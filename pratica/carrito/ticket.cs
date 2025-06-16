using System;
using System.Collections.Generic;

public class Ticket
{
    public int ID { get; set; }
    public DateTime FechaCompra { get; set; }
    public List<ItemCarrito> ItemsComprados { get; set; }
    public double TotalConIVA { get; set; }

    public Ticket(int id, DateTime fechaCompra, List<ItemCarrito> itemsComprados, double totalConIVA){
        ID = id;
        FechaCompra = fechaCompra;
        ItemsComprados = itemsComprados;
        TotalConIVA = totalConIVA;
    }

        public static int GenerarID(){
        return contadorID++;
    }

    public void MostrarTicket(){
        Console.WriteLine($"\n--- Ticket ID: {ID} ---");
        Console.WriteLine($"Fecha: {FechaCompra:dd/MM/yyyy HH:mm:ss}");
        Console.WriteLine("Items comprados:");
        foreach (var item in ItemsComprados){
            double subtotal = item.Subtotal();
            Console.WriteLine($"- [{item.Producto.Codigo}] {item.Producto.Nombre}, precio u.: {item.Producto.Precio:F2}, cantidad: {item.Cantidad}, subtotal: {subtotal:F2}");
        }
        Console.WriteLine($"Total con IVA (21%): ${TotalConIVA:F2}");
    }
}
