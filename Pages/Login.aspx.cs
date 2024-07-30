using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using DataModels;
using LinqToDB;
using System.Data.SqlClient;
using System.Data;
using LinqToDB.DataProvider.SqlServer;
using LinqToDB.Data;


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
                    var persona.Value = db.SpAutenticarUsuario(Email, Clave).FirstOrDefault;
                    idPersona.Value = persona.idPersona
                }
                conexion.Open();
                string consulta = "SELECT * FROM PERSONA WHERE email='" + email + "' and clave='" + clave + "'";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                SqlDataReader read;
                read = comando.ExecuteReader();
                if (read.HasRows == true)
                {
                    Session["UsuarioID"] = read["idPersona"];
                    Session["NombreCompleto"] = read["nombreCompleto"];
                    Session["Email"] = read["email"];
                    Session["EsEmpleado"] = read["esEmpleado"];
                    Response.Redirect("~/Pages/MisReservaciones.aspx");
                }
                else {
                    lblMensaje.Text = "Usuario o Constraseña Incorrectos";
                }
            }
            catch { }

            
        }
    }
}