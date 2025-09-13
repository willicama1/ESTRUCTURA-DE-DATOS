using System;
using System.Collections.Generic;

class Program
{
    // Método principal
    static void Main()
    {
        // Creamos un catálogo de revistas usando una lista
        List<string> catalogoRevistas = new List<string>()
        {
            "National Geographic",
            "Time",
            "Forbes",
            "Vogue",
            "Scientific American",
            "The Economist",
            "People",
            "Rolling Stone",
            "Wired",
            "Harvard Business Review"
        };

        int opcion;
        do
        {
            // Menú interactivo
            Console.WriteLine("\n--- Catálogo de Revistas ---");
            Console.WriteLine("1. Buscar revista");
            Console.WriteLine("2. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el título de la revista a buscar: ");
                    string titulo = Console.ReadLine();

                    // Llamamos al método de búsqueda iterativa (puedes cambiar a recursiva si prefieres)
                    bool encontrado = BuscarRevista(catalogoRevistas, titulo);

                    // Mostramos el resultado
                    if (encontrado)
                        Console.WriteLine("Encontrado");
                    else
                        Console.WriteLine("No encontrado");
                    break;

                case 2:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                    break;
            }
        } while (opcion != 2);
    }

    // Método de búsqueda iterativa
    static bool BuscarRevista(List<string> catalogo, string titulo)
    {
        foreach (string revista in catalogo)
        {
            // Comparación ignorando mayúsculas/minúsculas
            if (revista.Equals(titulo, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }

    // Ejemplo de búsqueda recursiva (opcional)
    static bool BuscarRevistaRecursiva(List<string> catalogo, string titulo, int index)
    {
        if (index >= catalogo.Count)
            return false;

        if (catalogo[index].Equals(titulo, StringComparison.OrdinalIgnoreCase))
            return true;

        return BuscarRevistaRecursiva(catalogo, titulo, index + 1);
    }
}
