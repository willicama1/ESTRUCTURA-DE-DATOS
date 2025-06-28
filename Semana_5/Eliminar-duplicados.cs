using System;
using System.Collections.Generic;

public class ListaUnica
{
    public List<int> EliminarDuplicados(List<int> original)
    {
        HashSet<int> conjunto = new HashSet<int>(original);
        return new List<int>(conjunto);
    }
}

// Uso
class Program
{
    static void Main()
    {
        var lista = new ListaUnica();
        var resultado = lista.EliminarDuplicados(new List<int> { 1, 2, 2, 3, 4, 4, 5 });
        Console.WriteLine("Lista sin duplicados: " + string.Join(", ", resultado));
    }
}
