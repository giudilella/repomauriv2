using System;

class Program
{
    static void Main()
    {
        var tienda = new Tienda();
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Ver categorías");
            Console.WriteLine("2. Ver todos productos");
            Console.WriteLine("3. Ver productos por categoría");
            Console.WriteLine("4. Agregar producto al carrito (PILI)");
            Console.WriteLine("5. Eliminar producto del carrito");
            Console.WriteLine("6. Ver contenido del carrito (PILI)");
            Console.WriteLine("7. Ver total a pagar");
            Console.WriteLine("8. Finalizar compra (PILI)");
            Console.WriteLine("0. Salir");
            Console.Write("Opción: ");
            var op = Console.ReadLine();

            switch (op)
            {
                case "1":
                    tienda.MostrarCategorias();
                    break;
                case "2":
                    tienda.MostrarProductos();
                    break;
                case "3":
                    Console.Write("Nombre categoría: ");
                    tienda.MostrarPorCategoria(Console.ReadLine());
                    break;
                case "4":
                    Console.Write("Código producto: ");
                    int cod = int.Parse(Console.ReadLine());
                    Console.Write("Cantidad: ");
                    int cant = int.Parse(Console.ReadLine());
                    var prod = tienda.Productos.Find(p => p.Codigo == cod);
                    Console.WriteLine(prod != null ? tienda.Carrito.AgregarProducto(prod, cant)
                                                   : "Producto no existe.");
                    break;
                case "5":
                    Console.Write("Código a eliminar: ");
                    int cod2 = int.Parse(Console.ReadLine());
                    Console.WriteLine(tienda.Carrito.EliminarProducto(cod2));
                    break;
                case "6":
                    tienda.Carrito.VerCarrito();
                    break;
                case "7":
                    Console.WriteLine($"Total a pagar (21% IVA): ${tienda.Carrito.TotalPagar():F2}");
                    break;
                case "8":
                    tienda.Carrito.FinalizarCompra();
                    break;
                case "0":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }
}
