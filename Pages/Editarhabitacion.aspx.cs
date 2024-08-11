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
                    int habitacionId = int.Parse(Request.QueryString["ID"]);

                    using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                    {

                        var habitacion = db.SpConsultarHabitaciones(habitacionId).FirstOrDefault();

                        if (habitacion == null)
                        {
                            lblMensaje.Text = "La habitación no fue encontrada.";
                            lblMensaje.Visible = true;
                            return;
                        }
                        if (habitacion.Estado == 'I')
                        {
                            Response.Redirect("~/Pages/CrearHabitacion.aspx");
                        }
                        

                        // Aqui carga los datos de habitacion seleccionada
                        
                        Hotelselec.Text = habitacion.Nombre;  
                        txtnumhabitacion.Text = habitacion.NumeroHabitacion;
                        DropDownListcapacidad.SelectedValue = habitacion.CapacidadMaxima.ToString();
                        Textdescrip.Text = habitacion.Descripcion;

                    }
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Ocurrió un error al cargar la habitación: " + ex.Message;
                    lblMensaje.Visible = true;
                }



            }
        }






        protected void Buttoninactivar_Click(object sender, EventArgs e)
        {


            try
            {
                int habitacionId = int.Parse(Request.QueryString["ID"]);

                using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                {
                    db.InactivarHabitacion(habitacionId);
                }

                Response.Redirect("~/Pages/MensajeExito.aspx?mensaje=la habitación ha sido inactivada exitosamente");
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al inactivar la habitación: " + ex.Message;
                lblMensaje.Visible = true;
            }


        }

        protected void ButtonGuardareditarhabitacion_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    //int idHabitacion = int.Parse(Request.QueryString["ID"]);??
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
            Response.Redirect("~/Pages/ListaHabitaciones.aspx");
        }
    }
}
