using SistemaGestion;
using System;
using System.Collections.Generic;

namespace SistemaGestionUI
{
    class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("Sistema de Gestión de Usuarios");
                Console.WriteLine("1. Listar Usuarios");
                Console.WriteLine("2. Agregar Usuario");
                Console.WriteLine("3. Modificar Usuario");
                Console.WriteLine("4. Eliminar Usuario");
                Console.WriteLine("5. Salir");
                Console.Write("Selecciona una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ListarUsuarios();
                        break;
                    case "2":
                        AgregarUsuario();
                        break;
                    case "3":
                        ModificarUsuario();
                        break;
                    case "4":
                        EliminarUsuario();
                        break;
                    case "5":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Introduce una opción válida.");
                        break;
                }
            }
        }

        static void ListarUsuarios()
        {
            Console.WriteLine("Listado de Usuarios:");

            // Llama al método de negocio para obtener la lista de usuarios
            List<Usuario> usuarios = UsuarioBusiness.ListarUsuarios();

            if (usuarios != null && usuarios.Count > 0)
            {
                foreach (var usuario in usuarios)
                {
                    Console.WriteLine($"ID: {usuario.Id}, Nombre: {usuario.Nombre}, Apellido: {usuario.Apellido}");
                }
            }
            else
            {
                Console.WriteLine("No hay usuarios registrados.");
            }
        }

        static void AgregarUsuario()
        {
            Console.WriteLine("Agregar Usuario:");

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();

            // Crea un nuevo objeto Usuario con los datos ingresados
            Usuario nuevoUsuario = new Usuario
            {
                Nombre = nombre,
                Apellido = apellido
            };

            // Llama al método de negocio para agregar el usuario
            int resultado = UsuarioBusiness.AgregarUsuario(nuevoUsuario);

            if (resultado > 0)
            {
                Console.WriteLine($"Usuario agregado con éxito. ID: {resultado}");
            }
            else
            {
                Console.WriteLine("Error al agregar el usuario.");
            }
        }

        static void ModificarUsuario()
        {
            Console.WriteLine("Modificar Usuario:");

            Console.Write("ID del Usuario a Modificar: ");
            if (int.TryParse(Console.ReadLine(), out int idUsuario))
            {
                // Llama al método de negocio para obtener el usuario por su ID
                Usuario usuarioExistente = UsuarioBusiness.ObtenerUsuarioPorId(idUsuario);

                if (usuarioExistente != null)
                {
                    Console.Write("Nuevo Nombre: ");
                    string nuevoNombre = Console.ReadLine();

                    Console.Write("Nuevo Apellido: ");
                    string nuevoApellido = Console.ReadLine();

                    // Actualiza el objeto Usuario con los nuevos datos
                    usuarioExistente.Nombre = nuevoNombre;
                    usuarioExistente.Apellido = nuevoApellido;

                    // Llama al método de negocio para modificar el usuario
                    if (UsuarioBusiness.ModificarUsuario(usuarioExistente))
                    {
                        Console.WriteLine("Usuario modificado con éxito.");
                    }
                    else
                    {
                        Console.WriteLine("Error al modificar el usuario.");
                    }
                }
                else
                {
                    Console.WriteLine("No se encontró un usuario con el ID especificado.");
                }
            }
            else
            {
                Console.WriteLine("ID de usuario no válido.");
            }
        }

        static void EliminarUsuario()
        {
            Console.WriteLine("Eliminar Usuario:");

            Console.Write("ID del Usuario a Eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int idUsuario))
            {
                // Llama al método de negocio para eliminar el usuario por su ID
                if (UsuarioBusiness.EliminarUsuario(idUsuario))
                {
                    Console.WriteLine("Usuario eliminado con éxito.");
                }
                else
                {
                    Console.WriteLine("Error al eliminar el usuario.");
                }
            }
            else
            {
                Console.WriteLine("ID de usuario no válido.");
            }
        }
    }

        class Produto
        {
            static void Main(string[] args)
            {
                bool salir = false;

                while (!salir)
                {
                    Console.WriteLine("Sistema de Gestión de Productos");
                    Console.WriteLine("1. Listar Productos");
                    Console.WriteLine("2. Agregar Producto");
                    Console.WriteLine("3. Modificar Producto");
                    Console.WriteLine("4. Eliminar Producto");
                    Console.WriteLine("5. Salir");
                    Console.Write("Selecciona una opción: ");
                    string opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            ListarProductos();
                            break;
                        case "2":
                            AgregarProducto();
                            break;
                        case "3":
                            ModificarProducto();
                            break;
                        case "4":
                            EliminarProducto();
                            break;
                        case "5":
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Introduce una opción válida.");
                            break;
                    }
                }
            }

            static void ListarProductos()
            {
                Console.WriteLine("Listado de Productos:");

                // Llama al método de negocio para obtener la lista de productos
                List<Producto> productos = ProductoBusiness.ListarProductos();

                if (productos != null && productos.Count > 0)
                {
                    foreach (var producto in productos)
                    {
                        Console.WriteLine($"ID: {producto.Id}, Nombre: {producto.Nombre}, Precio: {producto.Precio}");
                    }
                }
                else
                {
                    Console.WriteLine("No hay productos registrados.");
                }
            }

            static void AgregarProducto()
            {
                Console.WriteLine("Agregar Producto:");

                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();

                Console.Write("Precio: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal precio))
                {
                    // Crea un nuevo objeto Producto con los datos ingresados
                    Producto nuevoProducto = new Producto
                    {
                        Nombre = nombre,
                        Precio = precio
                    };

                    // Llama al método de negocio para agregar el producto
                    int resultado = ProductoBusiness.AgregarProducto(nuevoProducto);

                    if (resultado > 0)
                    {
                        Console.WriteLine($"Producto agregado con éxito. ID: {resultado}");
                    }
                    else
                    {
                        Console.WriteLine("Error al agregar el producto.");
                    }
                }
                else
                {
                    Console.WriteLine("Precio no válido. Introduce un número válido.");
                }
            }

            static void ModificarProducto()
            {
                Console.WriteLine("Modificar Producto:");

                Console.Write("ID del Producto a Modificar: ");
                if (int.TryParse(Console.ReadLine(), out int idProducto))
                {
                    // Llama al método de negocio para obtener el producto por su ID
                    Producto productoExistente = ProductoBusiness.ObtenerProductoPorId(idProducto);

                    if (productoExistente != null)
                    {
                        Console.Write("Nuevo Nombre: ");
                        string nuevoNombre = Console.ReadLine();

                        Console.Write("Nuevo Precio: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal nuevoPrecio))
                        {
                            // Actualiza el objeto Producto con los nuevos datos
                            productoExistente.Nombre = nuevoNombre;
                            productoExistente.Precio = nuevoPrecio;

                            // Llama al método de negocio para modificar el producto
                            if (ProductoBusiness.ModificarProducto(productoExistente))
                            {
                                Console.WriteLine("Producto modificado con éxito.");
                            }
                            else
                            {
                                Console.WriteLine("Error al modificar el producto.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Precio no válido. Introduce un número válido.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se encontró un producto con el ID especificado.");
                    }
                }
                else
                {
                    Console.WriteLine("ID de producto no válido.");
                }
            }

            static void EliminarProducto()
            {
                Console.WriteLine("Eliminar Producto:");

                Console.Write("ID del Producto a Eliminar: ");
                if (int.TryParse(Console.ReadLine(), out int idProducto))
                {
                    // Llama al método de negocio para eliminar el producto por su ID
                    if (ProductoBusiness.EliminarProducto(idProducto))
                    {
                        Console.WriteLine("Producto eliminado con éxito.");
                    }
                    else
                    {
                        Console.WriteLine("Error al eliminar el producto.");
                    }
                }
                else
                {
                    Console.WriteLine("ID de producto no válido.");
                }
            }
    }


 
        class Venta
        {
            static void Main(string[] args)
            {
                bool salir = false;

                while (!salir)
                {
                    Console.WriteLine("Sistema de Gestión de Ventas");
                    Console.WriteLine("1. Listar Ventas");
                    Console.WriteLine("2. Agregar Venta");
                    Console.WriteLine("3. Modificar Venta");
                    Console.WriteLine("4. Eliminar Venta");
                    Console.WriteLine("5. Salir");
                    Console.Write("Selecciona una opción: ");
                    string opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            ListarVentas();
                            break;
                        case "2":
                            AgregarVenta();
                            break;
                        case "3":
                            ModificarVenta();
                            break;
                        case "4":
                            EliminarVenta();
                            break;
                        case "5":
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Introduce una opción válida.");
                            break;
                    }
                }
            }

            static void ListarVentas()
            {
                Console.WriteLine("Listado de Ventas:");

                // Llama al método de negocio para obtener la lista de ventas
                List<Venta> ventas = VentaBusiness.ListarVentas();

                if (ventas != null && ventas.Count > 0)
                {
                    foreach (var venta in ventas)
                    {
                        Console.WriteLine($"ID: {venta.Id}, Fecha: {venta.Fecha}, Monto Total: {venta.MontoTotal}");
                    }
                }
                else
                {
                    Console.WriteLine("No hay ventas registradas.");
                }
            }

            static void AgregarVenta()
            {
                Console.WriteLine("Agregar Venta:");

                Console.Write("Fecha (YYYY-MM-DD): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime fecha))
                {
                    // Crea un nuevo objeto Venta con los datos ingresados
                    Venta nuevaVenta = new Venta
                    {
                        Fecha = fecha
                    };

                    // Llama al método de negocio para agregar la venta
                    int resultado = VentaBusiness.AgregarVenta(nuevaVenta);

                    if (resultado > 0)
                    {
                        Console.WriteLine($"Venta agregada con éxito. ID: {resultado}");
                    }
                    else
                    {
                        Console.WriteLine("Error al agregar la venta.");
                    }
                }
                else
                {
                    Console.WriteLine("Fecha no válida. Introduce una fecha válida en formato YYYY-MM-DD.");
                }
            }

            static void ModificarVenta()
            {
                Console.WriteLine("Modificar Venta:");

                Console.Write("ID de la Venta a Modificar: ");
                if (int.TryParse(Console.ReadLine(), out int idVenta))
                {
                    // Llama al método de negocio para obtener la venta por su ID
                    Venta ventaExistente = VentaBusiness.ObtenerVentaPorId(idVenta);

                    if (ventaExistente != null)
                    {
                        Console.Write("Nueva Fecha (YYYY-MM-DD): ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime nuevaFecha))
                        {
                            // Actualiza el objeto Venta con la nueva fecha
                            ventaExistente.Fecha = nuevaFecha;

                            // Llama al método de negocio para modificar la venta
                            if (VentaBusiness.ModificarVenta(ventaExistente))
                            {
                                Console.WriteLine("Venta modificada con éxito.");
                            }
                            else
                            {
                                Console.WriteLine("Error al modificar la venta.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Fecha no válida. Introduce una fecha válida en formato YYYY-MM-DD.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se encontró una venta con el ID especificado.");
                    }
                }
                else
                {
                    Console.WriteLine("ID de venta no válido.");
                }
            }

            static void EliminarVenta()
            {
                Console.WriteLine("Eliminar Venta:");

                Console.Write("ID de la Venta a Eliminar: ");
                if (int.TryParse(Console.ReadLine(), out int idVenta))
                {
                    // Llama al método de negocio para eliminar la venta por su ID
                    if (VentaBusiness.EliminarVenta(idVenta))
                    {
                        Console.WriteLine("Venta eliminada con éxito.");
                    }
                    else
                    {
                        Console.WriteLine("Error al eliminar la venta.");
                    }
                }
                else
                {
                    Console.WriteLine("ID de venta no válido.");
                }
            }
    }

        class ProductosVenta
        {
            static void Main(string[] args)
            {
                bool salir = false;

                while (!salir)
                {
                    Console.WriteLine("Sistema de Gestión de Ventas");
                    Console.WriteLine("1. Listar Productos de una Venta");
                    Console.WriteLine("2. Agregar Producto a una Venta");
                    Console.WriteLine("3. Quitar Producto de una Venta");
                    Console.WriteLine("4. Modificar Producto de una Venta");
                    Console.WriteLine("5. Salir");
                    Console.Write("Selecciona una opción: ");
                    string opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            ListarProductosDeVenta();
                            break;
                        case "2":
                            AgregarProductoAVenta();
                            break;
                        case "3":
                            QuitarProductoDeVenta();
                            break;
                        case "4":
                            ModificarProductoDeVenta();
                            break;
                        case "5":
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Introduce una opción válida.");
                            break;
                    }
                }
            }

            static void ListarProductosDeVenta()
            {
                Console.WriteLine("Listado de Productos de una Venta:");

                Console.Write("ID de la Venta: ");
                if (int.TryParse(Console.ReadLine(), out int idVenta))
                {
                    // Llama al método de negocio para obtener los detalles de la venta
                    List<DetalleVenta> detalles = VentaBusiness.ListarDetallesDeVenta(idVenta);

                    if (detalles != null && detalles.Count > 0)
                    {
                        Console.WriteLine($"Productos de la Venta {idVenta}:");
                        foreach (var detalle in detalles)
                        {
                            Console.WriteLine($"Producto ID: {detalle.Producto.Id}, Nombre: {detalle.Producto.Nombre}, Cantidad: {detalle.Cantidad}, Precio Unitario: {detalle.Producto.Precio}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No hay productos registrados para la Venta {idVenta}.");
                    }
                }
                else
                {
                    Console.WriteLine("ID de venta no válido.");
                }
            }

            static void AgregarProductoAVenta()
            {
                Console.WriteLine("Agregar Producto a una Venta:");

                Console.Write("ID de la Venta: ");
                if (int.TryParse(Console.ReadLine(), out int idVenta))
                {
                    // Llama al método de negocio para obtener la venta por su ID
                    Venta venta = VentaBusiness.ObtenerVentaPorId(idVenta);

                    if (venta != null)
                    {
                        Console.Write("ID del Producto: ");
                        if (int.TryParse(Console.ReadLine(), out int idProducto))
                        {
                            // Llama al método de negocio para obtener el producto por su ID
                            Producto producto = ProductoBusiness.ObtenerProductoPorId(idProducto);

                            if (producto != null)
                            {
                                Console.Write("Cantidad: ");
                                if (int.TryParse(Console.ReadLine(), out int cantidad) && cantidad > 0)
                                {
                                    // Crea un nuevo detalle de venta con los datos ingresados
                                    DetalleVenta detalle = new DetalleVenta
                                    {
                                        Producto = producto,
                                        Cantidad = cantidad
                                    };

                                    // Llama al método de negocio para agregar el producto a la venta
                                    if (VentaBusiness.AgregarProductoAVenta(venta, detalle))
                                    {
                                        Console.WriteLine("Producto agregado a la venta con éxito.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error al agregar el producto a la venta.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Cantidad no válida. Introduce un valor entero positivo.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No se encontró un producto con el ID especificado.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("ID de producto no válido.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se encontró una venta con el ID especificado.");
                    }
                }
                else
                {
                    Console.WriteLine("ID de venta no válido.");
                }
            }

            static void QuitarProductoDeVenta()
            {
                Console.WriteLine("Quitar Producto de una Venta:");

                Console.Write("ID de la Venta: ");
                if (int.TryParse(Console.ReadLine(), out int idVenta))
                {
                    // Llama al método de negocio para obtener la venta por su ID
                    Venta venta = VentaBusiness.ObtenerVentaPorId(idVenta);

                    if (venta != null)
                    {
                        Console.Write("ID del Producto: ");
                        if (int.TryParse(Console.ReadLine(), out int idProducto))
                        {
                            // Llama al método de negocio para quitar el producto de la venta
                            if (VentaBusiness.QuitarProductoDeVenta(venta, idProducto))
                            {
                                Console.WriteLine("Producto quitado de la venta con éxito.");
                            }
                            else
                            {
                                Console.WriteLine("Error al quitar el producto de la venta.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("ID de producto no válido.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se encontró una venta con el ID especificado.");
                    }
                }
                else
                {
                    Console.WriteLine("ID de venta no válido.");
                }
            }

            static void ModificarProductoDeVenta()
            {
                Console.WriteLine("Modificar Producto de una Venta:");

                Console.Write("ID de la Venta: ");
                if (int.TryParse(Console.ReadLine(), out int idVenta))
                {
                    // Llama al método de negocio para obtener la venta por su ID
                    Venta venta = VentaBusiness.ObtenerVentaPorId(idVenta);

                    if (venta != null)
                    {
                        Console.Write("ID del Producto: ");
                        if (int.TryParse(Console.ReadLine(), out int idProducto))
                        {
                            // Llama al método de negocio para obtener el detalle de venta por el ID del producto
                            DetalleVenta detalleExistente = VentaBusiness.ObtenerDetalleDeVenta(venta, idProducto);

                            if (detalleExistente != null)
                            {
                                Console.Write("Nueva Cantidad: ");
                                if (int.TryParse(Console.ReadLine(), out int nuevaCantidad) && nuevaCantidad > 0)
                                {
                                    // Actualiza la cantidad del detalle de venta con la nueva cantidad
                                    detalleExistente.Cantidad = nuevaCantidad;

                                    // Llama al método de negocio para modificar el detalle de venta
                                    if (VentaBusiness.ModificarDetalleDeVenta(venta, detalleExistente))
                                    {
                                        Console.WriteLine("Producto de la venta modificado con éxito.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error al modificar el producto de la venta.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Cantidad no válida. Introduce un valor entero positivo.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No se encontró un producto con el ID especificado en la venta.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("ID de producto no válido.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se encontró una venta con el ID especificado.");
                    }
                }
                else
                {
                    Console.WriteLine("ID de venta no válido.");
                }
            }
        }
    }






