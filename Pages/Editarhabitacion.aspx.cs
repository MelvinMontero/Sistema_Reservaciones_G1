using DataModels;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Reservaciones_G1.Pages
{
    public partial class Editarhabitacion : System.Web.UI.Page
    {
        string conn = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            //Verificacion de si el usuario esta registrado como persona o empleado
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
                
                
                }
                catch
                {

                }




            }
        }

        protected void Buttoninactivar_Click(object sender, EventArgs e)
        {

            try
            {
                int habitacionId = Convert.ToInt32(Hotelselec.Text);

                using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                {
                    db.InactivarHabitacion(habitacionId);
                }
            }
            catch 
            {
                Response.Redirect("Error");
            }





        }

        protected void ButtonGuardareditarhabitacion_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    int habitacionId = Convert.ToInt32(Hotelselec.Text);
                    string numeroHabitacion = txtnumhabitacion.Text;
                    int capacidadMaxima = Convert.ToInt32(DropDownListcapacidad.SelectedValue);
                    string descripcion = Textdescrip.Text;
                    using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                    {
                        db.EditarHabitacion(habitacionId, numeroHabitacion, capacidadMaxima, descripcion).FirstOrDefault();

                    }
                }
                catch
                {

                    Response.Redirect("Error");

                }





            }
        }

        protected void ButtonRegresar_Click(object sender, EventArgs e)
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