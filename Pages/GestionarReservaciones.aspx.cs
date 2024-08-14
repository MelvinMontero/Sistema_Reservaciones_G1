using DataModels;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Sistema_Reservaciones_G1.Pages
{
    public partial class GestionarReservaciones : System.Web.UI.Page
    {
        string conn = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idPersona"] == null)
            {
                 Response.Redirect("~/Pages/Login.aspx");
            }
            if (!IsPostBack)
            {  //si es empleado empieza a cargar los datos 
                CargarClientes();
                CargarReservaciones();
            }
        }
        private void CargarClientes()
        {
            try
            { //se carga dentro de el drop down clientes los clientes de la base de datos por medio de consultar persona
                var lista = new List<ListItem>
                {
                    new ListItem("Seleccione un cliente", "")
                };
                using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                {
                    var query = db.SpConsultarPersona()
                        .OrderBy(p => p.NombreCompleto)
                        .Select(p => new ListItem(p.NombreCompleto, p.IdPersona.ToString()))
                        .ToList();
                    lista.AddRange(query);
                }
                ddlClientes.DataSource = lista;
                ddlClientes.DataTextField = "Text";
                ddlClientes.DataValueField = "Value";
                ddlClientes.DataBind();
            }
            catch (Exception ex)
            {
                Trace.Warn("Error al cargar clientes", ex.Message);
            }
        }
        private void CargarReservaciones()
        { //Usa un procedimiento almacenado (SpGestionarReservaciones) para obtener las reservaciones.
            try
            {
                using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                {
                    var lista = db.SpGestionarReservaciones()
                        .Select(x => new
                        {
                            x.IdReservacion,
                            x.NombreCompleto,
                            x.Nombre,
                            x.FechaEntrada,
                            x.FechaSalida,
                            x.CostoTotal,
                            Estado = ObtenerEstado(x.Estado, x.FechaEntrada.Value, x.FechaSalida.Value)
                        }).ToList(); //lista item

                    gvReservaciones.DataSource = lista;
                    gvReservaciones.DataBind();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
            }
        }
        //obtener estado es un metodo para validar si la habitacion esta cancelada,finalizada,en proceso o en espera segun su fecha
        private string ObtenerEstado(char estado, DateTime fechaEntrada, DateTime fechaSalida)
        {
            DateTime fechaActual = DateTime.Now;
            if (estado == 'I')
            {
                return "Cancelada";
            }
            if (estado == 'A')
            {
                if (fechaSalida < fechaActual) //si la fecha actual es mayor a la fecha de salida esta finalizada
                {
                    return "Finalizada";
                }
                if (fechaEntrada <= fechaActual) //si la fecha de entrada es menor o igual a la fecha actual esta en proceso
                {
                    return "En proceso";
                }
                if (fechaEntrada > fechaActual && fechaSalida > fechaActual) //si la fecha de entrada es mayor a la fecha actual y la fecha de salida es mayor a la fecha actual
                {
                    return "En espera";
                }
            }
            return "Desconocido";
        }

        //Permite al usuario filtrar las reservaciones mostradas en el GridView en función del cliente y un rango de fechas.
        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string clienteSeleccionado = ddlClientes.SelectedItem.Text;
            DateTime fechaEntrada = DateTime.MinValue;
            DateTime fechaSalida = DateTime.MinValue;

            if (DateTime.TryParse(txtFechaEntrada.Text, out fechaEntrada) &&
                DateTime.TryParse(txtFechaSalida.Text, out fechaSalida))
            {
                if (fechaSalida >= fechaEntrada) //selecciona los valores para imprimir de nuevo la lista con los datos seleccionados
                {
                    using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                    {
                        var listaReservaciones = db.SpGestionarReservaciones()
                            .Where(r => (clienteSeleccionado == "Seleccione un cliente" || r.NombreCompleto == clienteSeleccionado) &&
                                        r.FechaEntrada >= fechaEntrada && r.FechaSalida <= fechaSalida)
                            .Select(x => new
                            {
                                x.IdReservacion,
                                x.NombreCompleto,
                                x.Nombre,
                                x.FechaEntrada,
                                x.FechaSalida,
                                x.CostoTotal,
                                Estado = ObtenerEstado(x.Estado, x.FechaEntrada.Value, x.FechaSalida.Value)
                            }).ToList();

                        gvReservaciones.DataSource = listaReservaciones;
                        gvReservaciones.DataBind();
                    }
                }
                else
                {
                    lblMensaje.Text = "La fecha de salida debe ser mayor o igual a la fecha de entrada.";
                }
            }
            else
            {
                lblMensaje.Text = "Las fechas deben estar en el formato dd/MM/yyyy.";
            }

            txtFechaEntrada.Text = fechaEntrada.ToString("yyyy-MM-dd");
            txtFechaSalida.Text = fechaSalida.ToString("yyyy-MM-dd");
        }
        //valida que la fecha de salida no sea antes que la de entrada
        protected void ValidateFechaSalida(object source, ServerValidateEventArgs args)
        {
            DateTime fechaEntrada, fechaSalida;
            if (DateTime.TryParse(txtFechaEntrada.Text, out fechaEntrada) && DateTime.TryParse(args.Value, out fechaSalida))
            {
                if (fechaSalida < fechaEntrada)
                {
                    args.IsValid = false;
                }
                else
                {
                    args.IsValid = true;
                }
            }
            else
            {
                args.IsValid = false;
            }
        }
    }
}
