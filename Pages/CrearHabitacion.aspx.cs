using DataModels;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;


namespace Sistema_Reservaciones_G1.Pages
{
    public partial class CrearHabitacion : System.Web.UI.Page
    {
        string conn = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Gestionarhabitaciones.aspx");
        }

        protected void ButtonGuardarcrearhabitacion_Click(object sender, EventArgs e)
        {
            if (Page.IsValid) { try
                {
                    int hotelId = Convert.ToInt32(droplisthoteles.SelectedValue);
                    string numeroHabitacion = txtnumhabitacion.Text;
                    int capacidadMaxima = Convert.ToInt32(DropDownListcapacidad.SelectedValue);
                    string descripcion = Textdescrip.Text;
                    using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                    {
                        db.SpConsultarHabitaciones(hotelId,numeroHabitacion,capacidadMaxima,descripcion).FirstOrDefault();

                    }
                }
                catch { 
                
                Response.Redirect("Error");
                
                }
           //se debe agregar un validador de pagina ?
            }
        }
    }
}