﻿using DataModels;
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
            try
            {
                var lista = new List<ListItem>
                {
                    new ListItem("Seleccione un hotel", "")
                };
                using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                {
                    var query = db.SpConsultarHotel()
                        .OrderBy(h => h.Nombre)
                        .Select(h => new ListItem(h.Nombre, h.IdHotel.ToString()))
                        .ToList();
                    lista.AddRange(query);
                }
                drdHotel.DataSource = lista;
                drdHotel.DataTextField = "Text";
                drdHotel.DataValueField = "Value";
                drdHotel.DataBind();
            }
            catch (Exception ex)
            {
                Trace.Warn("Error al cargar hoteles", ex.Message);
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
                    int Nombre = int.Parse(drdHotel.SelectedValue);
                    string numeroHabitacion = txtnumhabitacion.Text;
                    int capacidadMaxima = Convert.ToInt32(DropDownListcapacidad.SelectedValue);
                    string descripcion = txtDescripcion.Text;
                    using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                    {
                        db.SpCrearHabitacion(Nombre, numeroHabitacion, capacidadMaxima, descripcion);

                    }
                    Response.Redirect("~/Pages/ExitoHabitaciones.aspx?mensaje=Habitación%20creada%20con%20éxito.");
                }
                catch (Exception ex)
                {

                    lblMensaje.Text = "No se pudo guardar. " + ex;

                }

            }
        }
        protected void cvNumHabitacionUnico_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                // Obtén el ID del hotel desde la consulta si existe
                int idHotel = int.Parse(Request.QueryString["ID_Hotel"]);

                // Obtén el número de habitación ingresado por el usuario
                string numeroHabitacion = args.Value;

                using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                {
                    // Verifica si existe otra habitación con el mismo número en el mismo hotel
                    var habitacionDuplicada = db.SpConsultarListaHabitaciones()
                        .FirstOrDefault();
                    if (habitacionDuplicada.NumeroHabitacion.Equals(txtnumhabitacion))
                    {
                        lblMensaje.Text = "El número de habitación ya existe para este hotel.";
                        lblMensaje.Visible = true;
                        args.IsValid = false;
                        return;
                    }
                    else
                    {
                        args.IsValid = true; // El número de habitación es único
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al validar el número de habitación: " + ex.Message;
                lblMensaje.Visible = true;
                args.IsValid = false;
            }
        }
    }
}