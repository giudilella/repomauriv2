public class Producto
{
    private static int contadorCodigo = 1;
    public int Codigo { get; private set; }
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public int Stock { get; set; }
    public Categoria Categoria { get; set; }

    public Producto(string nombre, double precio, int stock, Categoria categoria)
    {
        Codigo = contadorCodigo++;
        Nombre = nombre;
        Precio = precio;
        Stock = stock;
        Categoria = categoria;
    }
}
