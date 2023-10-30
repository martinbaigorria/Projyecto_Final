using Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Desafio
{
    public static class VentaData
    {
        private static string CadenaConexion = "Martinbaigorria(aca iria mi conexion a la base)";

        public static Venta ObtenerVenta(int id)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(CadenaConexion))
                {
                    conexion.Open();
                    string consulta = "SELECT * FROM Ventas WHERE Id = @Id";
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@Id", id);
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                return new Venta
                                {
                                    Id = (int)lector["Id"],
                                    Fecha = (DateTime)lector["Fecha"],
                                    MontoTotal = (decimal)lector["MontoTotal"]
                                };
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en ObtenerVenta: " + ex.Message);
                return null;
            }
        }

        public static List<Venta> ListarVentas()
        {
            List<Venta> ventas = new List<Venta>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(CadenaConexion))
                {
                    conexion.Open();
                    string consulta = "SELECT * FROM Ventas";
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                ventas.Add(new Venta
                                {
                                    Id = (int)lector["Id"],
                                    Fecha = (DateTime)lector["Fecha"],
                                    MontoTotal = (decimal)lector["MontoTotal"]
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en ListarVentas: " + ex.Message);
            }
            return ventas;
        }

        public static int CrearVenta(Venta venta)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(CadenaConexion))
                {
                    conexion.Open();
                    string consulta = "INSERT INTO Ventas (Fecha, MontoTotal) " +
                        "VALUES (@Fecha, @MontoTotal); " +
                        "SELECT SCOPE_IDENTITY()";
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@Fecha", venta.Fecha);
                        comando.Parameters.AddWithValue("@MontoTotal", venta.MontoTotal);

                        return Convert.ToInt32(comando.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CrearVenta: " + ex.Message);
                return -1; 
            }
        }

        public static bool ModificarVenta(Venta venta)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(CadenaConexion))
                {
                    conexion.Open();
                    string consulta = "UPDATE Ventas SET Fecha = @Fecha, MontoTotal = @MontoTotal " +
                        "WHERE Id = @Id";
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@Id", venta.Id);
                        comando.Parameters.AddWithValue("@Fecha", venta.Fecha);
                        comando.Parameters.AddWithValue("@MontoTotal", venta.MontoTotal);

                        int filasAfectadas = comando.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en ModificarVenta: " + ex.Message);
                return false; 
            }
        }

        public static bool EliminarVenta(int id)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(CadenaConexion))
                {
                    conexion.Open();
                    string consulta = "DELETE FROM Ventas WHERE Id = @Id";
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
                Console.WriteLine("Error en EliminarVenta: " + ex.Message);
                return false; 
            }
        }
    }
}
