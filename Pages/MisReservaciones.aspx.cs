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
            //int idPersona = Convert.ToInt32(Session["idPersona"]);
            int idPersona = 1;
            try
            {
                using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                {
                    var lista = db.SpMisReservaciones(1);
                    var listaConEstado = lista.Select(r => new
                    {
                        r._Reservación,
                        r.Hotel,
                        fechaEntrada = r.FechaEntrada.ToString("dd/MM/yyyy"),
                        fechaSalida = r.FechaSalida.ToString("dd/MM/yyyy"),
                        costo = r.Costo.ToString("C2"),
                        estado = ObtenerEstado(r.Estado, r.FechaEntrada, r.FechaSalida)
                    }).ToList();

                    gvMisReservaciones.DataSource = listaConEstado;
                    gvMisReservaciones.DataBind();
                }
            }
            catch (Exception ex) 
            { 
            
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