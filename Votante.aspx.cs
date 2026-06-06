using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Desempenio2.MatiasGomez
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["colorFondo"] != null)
            {
                divContenedor.Style["background-color"] = Request.Cookies["colorFondo"].Value;
            }
            if (!IsPostBack)
            {
                CargarGrillaVotacion();

                if (Session["votacionUsuario"] == null)
                {
                    Session["votacionUsuario"] = new List<string>();
                }

                ActualizarListaVisual();
            }
        }

        private void CargarGrillaVotacion()
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                string sql = "SELECT id, nombreImagen, nombreArchivo FROM Imagenes";
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        GridView1.DataSource = reader;
                        GridView1.DataBind();
                    }
                }
            }
        }

        private void ActualizarListaVisual()
        {
            if (Session["votacionUsuario"] != null)
            {
                List<string> listaVotos = (List<string>)Session["votacionUsuario"];

                blHistorialVotos.DataSource = listaVotos;
                blHistorialVotos.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Votar")
            {
                string idImagenVotada = e.CommandArgument.ToString();

                Button btnFila = (Button)e.CommandSource;
                GridViewRow filaSeleccionada = (GridViewRow)btnFila.NamingContainer;

                string nombreImagenVotada = filaSeleccionada.Cells[0].Text;

               List<string> listaVotos = (List<string>)Session["votacionUsuario"];

                string votoTexto = $"Votó por la imagen: {nombreImagenVotada} (ID: {idImagenVotada})";
                listaVotos.Add(votoTexto);

                Session["votacionUsuario"] = listaVotos;

                ActualizarListaVisual();

                lblVotos.Text = $"¡Voto registrado con éxito! Total de votos acumulados en tu sesión: {listaVotos.Count}";
            }
        }
    }
}