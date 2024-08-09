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
            {
                CargarClientes();
                CargarReservaciones();
            }
        }
        private void CargarClientes()
        {
            try
            {
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
        {
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
                        }).ToList();

                    gvReservaciones.DataSource = lista;
                    gvReservaciones.DataBind();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
            }
        }
        private string ObtenerEstado(char estado, DateTime fechaEntrada, DateTime fechaSalida)
        {
            DateTime fechaActual = DateTime.Now;
            if (estado == 'I')
            {
                return "Cancelada";
            }
            if (estado == 'A')
            {
                if (fechaSalida < fechaActual)
                {
                    return "Finalizada";
                }
                if (fechaEntrada <= fechaActual)
                {
                    return "En proceso";
                }
                if (fechaEntrada > fechaActual && fechaSalida > fechaActual)
                {
                    return "En espera";
                }
            }
            return "Desconocido";
        }
        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string clienteSeleccionado = ddlClientes.SelectedItem.Text;
            DateTime fechaEntrada = DateTime.MinValue;
            DateTime fechaSalida = DateTime.MinValue;

            if (DateTime.TryParse(txtFechaEntrada.Text, out fechaEntrada) &&
                DateTime.TryParse(txtFechaSalida.Text, out fechaSalida))
            {
                if (fechaSalida >= fechaEntrada)
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
