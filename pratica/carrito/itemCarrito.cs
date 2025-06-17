public class ItemCarrito{
    public Producto Producto { get; set; }
    public int Cantidad { get; set; }
    public ItemCarrito(Producto prod, int cantidad){
        Producto = prod;
        Cantidad = cantidad;
    }
    public double Subtotal(){
        double total = Producto.Precio * Cantidad;
        // descuento del 15% si compra 5 o más del mismo producto
        if (Cantidad >= 5)
            total *= 0.85;
        return total;
    }
}
