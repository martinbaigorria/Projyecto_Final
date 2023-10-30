using Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace Desafio
{
    public static class UsuarioData
    {
        private static string CadenaConexion = "Martinbaigorria(aca iria mi conexion a la base)";

        public static Usuario ObtenerUsuario(int id)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(CadenaConexion))
                {
                    conexion.Open();
                    string consulta = "SELECT * FROM Usuarios WHERE Id = @Id";
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@Id", id);
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                return new Usuario
                                {
                                    Id = (int)lector["Id"],
                                    Nombre = lector["Nombre"].ToString(),
                                    Apellido = lector["Apellido"].ToString(),
                                    NombreUsuario = lector["NombreUsuario"].ToString(),
                                    Contraseña = lector["Contraseña"].ToString(),
                                    Mail = lector["Mail"].ToString()
                                };
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en ObtenerUsuario: " + ex.Message);
                return null;
            }
        }

        public static List<Usuario> ListarUsuarios()
        {
            try
            {
                List<Usuario> usuarios = new List<Usuario>();
                using (SqlConnection conexion = new SqlConnection(CadenaConexion))
                {
                    conexion.Open();
                    string consulta = "SELECT * FROM Usuarios";
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                usuarios.Add(new Usuario
                                {
                                    Id = (int)lector["Id"],
                                    Nombre = lector["Nombre"].ToString(),
                                    Apellido = lector["Apellido"].ToString(),
                                    NombreUsuario = lector["NombreUsuario"].ToString(),
                                    Contraseña = lector["Contraseña"].ToString(),
                                    Mail = lector["Mail"].ToString()
                                });
                            }
                        }
                    }
                }
                return usuarios;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en ListarUsuarios: " + ex.Message);
                return null;
            }
        }

        public static int CrearUsuario(Usuario usuario)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(CadenaConexion))
                {
                    conexion.Open();
                    string consulta = "INSERT INTO Usuarios (Nombre, Apellido, NombreUsuario, Contraseña, Mail) " +
                        "VALUES (@Nombre, @Apellido, @NombreUsuario, @Contraseña, @Mail); " +
                        "SELECT SCOPE_IDENTITY()";
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        comando.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                        comando.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                        comando.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                        comando.Parameters.AddWithValue("@Mail", usuario.Mail);

                        return Convert.ToInt32(comando.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CrearUsuario: " + ex.Message);
                return 0;
            }
        }

        public static bool ModificarUsuario(Usuario usuario)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(CadenaConexion))
                {
                    conexion.Open();
                    string consulta = "UPDATE Usuarios SET Nombre = @Nombre, Apellido = @Apellido, " +
                        "NombreUsuario = @NombreUsuario, Contraseña = @Contraseña, Mail = @Mail WHERE Id = @Id";
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@Id", usuario.Id);
                        comando.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        comando.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                        comando.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                        comando.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                        comando.Parameters.AddWithValue("@Mail", usuario.Mail);

                        int filasAfectadas = comando.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en ModificarUsuario: " + ex.Message);
                return false;
            }
        }

        public static bool EliminarUsuario(int id)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(CadenaConexion))
                {
                    conexion.Open();
                    string consulta = "DELETE FROM Usuarios WHERE Id = @Id";
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@Id", id);

                        int filasAfectadas = comando.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en EliminarUsuario: " + ex.Message);
                return false;
            }
        }
    }
}
