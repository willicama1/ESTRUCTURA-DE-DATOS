public class Ordenador
{
    public List<int> OrdenarAscendente(List<int> datos)
    {
        datos.Sort();
        return datos;
    }
}

class Program
{
    static void Main()
    {
        var orden = new Ordenador();
        var ordenados = orden.OrdenarAscendente(new List<int> { 5, 3, 1, 4, 2 });
        Console.WriteLine("Ordenados: " + string.Join(", ", ordenados));
    }
}
