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
    public class ProductoVendidoController : ApiController
    {
        private string connectionString = "Martinbaigorria(aca iria mi conexion a la base)";

        public IEnumerable<ProductoVendido> GetProductosVendidos()
        {
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM ProductosVendidos";
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProductoVendido productoVendido = new ProductoVendido
                        {
                            Id = (int)reader["Id"],
                        };
                        productosVendidos.Add(productoVendido);
                    }
                }
            }

            return productosVendidos;
        }

        public ProductoVendido GetProductoVendido(int id)
        {
            ProductoVendido productoVendido = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM ProductosVendidos WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            productoVendido = new ProductoVendido
                            {
                                Id = (int)reader["Id"],
                            };
                        }
                    }
                }
            }

            return productoVendido;
        }

        public HttpResponseMessage PostProductoVendido(ProductoVendido productoVendido)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO ProductosVendidos (ProductoId, VentaId, Cantidad, ...) VALUES (@ProductoId, @VentaId, ...)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductoId", productoVendido.ProductoId);
                    command.Parameters.AddWithValue("@VentaId", productoVendido.VentaId);
                    command.Parameters.AddWithValue("@Cantidad", productoVendido.Cantidad);
                    command.ExecuteNonQuery();
                }
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        public HttpResponseMessage PutProductoVendido(int id, ProductoVendido productoVendido)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE ProductosVendidos SET ProductoId = @ProductoId, VentaId = @VentaId, Cantidad = @Cantidad, ... WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@ProductoId", productoVendido.ProductoId);
                    command.Parameters.AddWithValue("@VentaId", productoVendido.VentaId);
                    command.Parameters.AddWithValue("@Cantidad", productoVendido.Cantidad);
                    command.ExecuteNonQuery();
                }
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        public HttpResponseMessage DeleteProductoVendido(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM ProductosVendidos WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }


      
            private ProductoVendidoService _productoVendidoService; 

            // GET: api/productosvendidos
            public IHttpActionResult GetProductosVendidos()
            {
                try
                {
                    var productosVendidos = _productoVendidoService.ObtenerTodosLosProductosVendidos();
                    return Ok(productosVendidos);
                }
                catch (Exception ex)
                {
                    return InternalServerError();
                }
            }

            public IHttpActionResult GetProductoVendido(int id)
            {
                try
                {
                    var productoVendido = _productoVendidoService.ObtenerProductoVendidoPorId(id);

                    if (productoVendido != null)
                    {
                        return Ok(productoVendido);
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

            public IHttpActionResult PostProductoVendido(ProductoVendido productoVendido)
            {
                try
                {
                    if (productoVendido == null)
                    {
                        return BadRequest("Los datos del producto vendido son nulos.");
                    }

                    _productoVendidoService.CrearProductoVendido(productoVendido);
                    return Created(Request.RequestUri + "/" + productoVendido.Id, productoVendido);
                }
                catch (Exception ex)
                {
                    return InternalServerError();
                }
            }

            public IHttpActionResult PutProductoVendido(int id, ProductoVendido productoVendido)
            {
                try
                {
                    if (productoVendido == null)
                    {
                        return BadRequest("Los datos del producto vendido son nulos.");
                    }

                    bool actualizado = _productoVendidoService.ActualizarProductoVendido(id, productoVendido);

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

            public IHttpActionResult DeleteProductoVendido(int id)
            {
                try
                {
                    bool eliminado = _productoVendidoService.EliminarProductoVendido(id);

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
