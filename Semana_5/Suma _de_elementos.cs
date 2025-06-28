public class CalculadoraLista
{
    public int Sumar(List<int> numeros)
    {
        int suma = 0;
        foreach (var n in numeros)
        {
            suma += n;
        }
        return suma;
    }
}

class Program
{
    static void Main()
    {
        var calc = new CalculadoraLista();
        var total = calc.Sumar(new List<int> { 10, 20, 30 });
        Console.WriteLine("Suma total: " + total);
    }
}
