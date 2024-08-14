using Azure.Core;
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
            { //si se realiza la carga se cargan los datos consultando si la habitacion del id existe y esta en la lista, tambien si no esta inactiva
                try
                {
                    int habitacionId = int.Parse(Request.QueryString["ID"]);

                    using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                    {

                        var habitacion = db.SpConsultarHabitaciones(habitacionId).FirstOrDefault();
                        var listaHabitacion = db.SpConsultarListaHabitaciones().FirstOrDefault();
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
        //se inactiva la habitacion segun el id de query string por el metodo inactivar habitacion
        protected void Buttoninactivar_Click(object sender, EventArgs e)
        {
            try
            {
                int habitacionId = int.Parse(Request.QueryString["ID"]);

                using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                {
                    db.InactivarHabitacion(habitacionId);
                }

                Response.Redirect("~/Pages/ExitoHabitaciones.aspx?mensaje=Habitación%20editada%20con%20éxito.");
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
                    int idHabitacion = int.Parse(Request.QueryString["ID"]);
                    string numeroHabitacion = txtnumhabitacion.Text;
                    int capacidadMaxima = Convert.ToInt32(DropDownListcapacidad.SelectedValue);
                    string descripcion = Textdescrip.Text;

                    // Validación: Verificar que la capacidad máxima sea mayor a 0
                    if (capacidadMaxima <= 0)
                    {
                        lblMensaje.Text = "La capacidad máxima debe ser mayor a 0.";
                        lblMensaje.Visible = true;
                        return;
                    }

                    // Validación: Verificar que la descripción no esté vacía
                    if (string.IsNullOrWhiteSpace(descripcion))
                    {
                        lblMensaje.Text = "La descripción no puede estar vacía.";
                        lblMensaje.Visible = true;
                        return;
                    }

                    using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                    {
                        // Validación: Verificar que el número de habitación no esté duplicado
                        var habitacionDuplicada = db.SpConsultarListaHabitaciones().FirstOrDefault();

                        if (habitacionDuplicada.NumeroHabitacion.Equals(txtnumhabitacion))
                        {
                            lblMensaje.Text = "El número de habitación ya existe para este hotel.";
                            lblMensaje.Visible = true;
                            return;
                        }

                        // Si todas las validaciones son exitosas, procede a actualizar la habitación pot el metodo de editar
                        db.EditarHabitacion(idHabitacion, numeroHabitacion, capacidadMaxima, descripcion);
                    }

                    // Redirecciona a la página de éxito
                    Response.Redirect("~/Pages/ExitoHabitaciones.aspx?mensaje=Habitación%20editada%20con%20éxito.");
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Error al actualizar la habitación: " + ex.Message;
                    lblMensaje.Visible = true;
                }





            }
        }

        protected void ButtonRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/ListaHabitaciones.aspx");
        }


        
    }
}
