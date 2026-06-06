using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Desempenio2.MatiasGomez
{
    public partial class WebForm3 : System.Web.UI.Page
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
                CargarImagenes();
            }
        }
        
        private void CargarImagenes()
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                string sql = "SELECT id, nombreImagen FROM Imagenes";
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        ListBox1.DataSource = reader;
                        ListBox1.DataTextField = "nombreImagen";
                        ListBox1.DataValueField = "id";
                        ListBox1.DataBind();
                    }
                }
            }
        }

        // Alta de imagen
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            // 1. Verificamos que el usuario haya seleccionado un archivo
            if (fuImagen.HasFile)
            {
                string ext = Path.GetExtension(fuImagen.FileName).ToLower();

                if (ext == ".jpg" || ext == ".jpeg")
                {
                    // 🔥 LA CLAVE: Capturamos el nombre original del archivo (ejemplo: "mifoto.jpg")
                    // Path.GetFileNameWithoutExtension le quita el ".jpg" para guardarlo limpio como título
                    string nombreOriginal = Path.GetFileNameWithoutExtension(fuImagen.FileName);

                    // Generamos el código único para el archivo físico en el disco (Evita que se pisen archivos iguales)
                    string nombreArchivoUnico = Guid.NewGuid().ToString() + ext;
                    string rutaCarpeta = Server.MapPath("~/images/");
                    string rutaCompleta = rutaCarpeta + nombreArchivoUnico;

                    if (!Directory.Exists(rutaCarpeta))
                    {
                        Directory.CreateDirectory(rutaCarpeta);
                    }

                    // Guardamos el archivo físico en el servidor
                    fuImagen.SaveAs(rutaCompleta);

                    // Guardamos en la base de datos
                    using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                    {
                        conexion.Open();
                        // @nom guardará el nombre real (ej: "mifoto") y @arc el archivo físico
                        string sql = "INSERT INTO Imagenes (nombreImagen, nombreArchivo) VALUES (@nom, @arc)";
                        using (SqlCommand comando = new SqlCommand(sql, conexion))
                        {
                            comando.Parameters.AddWithValue("@nom", nombreOriginal);
                            comando.Parameters.AddWithValue("@arc", nombreArchivoUnico);
                            comando.ExecuteNonQuery();
                        }
                    }

                    CargarImagenes(); // Refrescamos el ListBox
                    lblStatus.Text = $"✅ Imagen '{nombreOriginal}' subida con éxito.";
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblStatus.Text = "❌ Solo se permiten archivos .jpg o .jpeg";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblStatus.Text = "❌ Por favor, seleccione un archivo antes de presionar Agregar.";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Consulta para mostrar
        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBox1.SelectedIndex != -1)
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string sql = "SELECT nombreImagen FROM Imagenes WHERE id = @id";
                    using (SqlCommand comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue("@id", ListBox1.SelectedValue);
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtNombreImagen.Text = reader["nombreImagen"].ToString();
                            }
                        }
                    }
                }
            }
        }

        // Modificar nombre
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (ListBox1.SelectedIndex != -1 && txtNombreImagen.Text != string.Empty)
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string sql = "UPDATE Imagenes SET nombreImagen = @nom WHERE id = @id";
                    using (SqlCommand comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue("@nom", txtNombreImagen.Text);
                        comando.Parameters.AddWithValue("@id", ListBox1.SelectedValue);
                        comando.ExecuteNonQuery();
                    }
                }

               CargarImagenes();
                txtNombreImagen.Text = string.Empty;
                lblStatus.Text = "✅ Nombre de imagen modificado.";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblStatus.Text = "❌ Seleccione una imagen de la lista para modificar.";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Eliminar Imagen
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ListBox1.SelectedIndex != -1)
            {
                string idSeleccionado = ListBox1.SelectedValue;
                string nombreArchivoABorrar = string.Empty;

                
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string sqlBuscar = "SELECT nombreArchivo FROM Imagenes WHERE id = @id";
                    using (SqlCommand comando = new SqlCommand(sqlBuscar, conexion))
                    {
                        comando.Parameters.AddWithValue("@id", idSeleccionado);
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nombreArchivoABorrar = reader["nombreArchivo"].ToString();
                            }
                        }
                    }
                }

                
                if (!string.IsNullOrEmpty(nombreArchivoABorrar))
                {
                    
                    string rutaCompleta = Server.MapPath("~/images/") + nombreArchivoABorrar;

                    if (File.Exists(rutaCompleta))
                    {
                        File.Delete(rutaCompleta); 
                    }
                }

               
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string sqlEliminar = "DELETE FROM Imagenes WHERE id = @id";
                    using (SqlCommand comando = new SqlCommand(sqlEliminar, conexion))
                    {
                        comando.Parameters.AddWithValue("@id", idSeleccionado);
                        comando.ExecuteNonQuery();
                    }
                }

                
                CargarImagenes();
                txtNombreImagen.Text = string.Empty;

                lblStatus.Text = "✅ Imagen eliminada .";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblStatus.Text = "❌ Seleccione una imagen de la lista para eliminar.";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}