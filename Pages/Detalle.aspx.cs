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
    public partial class Detalle : System.Web.UI.Page
    {
        string conn = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar si la sesión es válida
            if (Session["idPersona"] == null)
            {
                Response.Redirect("~/Pages/Login.aspx");
            }

            // Obtener el ID de la persona autenticada y si es empleado
            int idPersona = (int)Session["idPersona"];
            bool esEmpleado = Session["EsEmpleado"] != null && (bool)Session["EsEmpleado"];

            if (!IsPostBack)
            {
                try
                {
                    // Obtener el ID de la reservación desde la cadena de consulta
                    int idReservacion;
                    if (int.TryParse(Request.QueryString["ID"], out idReservacion))
                    {
                        using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                        {
                            // Obtener los detalles de la reservación
                            var detalle = db.SpConsultarReservacion(idReservacion).FirstOrDefault();

                            if (detalle != null)
                            {
                                // Verificar si la reservación pertenece al usuario autenticado si no es empleado
                                if (!esEmpleado && detalle.IdPersona != idPersona)
                                {
                                    // Redirigir a "Mis reservaciones" si la reservación no pertenece al usuario
                                    Response.Redirect("~/Pages/MisReservaciones.aspx");
                                }

                                // Cargar los detalles de la reservación en el formulario
                                TextResernum.Text = detalle.IdReservacion.ToString();
                                Texthotel.Text = detalle.Nombre.ToString();
                                Textnumhabit.Text = detalle.NumeroHabitacion.ToString();
                                Textnumcliente.Text = detalle.NombreCompleto.ToString();
                                Textfechaentrada.Text = detalle.FechaEntrada.Value.ToString("dd/MM/yyyy");
                                Textfechasalida.Text = detalle.FechaSalida.Value.ToString("dd/MM/yyyy");
                                Textdiareserva.Text = detalle.TotalDiasReservacion.ToString();
                                Textninos.Text = detalle.NumeroNinhos.ToString();
                                textAdultos.Text = detalle.NumeroAdultos.ToString();
                                Textcostototal.Text = detalle.CostoTotal.ToString();
                                char estado = detalle.Estado;

                                // Consultar la bitacora por id en el gridview
                                var lista = db.SpConsultarBitacora(idReservacion)
                                    .Select(x => new
                                    {
                                        x.FechaDeLaAccion,
                                        x.AccionRealizada,
                                        x.NombreCompleto,
                                    })
                                    .ToList();
                                grvBitacoras.DataSource = lista;
                                grvBitacoras.DataBind();

                                // Controlar la visibilidad del botón Editar
                                if (!esEmpleado)
                                {
                                    btnEditar.Visible = detalle.Estado == 'A' && detalle.FechaEntrada > DateTime.Now;
                                }
                                else if (esEmpleado)
                                {
                                    btnEditar.Visible = detalle.Estado == 'A' && detalle.FechaSalida > DateTime.Now;
                                }
                                else
                                {
                                    btnEditar.Visible = false;
                                }
                                DateTime fechaActual = DateTime.Now;
                                if (detalle.Estado == 'I')
                                {
                                    btnCancelar.Visible = false;
                                }
                            }   
                        }
                    }
                    else
                    {
                        lblMensaje.Text = "ID de reservación inválido.";
                    }
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Error al cargar la reservación o bitácora: " + ex.Message;
                }

                // Mostrar o esconder el mensaje de error
                lblMensaje.Visible = !string.IsNullOrEmpty(lblMensaje.Text);
            }

        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int idReservacion = int.Parse(Request.QueryString["ID"]);
            Response.Redirect($"~/Pages/EditarReservacion.aspx?id={idReservacion}");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            int idReservacion = int.Parse(Request.QueryString["ID"]);
            try
            {
                using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                {
                    var detalle = db.SpConsultarReservacion(idReservacion).FirstOrDefault();
                    if (detalle != null)
                    {
                        int idPersona = (int)Session["idPersona"];
                        bool esEmpleado = (bool)Session["EsEmpleado"];
                        if (!esEmpleado && detalle.IdPersona != idPersona)
                        {
                            Response.Redirect("~/Pages/MisReservaciones.aspx");
                            return;
                        }
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
                            return;
                        }

                        DateTime fechaActual = DateTime.Now.Date;

                        if (detalle.FechaSalida <= fechaActual)
                        {
                            if (esEmpleado)
                            {
                                Response.Redirect("~/Pages/GestionarReservaciones.aspx");
                            }
                            else
                            {
                                Response.Redirect("~/Pages/MisReservaciones.aspx");
                            }
                            return;
                        }

                        if (detalle.FechaEntrada <= fechaActual && detalle.FechaSalida > fechaActual)
                        {
                            if (esEmpleado)
                            {
                                Response.Redirect("~/Pages/GestionarReservaciones.aspx");
                            }
                            else
                            {
                                Response.Redirect("~/Pages/MisReservaciones.aspx");
                            }
                            return;
                        }
                        db.SpCancelarReservacion(idReservacion,idPersona);
                        Response.Redirect("~/Pages/Exito.aspx?mensaje=Reservación%20cancelada%20con%20éxito.");
                    }
                    else
                    {
                        lblMensaje.Text = "Reservación no encontrada.";
                        lblMensaje.Visible = true;
                    }
                }
            }catch (Exception ex)
            {
                lblMensaje.Text = "Ha ocurrido un error inesperado. " + ex.Message;
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
    }
}