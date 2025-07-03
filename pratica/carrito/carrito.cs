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
            return $"No hay stock suficiente para {prod.Nombre}. Stock disponible: {prod.Stock}";
        var existente = items.FirstOrDefault(i => i.Producto.Codigo == prod.Codigo);
        if (existente != null)
            existente.Cantidad += cantidad;
        else
            items.Add(new ItemCarrito(prod, cantidad));
        prod.Stock -= cantidad; // Restar del stock al agregar
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
    public Ticket FinalizarCompra()
    {
        if (items.Count == 0)
        {
            Console.WriteLine("El carrito está vacío. No se puede finalizar la compra.");
            return null;
        }

        var itemsTicket = new List<ItemCarrito>(items.Select(i => new ItemCarrito(i.Producto, i.Cantidad)));
        double totalConIVA = TotalPagar();

        var ticket = new Ticket(Ticket.GenerarID(), DateTime.Now, itemsTicket, totalConIVA);
        Tienda tienda = new Tienda(); // Temporal, asumiendo acceso a la instancia de Tienda
        tienda.AgregarTicket(ticket);

        items.Clear();
        Console.WriteLine("Compra completada y stock actualizado.");

        return ticket;
    }

    // Eliminar una cantidad específica de un producto del carrito
    public string EliminarProducto(int codigoProducto, int cantidadEliminar)
    {
        var item = items.FirstOrDefault(i => i.Producto.Codigo == codigoProducto);
        if (item == null)
            return "El producto no está en el carrito.";

        if (cantidadEliminar <= 0)
            return "La cantidad a eliminar debe ser positiva.";

        if (cantidadEliminar > item.Cantidad)
            return $"No se puede eliminar {cantidadEliminar} unidades. Solo hay {item.Cantidad} en el carrito.";

        item.Producto.Stock += cantidadEliminar; // Devolver al stock
        item.Cantidad -= cantidadEliminar;
        if (item.Cantidad <= 0)
        {
            items.Remove(item);
            return $"Se eliminaron {cantidadEliminar} x {item.Producto.Nombre} del carrito.";
        }
        else
        {
            return $"Se eliminaron {cantidadEliminar} x {item.Producto.Nombre}. Quedan {item.Cantidad} en el carrito.";
        }
    }

    // Calcular total a pagar con IVA (giu)
    public double TotalPagar()
    {
        double subtotal = items.Sum(i => i.Subtotal());
        return subtotal * 1.21; // 21% de IVA
    }
}