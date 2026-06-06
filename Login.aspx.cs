using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Desempenio2.MatiasGomez
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["colorFondo"] != null)
            {
                divContenedor.Style["background-color"] = Request.Cookies["colorFondo"].Value;
            }
            if (!IsPostBack && Session["Usuario"] != null)
            {
                Usuario usu = (Usuario)Session["Usuario"];
                txtMail.Text = usu.Mail;
            }
        }

        protected void Ingresar_Click(object sender, EventArgs e)
        {
            
            if (Page.IsValid)
            {
                if (Session["Usuario"] != null)
                {
                    Usuario usu = (Usuario)Session["Usuario"];
                    if (txtMail.Text.Trim() == usu.Mail)
                    {
                        if (usu.TipoUsuario == "Publicador")
                        {
                            Response.Redirect("Publicador.aspx");
                        }
                        else if (usu.TipoUsuario == "Votante")
                        {
                            Response.Redirect("Votante.aspx");
                        }
                    }
                    else
                    {
                        lblError.Text = "❌ El mail ingresado no coincide con el usuario registrado en la sesión.";
                    }
                }
                else
                {
                    lblError.Text = "❌ No se encontró ninguna sesión activa. Primero debe pasar por el formulario Registrar";
                }
            }
        }

    }
}