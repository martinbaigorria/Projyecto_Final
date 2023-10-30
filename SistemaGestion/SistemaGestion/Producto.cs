using Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Desafio
    {
        public static class ProductoData
        {
        private static string CadenaConexion = "Martinbaigorria(aca iria mi conexion a la base)";

        public static List<Producto> ListarProductos()
            {
                List<Producto> productos = new List<Producto>();
                try
                {
                    using (SqlConnection conexion = new SqlConnection(CadenaConexion))
                    {
                        conexion.Open();
                        string consulta = "SELECT * FROM Productos";
                        using (SqlCommand comando = new SqlCommand(consulta, conexion))
                        {
                            using (SqlDataReader lector = comando.ExecuteReader())
                            {
                                while (lector.Read())
                                {
                                    productos.Add(new Producto
                                    {
                                        Id = (int)lector["Id"],
                                        Nombre = lector["Nombre"].ToString(),
                                        Precio = (decimal)lector["Precio"]
                                    });
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en ListarProductos: " + ex.Message);
                }

                return productos;
            }

            public static int CrearProducto(Producto producto)
            {
                try
                {
                    using (SqlConnection conexion = new SqlConnection(CadenaConexion))
                    {
                        conexion.Open();
                        string consulta = "INSERT INTO Productos (Nombre, Precio) " +
                            "VALUES (@Nombre, @Precio); " +
                            "SELECT SCOPE_IDENTITY()";
                        using (SqlCommand comando = new SqlCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                            comando.Parameters.AddWithValue("@Precio", producto.Precio);

                            return Convert.ToInt32(comando.ExecuteScalar());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en CrearProducto: " + ex.Message);
                    return -1; 
                }
            }

            public static bool ModificarProducto(Producto producto)
            {
                try
                {
                    using (SqlConnection conexion = new SqlConnection(CadenaConexion))
                    {
                        conexion.Open();
                        string consulta = "UPDATE Productos SET Nombre = @Nombre, Precio = @Precio " +
                            "WHERE Id = @Id";
                        using (SqlCommand comando = new SqlCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@Id", producto.Id);
                            comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                            comando.Parameters.AddWithValue("@Precio", producto.Precio);

                            int filasAfectadas = comando.ExecuteNonQuery();
                            return filasAfectadas > 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en ModificarProducto: " + ex.Message);
                    return false;
                }
            }

            public static bool EliminarProducto(int id)
            {
                try
                {
                    using (SqlConnection conexion = new SqlConnection(CadenaConexion))
                    {
                        conexion.Open();
                        string consulta = "DELETE FROM Productos WHERE Id = @Id";
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
                    Console.WriteLine("Error en EliminarProducto: " + ex.Message);
                    return false; 
                }
            }
        }
    }
