using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Desempenio2.MatiasGomez
{

    
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            divContenedor.Style["background-color"] = ddlColor.SelectedValue;
        }

        protected void ddlColor_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            divContenedor.Style["background-color"] = ddlColor.SelectedValue;
        }
        protected void Registrar_Click(object sender, EventArgs e)
        {
            
            if (Page.IsValid)
            {
                Usuario objetoUsuario = new Usuario
                {
                    Mail = txtMail.Text,
                    TipoUsuario = tipoUsuario.SelectedValue
                };
                Session["Usuario"] = objetoUsuario;
                HttpCookie cookieColor = new HttpCookie("colorFondo");
                cookieColor.Value = ddlColor.SelectedValue;
                cookieColor.Expires = DateTime.Now.AddDays(3);
                Response.Cookies.Add(cookieColor);
                Response.Redirect("Login.aspx");
            }
        }
    }
}