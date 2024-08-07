﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using DataModels;
using System.Web.Security;

namespace Sistema_Reservaciones_G1
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EsEmpleado"] != null && (bool)Session["EsEmpleado"])
            {
                hlGestionarReservaciones.Visible = true;
                hlGestionarHabitaciones.Visible = true;
            }
            else
            {
                hlGestionarReservaciones.Visible = false;
                hlGestionarHabitaciones.Visible = false;
            }
            if (Session["NombreCompleto"] != null)
            {
                lblNombreUsuario.Text = Session["NombreCompleto"].ToString();
            }
            btnLogout.Text = Session["NombreCompleto"] != null ? "Cerrar Sesión" : "Ingresar";
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, string.Empty)
                {
                    Expires = DateTime.Now.AddDays(-1)
                };
                Response.Cookies.Add(authCookie);
            }
            Response.Redirect("~/Pages/Login.aspx");
        }
    }
}