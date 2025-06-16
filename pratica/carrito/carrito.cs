using System;
using System.Collections.Generic;
using System.Linq;

public class Carrito
{
    private List<ItemCarrito> items = new List<ItemCarrito>();

    // (PILI) Agregar un producto al carrito
    public string AgregarProducto(Producto prod, int cantidad)
    {
        if (cantidad <= 0)
            return "La cantidad debe ser positiva.";
        if (prod.Stock < cantidad)
            return $"No hay stock suficiente para {prod.Nombre}. Stock: {prod.Stock}";
        var existente = items.FirstOrDefault(i => i.Producto.Codigo == prod.Codigo);
        if (existente != null)
            existente.Cantidad += cantidad;
        else
            items.Add(new ItemCarrito(prod, cantidad));
        return $"Se agregaron {cantidad} x {prod.Nombre}";
    }

    // (PILI) Ver contenido del carrito
    public void VerCarrito()
    {
        if (items.Count == 0)
        {
            Console.WriteLine("El carrito está vacío.");
            return;
        }
        Console.WriteLine("Carrito:");
        foreach (var i in items)
        {
            Console.WriteLine($"- [{i.Producto.Codigo}] {i.Producto.Nombre}, precio u.: {i.Producto.Precio}, cantidad: {i.Cantidad}, subtotal: {i.Subtotal():F2}");
        }
    }


    // (PILI) Finalizar compra: actualiza stock y vacía carrito
    public Ticket FinalizarCompra(){
        if (items.Count == 0){
        Console.WriteLine("El carrito está vacío. No se puede finalizar la compra.");
        return null;
        }

    var itemsTicket = new List<ItemCarrito>(items.Select(i => new ItemCarrito(i.Producto, i.Cantidad)));

    foreach (var i in items)
        i.Producto.Stock -= i.Cantidad;

    double totalConIVA = TotalPagar();

    var ticket = new Ticket(Ticket.GenerarID(), DateTime.Now, itemsTicket, totalConIVA);

    items.Clear();
    Console.WriteLine("Compra completada y stock actualizado.");

    return ticket;
    }

 // agregar método para eliminar un producto del carrito(giu)
    public string EliminarProducto(int codigoProducto){
        var item = items.FirstOrDefault(i => i.Producto.Codigo == codigoProducto);
        if (item == null)
            return "El producto no está en el carrito.";
        items.Remove(item);
        return $"Se eliminó {item.Producto.Nombre} del carrito.";
    }

// calcular total a pagar con IVA (giu)
    public double TotalPagar()
    {
        double subtotal = items.Sum(i => i.Subtotal());
        return subtotal * 1.21; // 21% de IVA
    }
}