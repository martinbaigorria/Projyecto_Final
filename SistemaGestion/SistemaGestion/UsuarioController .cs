using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SistemaGestion
{
    public class UsuarioController : ApiController
    {
        private string connectionString = "Martinbaigorria(aca iria mi conexion a la base)";

        public IEnumerable<Usuario> GetUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Usuarios";
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Usuario usuario = new Usuario
                        {
                            Id = (int)reader["Id"],
                            Nombre = reader["Nombre"].ToString(),
                        };
                        usuarios.Add(usuario);
                    }
                }
            }

            return usuarios;
        }

        public Usuario GetUsuario(int id)
        {
            Usuario usuario = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Usuarios WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = new Usuario
                            {
                                Id = (int)reader["Id"],
                                Nombre = reader["Nombre"].ToString(),
                                // Otros campos del usuario
                            };
                        }
                    }
                }
            }

            return usuario;
        }

        public HttpResponseMessage PostUsuario(Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Usuarios (Nombre, ...) VALUES (@Nombre, ...)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    command.ExecuteNonQuery();
                }
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        public HttpResponseMessage PutUsuario(int id, Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Usuarios SET Nombre = @Nombre, ... WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    command.ExecuteNonQuery();
                }
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        public HttpResponseMessage DeleteUsuario(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Usuarios WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
     
        }

        public void ModificarUsuario(int id, Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Usuarios SET Nombre = @Nombre, Email = @Email, ... WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    command.Parameters.AddWithValue("@Email", usuario.Email);
                    command.ExecuteNonQuery();
                }
            }
        }



        public IHttpActionResult GetUsuario(int id)
        {
            try
            {
                Usuario usuario = _usuarioService.ObtenerUsuarioPorId(id);

                if (usuario != null)
                {
                    return Ok(usuario);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult PostUsuario(Usuario usuario)
        {
            try
            {
                if (usuario == null)
                {
                    return BadRequest("Los datos del usuario son nulos.");
                }

                _usuarioService.CrearUsuario(usuario);

                return Created(Request.RequestUri + "/" + usuario.Id, usuario);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult PutUsuario(int id, Usuario usuario)
        {
            try
            {
                if (usuario == null)
                {
                    return BadRequest("Los datos del usuario son nulos.");
                }

                bool actualizado = _usuarioService.ActualizarUsuario(id, usuario);

                if (actualizado)
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
        public IHttpActionResult DeleteUsuario(int id)
        {
            try
            {
                bool eliminado = _usuarioService.EliminarUsuario(id);

                if (eliminado)
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
    }

}
