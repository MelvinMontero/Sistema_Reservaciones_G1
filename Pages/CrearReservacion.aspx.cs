using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using DataModels;
using LinqToDB;

namespace Sistema_Reservaciones_G1.Pages
{
    public partial class CrearReservacion : System.Web.UI.Page
    {
        string conn = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idPersona"] == null)
            {
                Response.Redirect("~/Pages/Login.aspx");
            }

            if (!Page.IsPostBack)
            {
                CargarHoteles();
                CargarClientes();
            }
        }
        private void CargarHoteles()
        {
            try
            {
                var lista = new List<ListItem>
                {
                    new ListItem("Seleccione un hotel", "")
                };
                using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                {
                    var query = db.SpConsultarHotel()
                        .OrderBy(h => h.Nombre)
                        .Select(h => new ListItem(h.Nombre, h.IdHotel.ToString()))
                        .ToList();
                    lista.AddRange(query);
                }
                drdHotel.DataSource = lista;
                drdHotel.DataTextField = "Text";
                drdHotel.DataValueField = "Value";
                drdHotel.DataBind();
            }
            catch (Exception ex)
            {
                Trace.Warn("Error al cargar hoteles", ex.Message);
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

                drdCliente.DataSource = lista;
                drdCliente.DataTextField = "Text";
                drdCliente.DataValueField = "Value";
                drdCliente.DataBind();

                if (Session["EsEmpleado"] == null || !(bool)Session["EsEmpleado"])
                {
                    drdCliente.Enabled = false;
                    drdCliente.SelectedValue = Session["idPersona"].ToString();
                }
            }
            catch (Exception ex)
            {
                Trace.Warn("Error al cargar clientes", ex.Message);
            }
        }
        
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {             
                try
                {
                    int idHotel = int.Parse(drdHotel.SelectedValue);
                    int idCliente = int.Parse(drdCliente.SelectedValue);
                    DateTime fechaEntrada = DateTime.Parse(txtFechaEntrada.Text);
                    DateTime fechaSalida = DateTime.Parse(txtFechaSalida.Text);
                    int numAdultos = int.Parse(txtNumAdultos.Text);
                    int numNinos = int.Parse(txtNumNinhos.Text);
                    int totalPersonas = numAdultos + numNinos;
                    int totalDiasReservacion = (fechaSalida - fechaEntrada).Days;
                    decimal costoTotal = 0;
                    if (totalDiasReservacion == 0)
                    {
                        totalDiasReservacion = 1;
                    }
                    using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                    {
                        var habitacion = db.SpConsultarHabitacionesPorId(idHotel,totalPersonas).FirstOrDefault();
                        if (habitacion == null) 
                        {
                            lblMensaje.Text = "No hay habitaciones disponibles con la capacidad requerida. Por favor, cambie el número de personas o seleccione otro hotel.";
                        }
                        else
                        {
                            int idHabitacion = habitacion.IdHabitacion;
                            string nHabitacion = habitacion.NumeroHabitacion;
                            int capacidadMaxima = habitacion.CapacidadMaxima;
                            decimal costoPorCadaAdulto = habitacion.CostoPorCadaAdulto;
                            decimal costoPorCadaNinho = habitacion.CostoPorCadaNinho;
                            costoTotal = totalDiasReservacion * ((numAdultos * costoPorCadaAdulto) + (numNinos * costoPorCadaNinho));
                            DateTime fechaCreacion = DateTime.Now;
                            char estado = 'A';
                            db.SpCrearReservacion(idCliente,
                                idHabitacion,
                                fechaEntrada,
                                fechaSalida,
                                numAdultos,
                                numNinos,
                                totalDiasReservacion,
                                costoPorCadaAdulto,
                                costoPorCadaNinho,
                                costoTotal,
                                fechaCreacion,
                                estado);
                            int idPersona = (int)Session["idPersona"];
                            db.SpCrearBitacora(idPersona, "CREADA");
                            Response.Redirect("~/Pages/Exito.aspx?mensaje=Reservación%20creada%20con%20éxito.");

                        }
                    }
                }
                catch (Exception ex)
                {
                    Trace.Warn("Error al guardar la reserva", ex.Message);
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Se produjo un error al guardar la reservación.');", true);
                }               
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Session["EsEmpleado"]!=null && (bool)Session["EsEmpleado"])
            {
                Response.Redirect("~/Pages/GestionarReservaciones.aspx");
            }
            else
            {
                Response.Redirect("~/Pages/Reservaciones.aspx");
            }
        }
        protected void ValidateFechaEntrada(object source, ServerValidateEventArgs args)
        {
            DateTime fechaEntrada;
            DateTime fechaSalida;

            if (DateTime.TryParseExact(args.Value, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out fechaEntrada) &&
                DateTime.TryParseExact(txtFechaSalida.Text, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out fechaSalida))
            {
                args.IsValid = fechaEntrada.Date >= DateTime.Now.Date && fechaEntrada.Date <= fechaSalida.Date;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void ValidateFechaSalida(object source, ServerValidateEventArgs args)
        {
            DateTime fechaEntrada;
            DateTime fechaSalida;
            if (DateTime.TryParseExact(txtFechaEntrada.Text, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out fechaEntrada) &&
                DateTime.TryParseExact(args.Value, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out fechaSalida))
            {
                args.IsValid = fechaSalida.Date >= fechaEntrada.Date && fechaSalida.Date >= DateTime.Now.Date;
            }
            else
            {
                args.IsValid = false;
            }
        }
    }
}