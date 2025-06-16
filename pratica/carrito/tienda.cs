using System;
using System.Collections.Generic;
using System.Linq;

public class Tienda
{
    public List<Categoria> Categorias { get; set; } = new List<Categoria>();
    public List<Producto> Productos { get; set; } = new List<Producto>();
    public Carrito Carrito { get; set; } = new Carrito();

    public Tienda()
    {
        // datos de prueba
        var c1 = new Categoria("Electrónicos", "Celulares, notebooks, etc.");
        var c2 = new Categoria("Alimentos", "Comestibles varios");

        Categorias.Add(c1);
        Categorias.Add(c2);

        Productos.Add(new Producto("Celular XYZ", 30000, 10, c1));
        Productos.Add(new Producto("Notebook ABC", 80000, 5, c1));
        Productos.Add(new Producto("Manzana", 200, 100, c2));
    }

    public void MostrarCategorias()
    {
        Console.WriteLine("Categorías disponibles:");
        foreach (var c in Categorias)
            Console.WriteLine($"- {c.Nombre}: {c.Descripcion}");
    }

    public void MostrarProductos(List<Producto> productos = null)
    {
        var lista = productos ?? Productos;
        Console.WriteLine("Productos:");
        foreach (var p in lista)
            Console.WriteLine($"[{p.Codigo}] {p.Nombre}, precio: {p.Precio}, stock: {p.Stock}, categoría: {p.Categoria.Nombre}");
    }

    public void MostrarPorCategoria(string nombreCat)
    {
        var fil = Productos.Where(p => p.Categoria.Nombre.Equals(nombreCat, StringComparison.OrdinalIgnoreCase)).ToList();
        if (fil.Count == 0)
            Console.WriteLine("No hay productos para esa categoría.");
        else
            MostrarProductos(fil);
    }
}
