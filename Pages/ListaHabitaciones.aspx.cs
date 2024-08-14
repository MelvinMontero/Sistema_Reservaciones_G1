using DataModels;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Reservaciones_G1.Pages
{
   
    public partial class ListaHabitaciones : System.Web.UI.Page
    { //validador de sesiones
        string conn = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idPersona"] == null)
            {
                Response.Redirect("~/Pages/Login.aspx");
            }
            bool esEmpleado = Session["EsEmpleado"] != null && (bool)Session["EsEmpleado"];

            if (!IsPostBack && esEmpleado)
            {
                CargarHabitaciones();
            }
            else if (!esEmpleado)
            {
                Response.Redirect("~/Pages/MisReservaciones.aspx");
            }
        }
        //carga todas las habitaciones por medio de un spconsultarlistahabitaciones y las imprime en un gridview
        private void CargarHabitaciones()
        {
            try
            {
                using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                {
                    var lista = db.SpConsultarListaHabitaciones() //  procedimiento almacenado para cargar las habitaciones
                    .ToList()
                    .Select(hab => new
                    {
                        hab.ID,
                        hab.Hotel,
                        hab.NumeroHabitacion,
                        hab.CapacidadMaxima,
                        hab.Estado
                    })
                    .ToList();

                    gvHabitaciones.DataSource = lista;
                    gvHabitaciones.DataBind();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
            }
 
        }
   
    }
}

    

