public class Inversor
{
    public List<int> InvertirLista(List<int> lista)
    {
        lista.Reverse();
        return lista;
    }
}

class Program
{
    static void Main()
    {
        var inv = new Inversor();
        var invertida = inv.InvertirLista(new List<int> { 10, 20, 30, 40 });
        Console.WriteLine("Lista invertida: " + string.Join(", ", invertida));
    }
}
