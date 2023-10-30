using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestion;

namespace SistemaGestion
{


    public static class ProductoBusiness
    {
        public static List<Producto> ListarProductos()
        {
            return ProductoData.ListarProductos();
        }

        public static int CrearProducto(Producto producto)
        {
            return ProductoData.CrearProducto(producto);
        }

        public static bool ModificarProducto(Producto producto)
        {
            return ProductoData.ModificarProducto(producto);
        }

        public static bool EliminarProducto(int id)
        {
            return ProductoData.EliminarProducto(id);
        }
    }

    public static class UsuarioBusiness
    {
        public static Usuario ObtenerUsuario(int id)
        {
            return UsuarioData.ObtenerUsuario(id);
        }

        public static List<Usuario> ListarUsuarios()
        {
            return UsuarioData.ListarUsuarios();
        }

        public static int CrearUsuario(Usuario usuario)
        {
            return UsuarioData.CrearUsuario(usuario);
        }

        public static bool ModificarUsuario(Usuario usuario)
        {
            return UsuarioData.ModificarUsuario(usuario);
        }

        public static bool EliminarUsuario(int id)
        {
            return UsuarioData.EliminarUsuario(id);
        }
    }

    public static class VentaBusiness
    {
        public static Venta ObtenerVenta(int id)
        {
            return VentaData.ObtenerVenta(id);
        }

        public static List<Venta> ListarVentas()
        {
            return VentaData.ListarVentas();
        }

        public static int CrearVenta(Venta venta)
        {
            return VentaData.CrearVenta(venta);
        }

        public static bool ModificarVenta(Venta venta)
        {
            return VentaData.ModificarVenta(venta);
        }

        public static bool EliminarVenta(int id)
        {
            return VentaData.EliminarVenta(id);
        }
    }

    public static class ProductoVendidoBusiness
    {
        public static ProductoVendido ObtenerProductoVendido(int id)
        {
            return ProductoVendidoData.ObtenerProductoVendido(id);
        }

        public static List<ProductoVendido> ListarProductosVendidos()
        {
            return ProductoVendidoData.ListarProductosVendidos();
        }

        public static int CrearProductoVendido(ProductoVendido productoVendido)
        {
            return ProductoVendidoData.CrearProductoVendido(productoVendido);
        }

        public static bool ModificarProductoVendido(ProductoVendido productoVendido)
        {
            return ProductoVendidoData.ModificarProductoVendido(productoVendido);
        }

        public static bool EliminarProductoVendido(int id)
        {
            return ProductoVendidoData.EliminarProductoVendido(id);
        }
    }

}
