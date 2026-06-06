using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Desempenio2.MatiasGomez
{
    public partial class Site3 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       protected void lnkCerrarSesion_Click(object sender, EventArgs e)
        {
          Session.Abandon();
          Response.Redirect("Registrar.aspx");
        }
    }
}