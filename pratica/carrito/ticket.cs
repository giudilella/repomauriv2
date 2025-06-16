using System;
using System.Collections.Generic;

public class Ticket
{
    public int ID { get; set; }
    public DateTime FechaCompra { get; set; }
    public List<ItemCarrito> ItemsComprados { get; set; }
    public double TotalConIVA { get; set; }

    public Ticket(int id, DateTime fechaCompra, List<ItemCarrito> itemsComprados, double totalConIVA)
    {
        ID = id;
        FechaCompra = fechaCompra;
        ItemsComprados = itemsComprados;
        TotalConIVA = totalConIVA;
    }

    public void MostrarTicket()
    {
        // rodriiiii
    }
}
