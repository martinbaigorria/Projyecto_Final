using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public abstract class Base
    {
        public int Id { get; set; }
    }

    public class Usuario : Base
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Mail { get; set; }

        public Usuario()
        {
        }

        public Usuario(int id, string nombre, string apellido, string nombreUsuario, string contraseña, string mail)
            : this()
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.NombreUsuario = nombreUsuario;
            this.Contraseña = contraseña;
            this.Mail = mail;
        }
    }




    class Programa
    {
        static void Main(string[] args)
        {
            Usuario usuario1 = new Usuario(1, "Martin", "Baigorria", "martinbaigorria", "123456789", "martinbaigorria1@gmail.com");

            // Acceder a las propiedades del objeto Usuario
            Console.WriteLine("Información del Usuario:");
            Console.WriteLine($"ID: {usuario1.Id}");
            Console.WriteLine($"Nombre: {usuario1.Nombre}");
            Console.WriteLine($"Apellido: {usuario1.Apellido}");
            Console.WriteLine($"Nombre de Usuario: {usuario1.NombreUsuario}");
            Console.WriteLine($"Contraseña: {usuario1.Contraseña}");
            Console.WriteLine($"Correo Electrónico: {usuario1.Mail}");
        }
    }







    public class Producto : Base
    {
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }

        public Producto()
        {
        }

        public Producto(int id, string descripcion, decimal costo, decimal precioVenta, int stock, int idUsuario)
            : this()
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.Costo = costo;
            this.PrecioVenta = precioVenta;
            this.Stock = stock;
            this.IdUsuario = idUsuario;
        }
    }

    public class ProductoVendido : Base
    {
        public int IdProducto { get; set; }
        public int Stock { get; set; }
        public int IdVenta { get; set; }

        public ProductoVendido()
        {
        }

        public ProductoVendido(int id, int idProducto, int stock, int idVenta)
            : this()
        {
            this.Id = id;
            this.IdProducto = idProducto;
            this.Stock = stock;
            this.IdVenta = idVenta;
        }
    }

    public class Venta : Base
    {
        public string Comentarios { get; set; }
        public int IdUsuario { get; set; }

        public Venta()
        {
        }

        public Venta(int id, string comentarios, int idUsuario)
            : this()
        {
            this.Id = id;
            this.Comentarios = comentarios;
            this.IdUsuario = idUsuario;
        }
    }
}