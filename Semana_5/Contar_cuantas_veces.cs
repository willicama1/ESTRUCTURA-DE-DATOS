public class Contador
{
    public int ContarOcurrencias(List<int> datos, int objetivo)
    {
        int contador = 0;
        foreach (var item in datos)
        {
            if (item == objetivo)
            {
                contador++;
            }
        }
        return contador;
    }
}

class Program
{
    static void Main()
    {
        var contar = new Contador();
        int repeticiones = contar.ContarOcurrencias(new List<int> { 1, 2, 2, 3, 4, 2 }, 2);
        Console.WriteLine("El número aparece: " + repeticiones + " veces");
    }
}
