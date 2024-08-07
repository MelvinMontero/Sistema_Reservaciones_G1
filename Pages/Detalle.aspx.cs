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
            if (Session["idPersona"] == null)
            {
                Response.Redirect("~/Pages/Login.aspx");
            }
            if (!IsPostBack)
            {
                try
                {
                    int idReservacion = int.Parse(Request.QueryString["ID"]);
                    using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                    {
                        var detalle = db.SpConsultarReservacion(idReservacion).FirstOrDefault();
                        if (detalle != null) 
                        {
                            //Consultar la reservacion por id en los textbox
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

                            //Consultar la bitacora por id en el gridview
                            var bitacora = db.SpConsultarBitacora(idReservacion).FirstOrDefault();
                            int idBitacora = bitacora.IdBitacora;
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
                            if (Session["EsEmpleado"] != null && (bool)Session["EsEmpleado"])
                            {
                                if (estado == 'A' && detalle.FechaSalida > System.DateTime.Now)
                                {
                                    btnEditar.Visible = true;
                                }
                                else
                                {
                                    btnEditar.Visible = false;
                                }
                            }
                            else
                            {
                                if (estado == 'A' && detalle.FechaEntrada > System.DateTime.Now)
                                {
                                    btnEditar.Visible = true;
                                }
                                else
                                {
                                    btnEditar.Visible = false;
                                }
                            }
                        }
                        else
                        {
                            lblMensaje.Text = "Reservacion no encontrada.";
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Reservacion o Bitacora no encontrada." + ex;
                }
            }
            if (string.IsNullOrEmpty(lblMensaje.Text))
            {
                lblMensaje.Visible = false;
            }
            else
            {
                lblMensaje.Visible = true;
            }
            if (Session["EsEmpleado"] != null && (bool)Session["EsEmpleado"])
            {
                btnCancelar.Visible = true;
            }
            else
            {
                btnCancelar.Visible= false;
                
            }
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/EditarReservacion.aspx");
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
                        Response.Redirect("~/Pages/Exito.aspx?mensaje=Reservación%cancelada%20con%20éxito.");
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