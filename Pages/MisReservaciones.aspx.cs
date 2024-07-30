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
    public partial class MisReservaciones : System.Web.UI.Page
    {
        string conn = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idPersona"] == null)
            {
                Response.Redirect("~/Pages/Login.aspx");
            }
            int idPersona = Convert.ToInt32(Session["idPersona"]);
            if (!IsPostBack)
            {
                try
                {
                    using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                    {
                        var lista = db.SpMisReservaciones(idPersona)
                            .ToList()
                            .Select(res => new
                            {
                                res.IdReservacion,
                                res.Nombre,
                                res.FechaEntrada,
                                res.FechaSalida,
                                res.CostoTotal,
                                Estado = ObtenerEstado(res.Estado, res.FechaEntrada.Value, res.FechaSalida.Value)
                            })
                            .ToList();
                        gvMisReservaciones.DataSource = lista;
                        gvMisReservaciones .DataBind();
                    }
                }
                catch (Exception ex) 
                { 
            
                }
            }
           
        }
        private string ObtenerEstado(char estado, DateTime fechaEntrada, DateTime fechaSalida)
        {
            DateTime fechaActual = DateTime.Now;
            if (estado == 'I')
            {
                return "Cancelada";
            }
            if (estado == 'A')
            {
                if (fechaSalida < fechaActual)
                {
                    return "Finalizada";
                }
                if (fechaEntrada <= fechaActual)
                {
                    return "En proceso";
                }
                if (fechaEntrada > fechaActual && fechaSalida > fechaActual)
                {
                    return "En espera";
                }
            }
            return "Desconocido";
        }
    }
}