using System;

class Program{
    static void Main(){
        var tienda = new Tienda();
        bool salir = false;

        while (!salir){
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Ver categorías");
            Console.WriteLine("2. Ver todos productos");
            Console.WriteLine("3. Ver productos por categoría");
            Console.WriteLine("4. Agregar producto al carrito (PILI)");
            Console.WriteLine("5. Eliminar producto del carrito");
            Console.WriteLine("6. Ver contenido del carrito (PILI)");
            Console.WriteLine("7. Ver total a pagar");
            Console.WriteLine("8. Finalizar compra (PILI)");
            Console.WriteLine("9. Ver historial de compras");
            Console.WriteLine("10. Ver detalle de un ticket");
            Console.WriteLine("0. Salir");
            Console.Write("Opción: ");
            var op = Console.ReadLine();

            if (op == "1")
                tienda.MostrarCategorias();
            else if (op == "2")
                tienda.MostrarProductos();
            else if (op == "3"){
                Console.Write("Nombre categoría: ");
                tienda.MostrarPorCategoria(Console.ReadLine());
            }
            else if (op == "4"){
                Console.Write("Código producto: ");
                int cod = int.Parse(Console.ReadLine());
                Console.Write("Cantidad: ");
                int cant = int.Parse(Console.ReadLine());
                var prod = tienda.Productos.Find(p => p.Codigo == cod);
                if (prod != null){
                    Console.WriteLine(tienda.Carrito.AgregarProducto(prod, cant));
                }
                else{
                    Console.WriteLine("Producto no existe.");
                }
            }
            else if (op == "5"){
                try
                {
                    Console.Write("Código a eliminar: ");
                    int cod2 = int.Parse(Console.ReadLine());
                    Console.Write("Cantidad a eliminar: ");
                    int cantEliminar = int.Parse(Console.ReadLine());
                    Console.WriteLine(tienda.Carrito.EliminarProducto(cod2, cantEliminar));
                }
                catch (FormatException){
                    Console.WriteLine("Entrada inválida. Ingrese números válidos.");
                }
            }
            else if (op == "6")
                tienda.Carrito.VerCarrito();
            else if (op == "7")
                Console.WriteLine($"Total a pagar (21% IVA): ${tienda.Carrito.TotalPagar():F2}");
            else if (op == "8")
                tienda.Carrito.FinalizarCompra();
            else if (op == "9")
                tienda.MostrarHistorialCompras();
            else if (op == "10"){
                try{
                    Console.Write("ID del ticket: ");
                    int idTicket = int.Parse(Console.ReadLine());
                    tienda.MostrarTicketPorID(idTicket);
                }
                catch (FormatException){
                    Console.WriteLine("Entrada inválida. Ingrese un número válido.");
                }
            }
            else if (op == "0"){
                salir = true;
            }
            else{
                Console.WriteLine("Opción inválida.");
            }
        }
    }
}