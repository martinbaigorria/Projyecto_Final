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
    public class ProductoController : ApiController
    {
        private string connectionString = "Martinbaigorria(aca iria mi conexion a la base)"; 

        public IEnumerable<Producto> GetProductos()
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Productos";
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Producto producto = new Producto
                        {
                            Id = (int)reader["Id"],
                        };
                        productos.Add(producto);
                    }
                }
            }

            return productos;
        }

        public Producto GetProducto(int id)
        {
            Producto producto = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Productos WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            producto = new Producto
                            {
                                Id = (int)reader["Id"],
                            };
                        }
                    }
                }
            }

            return producto;
        }

        public HttpResponseMessage PostProducto(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Productos (Nombre, Precio, ...) VALUES (@Nombre, @Precio, ...)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    command.Parameters.AddWithValue("@Precio", producto.Precio);
                    command.ExecuteNonQuery();
                }
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        public HttpResponseMessage PutProducto(int id, Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Productos SET Nombre = @Nombre, Precio = @Precio, ... WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    command.Parameters.AddWithValue("@Precio", producto.Precio);
                    command.ExecuteNonQuery();
                }
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        public HttpResponseMessage DeleteProducto(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Productos WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        public void CrearProducto(Producto producto)
        {
            if (string.IsNullOrWhiteSpace(producto.Nombre) || producto.Precio <= 0)
            {
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Productos (Nombre, Precio, ...) VALUES (@Nombre, @Precio, ...)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    command.Parameters.AddWithValue("@Precio", producto.Precio);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ModificarProducto(int id, Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Productos SET Nombre = @Nombre, Precio = @Precio, ... WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    command.Parameters.AddWithValue("@Precio", producto.Precio);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarProducto(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string deleteProductosVendidosQuery = "DELETE FROM ProductosVendidos WHERE ProductoId = @Id";
                using (SqlCommand command = new SqlCommand(deleteProductosVendidosQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }

                string deleteProductoQuery = "DELETE FROM Productos WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(deleteProductoQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }



        private ProductoService _productoService;

        // GET: api/productos
        public IHttpActionResult GetProductos()
        {
            try
            {
                var productos = _productoService.ObtenerTodosLosProductos();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult GetProducto(int id)
        {
            try
            {
                var producto = _productoService.ObtenerProductoPorId(id);

                if (producto != null)
                {
                    return Ok(producto);
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

        public IHttpActionResult PostProducto(Producto producto)
        {
            try
            {
                if (producto == null)
                {
                    return BadRequest("Los datos del producto son nulos.");
                }

                _productoService.CrearProducto(producto);
                return Created(Request.RequestUri + "/" + producto.Id, producto);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult PutProducto(int id, Producto producto)
        {
            try
            {
                if (producto == null)
                {
                    return BadRequest("Los datos del producto son nulos.");
                }

                bool actualizado = _productoService.ActualizarProducto(id, producto);

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
        public IHttpActionResult DeleteProducto(int id)
        {
            try
            {
                bool eliminado = _productoService.EliminarProducto(id);

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


    }


