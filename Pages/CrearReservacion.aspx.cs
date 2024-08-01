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
        protected void ValidateFechaEntrada(object source, ServerValidateEventArgs args)
        {
            DateTime fechaEntrada;
            if (DateTime.TryParseExact(args.Value, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaEntrada))
            {
                args.IsValid = fechaEntrada > DateTime.Now;
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
            if (DateTime.TryParseExact(txtFechaEntrada.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaEntrada) &&
                DateTime.TryParseExact(args.Value, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaSalida))
            {
                args.IsValid = fechaSalida > fechaEntrada;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
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

                        
                        using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                        {
                            var habitacion = db.SpConsultarHabitaciones(idHotel,totalPersonas).FirstOrDefault();
                            if (habitacion != null) 
                            {

                            }
                            else
                            {

                            }
                            int idPersona = (int)Session["idPersona"];
                            db.InsertBitacora(idPersona, "CREADA");

                            // Redirigir a la página de éxito
                            string urlRedirect = (Session["EsEmpleado"] != null && (bool)Session["EsEmpleado"])
                                ? "~/Pages/GestionarReservaciones.aspx"
                                : "~/Pages/MisReservaciones.aspx";

                            Response.Redirect(urlRedirect);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Manejo de excepciones y mensajes de error
                        Trace.Warn("Error al guardar la reserva", ex.Message);
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Se produjo un error al guardar la reservación.');", true);
                    }
                }
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Session["EsEmpleado"]!=null && (bool)Session["EsEmpleado"])
            {
                Response.Redirect("~/Pages/GestionarRervaiones.aspx");
            }
            else
            {
                Response.Redirect("~/Pages/MisRervaiones.aspx");
            }
        }
    }
}