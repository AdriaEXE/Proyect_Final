using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wikia
{
    public partial class BackOffice : System.Web.UI.Page
    {
        string strConexion = "Server=(local); Database=css; Integrated Security=true";
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ListarMangas();
            ListarLinks();
            ListarTipos();
            ListarInformacion();
        }

        void ListarMangas()
        {
            using (var cn = new SqlConnection(strConexion))
            {
                using (var command = new SqlCommand("Select * from topp", cn))
                {
                    cn.Open();
                    var reader = command.ExecuteReader();
                    if (reader != null && reader.HasRows)
                    {
                        ListItem item;
                        while (reader.Read())
                        {
                            item = new ListItem();
                            item.Text = reader["nom"].ToString();
                            item.Value = reader["cod"].ToString();
                            cbMangas.Items.Add(item);
                        }

                    }
                }
            }
        }

        void ListarLinks()
        {
            using (var cn = new SqlConnection(strConexion))
            {
                using (var command = new SqlCommand("Select * from links", cn))
                {
                    cn.Open();
                    var reader = command.ExecuteReader();
                    if (reader != null && reader.HasRows)
                    {
                        ListItem item;
                        while (reader.Read())
                        {
                            item = new ListItem();
                            item.Text = reader["pagina"].ToString();
                            item.Value = reader["cod"].ToString();
                            cbSitios.Items.Add(item);
                        }

                    }
                }
            }
        }

        void ListarTipos()
        {
            using (var cn = new SqlConnection(strConexion))
            {
                using (var command = new SqlCommand("Select * from tipos", cn))
                {
                    cn.Open();
                    var reader = command.ExecuteReader();
                    if (reader != null && reader.HasRows)
                    {
                        ListItem item;
                        while (reader.Read())
                        {
                            item = new ListItem();
                            item.Text = reader["genero"].ToString();
                            item.Value = reader["cod"].ToString();
                            cbTipos.Items.Add(item);
                        }

                    }
                }
            }
        }

        void ListarInformacion()
        {
            using (var cn = new SqlConnection(strConexion))
            {
                using (var command = new SqlCommand("Select texto from concep", cn))
                {
                    cn.Open();
                    var reader = command.ExecuteReader();
                    if (reader != null && reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            txtInformacion.Text = reader["texto"].ToString();
                        }
                    }
                }
            }
        }

        //Para tabla conceptos
        protected void ActualizarInformacion(object sender, EventArgs e)
        {
            using (var cn = new SqlConnection(strConexion))
            {
                string informacion = txtInformacion.Text;
                cn.Open();
                var query = "UPDATE concep SET texto=@texto " +
                    "WHERE cod = 1";
                using (var command = new SqlCommand(query, cn))
                {
                    command.Parameters.AddWithValue("@texto", informacion);
                    command.ExecuteNonQuery();
                }
            }
        }

        
        //Para tabla links
        protected void ActualizarLink(object sender, EventArgs e)
        {
            using (var cn = new SqlConnection(strConexion))
            {
                string nombre, link;
                int codigo;
                nombre = txtNombrePagina.Text;
                codigo = int.Parse(txtCodigoPagina.Text);
                link = txtLinkPagina.Text;

                cn.Open();
                var query = "UPDATE links SET pagina=@pagina, link=@link WHERE cod=@cod ";
                using (var command = new SqlCommand(query, cn))
                {
                    command.Parameters.AddWithValue("@pagina", nombre);
                    command.Parameters.AddWithValue("@link", link);
                    command.Parameters.AddWithValue("@cod", codigo);
                    command.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                            "mensaje", "alert('Link Actualizado correctamente')", true);
                }
            }
        }

        protected void EliminarLink(object sender, EventArgs e)
        {
            using (var cn = new SqlConnection(strConexion))
            {
                int codigo;
                codigo = int.Parse(txtCodigoPagina.Text);

                cn.Open();
                var query = "DELETE FROM links WHERE cod=@cod ";
                using (var command = new SqlCommand(query, cn))
                {
                    command.Parameters.AddWithValue("@cod", codigo);
                    command.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                            "mensaje", "alert('Link eliminado correctamente')", true);
                }
            }
        }

        protected void CrearLink(object sender, EventArgs e)
        {
            using (var cn = new SqlConnection(strConexion))
            {
                string nombre, link;
                int codigo;
                nombre = txtNombrePagina.Text;
                codigo = int.Parse(txtCodigoPagina.Text);
                link = txtLinkPagina.Text;

                cn.Open();
                var query = "INSERT INTO links values(@cod, @nombre, @link)";
                using (var command = new SqlCommand(query, cn))
                {
                    command.Parameters.AddWithValue("@cod", codigo);
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@link", link);
                    command.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                            "mensaje", "alert('Link creado correctamente')", true);
                }
            }
        }

        protected void LlenarSitio(object sender, EventArgs e)
        {
            using (var cn = new SqlConnection(strConexion))
            {
                using (var command = new SqlCommand("Select * from links WHERE pagina = @pagina", cn))
                {
                    cn.Open();
                    command.Parameters.AddWithValue("@pagina", "InManga");
                    var reader = command.ExecuteReader();
                    if (reader != null && reader.HasRows)
                    {
                        reader.Read();
                        txtCodigoPagina.Text = reader["cod"].ToString();
                        txtNombrePagina.Text = reader["pagina"].ToString();
                        txtLinkPagina.Text = reader["link"].ToString();
                        
                    }
                }
            }
        }

        //Tabla tipos
        protected void ActualizarTipo(object sender, EventArgs e)
        {
            using (var cn = new SqlConnection(strConexion))
            {
                string genero,desc;
                int codigo;
                genero = txtNombreTipo.Text;
                codigo = int.Parse(txtCodigoTipo.Text);
                desc = txtDescripcion.Text;

                cn.Open();
                var query = "UPDATE tipos SET genero=@genero, descripcion=@desc WHERE cod=@cod ";
                using (var command = new SqlCommand(query, cn))
                {
                    command.Parameters.AddWithValue("@genero", genero);
                    command.Parameters.AddWithValue("@desc", desc);
                    command.Parameters.AddWithValue("@cod", codigo);
                    command.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                            "mensaje", "alert('Tipo actualizado correctamente)", true);
                }
            }
        }

        protected void EliminarTipo(object sender, EventArgs e)
        {
            using (var cn = new SqlConnection(strConexion))
            {
                int codigo;
                codigo = int.Parse(txtCodigoTipo.Text);

                cn.Open();
                var query = "DELETE FROM tipos WHERE cod=@cod ";
                using (var command = new SqlCommand(query, cn))
                {
                    command.Parameters.AddWithValue("@cod", codigo);
                    command.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                            "mensaje", "alert('Tipo eliminado correctamente')", true);
                }
            }
        }

        protected void CrearTipo(object sender, EventArgs e)
        {
            using (var cn = new SqlConnection(strConexion))
            {
                string genero, desc;
                int codigo;
                genero = txtNombreTipo.Text;
                codigo = int.Parse(txtCodigoTipo.Text);
                desc = txtDescripcion.Text;

                cn.Open();
                var query = "INSERT INTO links values(@cod, @genero, @desc)";
                using (var command = new SqlCommand(query, cn))
                {
                    command.Parameters.AddWithValue("@cod", codigo);
                    command.Parameters.AddWithValue("@genero", genero);
                    command.Parameters.AddWithValue("@desc", desc);
                    command.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                            "mensaje", "alert('Tipo creado correctamente')", true);
                }
            }
        }

        protected void LlenarTipo(object sender, EventArgs e)
        {
            using (var cn = new SqlConnection(strConexion))
            {
                using (var command = new SqlCommand("Select * from tipos WHERE genero = @genero", cn))
                {
                    cn.Open();
                    command.Parameters.AddWithValue("@genero", "Shonen");
                    var reader = command.ExecuteReader();
                    if (reader != null && reader.HasRows)
                    {
                        reader.Read();
                        txtCodigoTipo.Text = reader["cod"].ToString();
                        txtNombreTipo.Text = reader["genero"].ToString();
                        txtDescripcion.Text = reader["descripcion"].ToString();

                    }
                }
            }
        }

        //TAbla mangas
        protected void ActualizarManga(object sender, EventArgs e)
        {
            using (var cn = new SqlConnection(strConexion))
            {
                string nombre;
                int codigo;
                nombre = txtNombreManga.Text;
                codigo = int.Parse(txtCoidigoManga.Text);

                cn.Open();
                var query = "UPDATE topp SET nom=@nombre WHERE cod=@cod ";
                using (var command = new SqlCommand(query, cn))
                {
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@cod", codigo);
                    command.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                            "mensaje", "alert('Manga actualizado correctamente')", true);
                }
            }
        }

        protected void EliminarManga(object sender, EventArgs e)
        {
            using (var cn = new SqlConnection(strConexion))
            {
                int codigo;
                codigo = int.Parse(txtCoidigoManga.Text);

                cn.Open();
                var query = "DELETE FROM topp WHERE cod=@cod ";
                using (var command = new SqlCommand(query, cn))
                {
                    command.Parameters.AddWithValue("@cod", codigo);
                    command.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                            "mensaje", "alert('Manga eliminado correctamente')", true);
                }
            }
        }

        protected void CrearManga(object sender, EventArgs e)
        {
            using (var cn = new SqlConnection(strConexion))
            {
                string nombre;
                int codigo;
                nombre = txtNombreManga.Text;
                codigo = int.Parse(txtCoidigoManga.Text);

                cn.Open();
                var query = "INSERT INTO topp values(@cod, @nom)";
                using (var command = new SqlCommand(query, cn))
                {
                    command.Parameters.AddWithValue("@cod", codigo);
                    command.Parameters.AddWithValue("@nom", nombre);
                    command.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                            "mensaje", "alert('Manga creado correctamente')", true);
                }
            }
        }

        protected void LlenarManga(object sender, EventArgs e)
        {
            using (var cn = new SqlConnection(strConexion))
            {
                using (var command = new SqlCommand("Select * from topp WHERE nom = @nom", cn))
                {
                    cn.Open();
                    command.Parameters.AddWithValue("@nom", "One Piece");
                    var reader = command.ExecuteReader();
                    if (reader != null && reader.HasRows)
                    {
                        reader.Read();
                        txtCoidigoManga.Text = reader["cod"].ToString();
                        txtNombreManga.Text = reader["nom"].ToString();

                    }
                }
            }
        }
    }
}