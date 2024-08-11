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
            //Verificacion de si el usuario esta registrado como persona o empleado
            if (Session["idPersona"] == null)
            {
                Response.Redirect("~/Pages/Login.aspx");
            }
            int idPersona = (int)Session["idPersona"];
            bool esEmpleado = Session["EsEmpleado"] != null && (bool)Session["EsEmpleado"];

            if (!IsPostBack)
            {
                
                    CargarHoteles();

               
               
            }
        }

        private void CargarHoteles()
        {
            if (Page.IsValid)
            {
                try
                {
                    using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                    {
                        var hoteles = db.SpCargartodoslosHoteles()
                        .OrderBy(h => h.Nombre)
                        .Select(h => h.Nombre)
                        .ToList();
                        droplisthoteles.DataSource = hoteles;
                        droplisthoteles.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error al cargar hoteles: {ex.Message}");
                }
            }
            
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaHabitaciones.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    int Nombre = int.Parse(droplisthoteles.SelectedValue);
                    string numeroHabitacion = txtnumhabitacion.Text;
                    int capacidadMaxima = Convert.ToInt32(DropDownListcapacidad.SelectedValue);
                    string descripcion = Textdescrip.Text;
                    using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                    {
                        db.SpCrearHabitacion(Nombre, numeroHabitacion, capacidadMaxima, descripcion);

                    }
                    Response.Redirect("ListaHabitaciones.aspx?mensaje=Habitación creada con éxito");
                }
                catch
                {

                    Response.Redirect("Error");

                }

            }
        }




    }
}