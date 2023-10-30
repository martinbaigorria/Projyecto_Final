using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base;
using System.Data;
using System.Data.SqlClient;




    namespace SistemaGestion
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




        public static class ProductoVendidoData
        {
            private static string CadenaConexion = "Martinbaigorria(aca iria mi conexion a la base)";

            public static ProductoVendido ObtenerProductoVendido(int id)
            {
                try
                {
                    using (SqlConnection conexion = new SqlConnection(CadenaConexion))
                    {
                        conexion.Open();
                        string consulta = "SELECT * FROM ProductosVendidos WHERE Id = @Id";
                        using (SqlCommand comando = new SqlCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@Id", id);
                            using (SqlDataReader lector = comando.ExecuteReader())
                            {
                                if (lector.Read())
                                {
                                    return new ProductoVendido
                                    {
                                        Id = (int)lector["Id"],
                                        Nombre = lector["Nombre"].ToString(),
                                        Precio = (decimal)lector["Precio"]
                                    };
                                }
                                return null;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en ObtenerProductoVendido: " + ex.Message);
                    return null;
                }
            }

            public static List<ProductoVendido> ListarProductosVendidos()
            {
                List<ProductoVendido> productosVendidos = new List<ProductoVendido>();
                try
                {
                    using (SqlConnection conexion = new SqlConnection(CadenaConexion))
                    {
                        conexion.Open();
                        string consulta = "SELECT * FROM ProductosVendidos";
                        using (SqlCommand comando = new SqlCommand(consulta, conexion))
                        {
                            using (SqlDataReader lector = comando.ExecuteReader())
                            {
                                while (lector.Read())
                                {
                                    productosVendidos.Add(new ProductoVendido
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
                    Console.WriteLine("Error en ListarProductosVendidos: " + ex.Message);
                }
                return productosVendidos;
            }

            public static int CrearProductoVendido(ProductoVendido productoVendido)
            {
                try
                {
                    using (SqlConnection conexion = new SqlConnection(CadenaConexion))
                    {
                        conexion.Open();
                        string consulta = "INSERT INTO ProductosVendidos (Nombre, Precio) " +
                            "VALUES (@Nombre, @Precio); " +
                            "SELECT SCOPE_IDENTITY()";
                        using (SqlCommand comando = new SqlCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@Nombre", productoVendido.Nombre);
                            comando.Parameters.AddWithValue("@Precio", productoVendido.Precio);

                            return Convert.ToInt32(comando.ExecuteScalar());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en CrearProductoVendido: " + ex.Message);
                    return -1;
                }
            }

            public static bool ModificarProductoVendido(ProductoVendido productoVendido)
            {
                try
                {
                    using (SqlConnection conexion = new SqlConnection(CadenaConexion))
                    {
                        conexion.Open();
                        string consulta = "UPDATE ProductosVendidos SET Nombre = @Nombre, Precio = @Precio " +
                            "WHERE Id = @Id";
                        using (SqlCommand comando = new SqlCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@Id", productoVendido.Id);
                            comando.Parameters.AddWithValue("@Nombre", productoVendido.Nombre);
                            comando.Parameters.AddWithValue("@Precio", productoVendido.Precio);

                            int filasAfectadas = comando.ExecuteNonQuery();
                            return filasAfectadas > 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en ModificarProductoVendido: " + ex.Message);
                    return false;
                }
            }

            public static bool EliminarProductoVendido(int id)
            {
                try
                {
                    using (SqlConnection conexion = new SqlConnection(CadenaConexion))
                    {
                        conexion.Open();
                        string consulta = "DELETE FROM ProductosVendidos WHERE Id = @Id";
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
                    Console.WriteLine("Error en EliminarProductoVendido: " + ex.Message);
                    return false;
                }
            }
        }
    }


public static class VentaData
{
    private static string CadenaConexion = "Martinbaigorria(aca iria mi conexion a la base)";

    public static Venta ObtenerVenta(int id)
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

    public static List<Venta> ListarVentas()
    {
        List<Venta> ventas = new List<Venta>();
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
        return ventas;
    }

    public static int CrearVenta(Venta venta)
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

    public static bool ModificarVenta(Venta venta)
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

    public static bool EliminarVenta(int id)
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




