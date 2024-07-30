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
    public partial class Login : System.Web.UI.Page
    {
        string conn = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string Email = txtemail.Text;
            string Clave = pswclave.Text;
            try
            {
                using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                {
                    try
                    {
                        var persona = db.SpAutenticarUsuario(Email, Clave).FirstOrDefault();
                        if (persona!=null)
                        {
                            if (persona.Email.Equals(Email) && persona.Clave.Equals(Clave))
                            {
                                Session["idPersona"] = persona.IdPersona;
                                Session["NombreCompleto"] = persona.NombreCompleto;
                                Session["Email"] = persona.Email;
                                Session["EsEmpleado"] = persona.EsEmpleado;
                                if (Session["EsEmpleado"] != null && (bool)Session["EsEmpleado"])
                                {
                                    Response.Redirect("~/Pages/GestionarReservaciones.aspx");
                                }
                                else
                                {
                                    Response.Redirect("~/Pages/MisReservaciones.aspx");
                                }

                            }
                            else
                            {
                                lblMensaje.Text = "Usuario o Constraseña Incorrectos";
                            }
                        }
                        else
                        {
                            lblMensaje.Text = "Usuario o Constraseña Incorrectos";
                        }

                    }
                    catch (Exception ex)
                    {
                        lblMensaje.Text = "Usuario o Constraseña Incorrectos o Cuenta Inactiva";
                        System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                    }     
                }
            }
            catch (Exception ex) {
                lblMensaje.Text = "Ocurrió un error al intentar iniciar sesión. Por favor, intente nuevamente.";
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}