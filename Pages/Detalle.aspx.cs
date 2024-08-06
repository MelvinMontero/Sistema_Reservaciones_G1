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
            /*if (Session["idPersona"] == null)
            {
                Response.Redirect("~/Pages/Login.aspx");
            }*/
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
                            TextResernum.Text = detalle.IdReservacion.ToString();
                            Texthotel.Text = detalle.Nombre.ToString();
                            Textnumhabit.Text = detalle.NumeroHabitacion.ToString();
                            Textnumcliente.Text = detalle.NombreCompleto.ToString();
                            Textfechaentrada.Text = detalle.FechaEntrada.Value.ToString("dd/MM/yyyy");
                            Textfechasalida.Text = detalle.FechaSalida.Value.ToString("dd/MM/yyyy");
                            Textdiareserva.Text = detalle.TotalDiasReservacion.ToString();
                            Textninos.Text = detalle.NumeroNinhos.ToString();
                            textAdultos.Text = detalle.NumeroAdultos.ToString();
                            decimal costoTotal = detalle.CostoTotal;
                            string costoTotaltxt = String.Format("{ 0:C}", costoTotal);
                            Textcostototal.Text = costoTotaltxt;
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
                        }
                        else
                        {
                            lblMensaje.Text = "Reservacion no encontrada.";
                        }
                        
                    }
                }
                catch (Exception)
                {
                    lblMensaje.Text = "Reservacion no encontrada o Bitacora.";
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
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {

        }
    }
}