using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using DataModels;
using LinqToDB;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace Sistema_Reservaciones_G1.Pages
{
    public partial class EditarReservacion : System.Web.UI.Page
    {
        string conn = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
        int numeroPersonas;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idPersona"] == null)
            {
                Response.Redirect("~/Pages/Login.aspx");
            }
            int idPersona = (int)Session["idPersona"];
            bool esEmpleado = Session["EsEmpleado"] != null && (bool)Session["EsEmpleado"];
            if (!IsPostBack)
            {
                try
                {
                    int idReservacion = int.Parse(Request.QueryString["ID"]);
                    
                    using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn))) 
                    {

                        var detalle = db.SpConsultarReservacion(idReservacion).FirstOrDefault();
                        if (!esEmpleado && detalle.IdPersona != idPersona)
                        {
                            Response.Redirect("~/Pages/MisReservaciones.aspx");
                        }
                        txtHotel.Text = detalle.Nombre.ToString();
                        txtHabitacion.Text = detalle.NumeroHabitacion.ToString();
                        txtCliente.Text =   detalle.NombreCompleto.ToString();
                        txtFechaEntrada.Text = detalle.FechaEntrada.Value.ToString("dd/MM/yyyy");
                        txtFechaSalida.Text = detalle.FechaSalida.Value.ToString("dd/MM/yyyy");
                        txtnumeroAdultos.Text = detalle.NumeroAdultos.ToString();
                        txtnumeroNinhos.Text = detalle.NumeroNinhos.ToString();
                        
                        //Redirigir según el estado de la reservación
                        if (detalle.Estado == 'I')
                        {
                            if (esEmpleado)
                            {
                                Response.Redirect("~/Pages/GestionarReservaciones.aspx");
                            }
                            else
                            {
                                Response.Redirect("~/Pages/MisReservaciones.aspx");
                            }
                        }

                        // Redirigir si la fecha de salida es menor o igual a la fecha actual
                        if (detalle.FechaSalida <= DateTime.Now)
                        {
                            if (esEmpleado)
                            {
                                Response.Redirect("~/Pages/GestionarReservaciones.aspx");
                            }
                            else
                            {
                                Response.Redirect("~/Pages/MisReservaciones.aspx");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = ex.Message;
                    lblMensaje.Visible = true;
                }
            }
            lblMensaje.Visible = false;
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int idReservacion = int.Parse(Request.QueryString["ID"]);
                try
                {
                    DateTime fechaEntrada = DateTime.Parse(txtFechaEntrada.Text);
                    DateTime fechaSalida = DateTime.Parse(txtFechaSalida.Text);
                    int numeroAdultos = int.Parse(txtnumeroAdultos.Text);
                    int numeroNinhos = int.Parse(txtnumeroNinhos.Text);
                    int numeroPersonasValidar = numeroAdultos + numeroNinhos;
                    int totalDiasReservacion = (fechaSalida - fechaEntrada).Days;
                    DateTime fechaModificacion = System.DateTime.Now;
                    if (totalDiasReservacion == 0)
                    {
                        totalDiasReservacion = 1;
                    }
                    using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                    {
                        var detalle = db.SpConsultarReservacion(idReservacion).FirstOrDefault();
                        int idHotel = detalle.IdHotel;
                        if (numeroPersonasValidar <= detalle.CapacidadMaxima)
                        {
                            var habitacion = db.SpConsultarHabitaciones(idHotel, numeroPersonasValidar).FirstOrDefault();
                            decimal costoPorCadaAdulto = habitacion.CostoPorCadaAdulto;
                            decimal costoPorCadaNinho = habitacion.CostoPorCadaNinho;
                            decimal costoTotal = totalDiasReservacion * ((numeroAdultos * costoPorCadaAdulto) + (numeroNinhos * costoPorCadaNinho));
                            db.SpModificarReservacion(idReservacion, 
                                fechaEntrada, 
                                fechaSalida, 
                                numeroAdultos, 
                                numeroNinhos, 
                                totalDiasReservacion, 
                                costoPorCadaAdulto,
                                costoPorCadaNinho, 
                                costoTotal, 
                                fechaModificacion);
                            int idPersona = (int)Session["idPersona"];
                            db.SpCrearBitacora(idPersona, "CORREGIDA");
                            Response.Redirect("~/Pages/Exito.aspx?mensaje=Reservación%20modificada%20con%20éxito.");
                        }
                        else
                        {
                            lblMensaje.Text = "Has superado la capacidad maxima de la habitación.";
                            lblMensaje.Visible = true;
                        }
                    }
                        
                }
                catch (Exception ex) 
                {
                    lblMensaje.Text = ex.Message;
                    lblMensaje.Visible = true;
                }
            }
            
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            if (Session["EsEmpleado"] != null && (bool)Session["EsEmpleado"])
            {
                Response.Redirect("~/Pages/GestionarReservaciones.aspx");
            }
            else
            {
                Response.Redirect("~/Pages/MisReservaciones.aspx");
            }
        }

        protected void cvFechaEntrada_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime fechaEntrada;
            if (DateTime.TryParseExact(args.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaEntrada))
            {
                if (fechaEntrada > DateTime.Now)
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void cvFechaSalida_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime fechaSalida;
            if (DateTime.TryParseExact(args.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaSalida))
            {
                if (fechaSalida > DateTime.Now)
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }
            else
            {
                args.IsValid = false;
            }
        }
    }
}