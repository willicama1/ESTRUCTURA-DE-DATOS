using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // 1. Generar los 500 ciudadanos
        var todos = new HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            todos.Add($"Ciudadano {i}");
        }

        // 2. Crear 75 ciudadanos vacunados con Pfizer
        var pfizer = new HashSet<string>();
        for (int i = 1; i <= 75; i++)
        {
            pfizer.Add($"Ciudadano {i}");
        }

        // 3. Crear 75 ciudadanos vacunados con AstraZeneca
        var astrazeneca = new HashSet<string>();
        for (int i = 50; i < 125; i++) // se solapan con Pfizer algunos
        {
            astrazeneca.Add($"Ciudadano {i}");
        }

        // 4. Aplicar operaciones de conjuntos
        // Ciudadanos no vacunados
        var noVacunados = new HashSet<string>(todos);
        noVacunados.ExceptWith(pfizer);
        noVacunados.ExceptWith(astrazeneca);

        // Ciudadanos que recibieron ambas dosis
        var ambasDosis = new HashSet<string>(pfizer);
        ambasDosis.IntersectWith(astrazeneca);

        // Solo Pfizer
        var soloPfizer = new HashSet<string>(pfizer);
        soloPfizer.ExceptWith(astrazeneca);

        // Solo AstraZeneca
        var soloAstraZeneca = new HashSet<string>(astrazeneca);
        soloAstraZeneca.ExceptWith(pfizer);

        // 5. Mostrar resultados
        Console.WriteLine("==== CAMPAÑA DE VACUNACIÓN COVID-19 ====\n");
        
        Console.WriteLine("1. Ciudadanos que NO se han vacunado:");
        Console.WriteLine($"Total: {noVacunados.Count}\n");

        Console.WriteLine("2. Ciudadanos que recibieron AMBAS dosis:");
        Console.WriteLine($"Total: {ambasDosis.Count}\n");

        Console.WriteLine("3. Ciudadanos que SOLO recibieron Pfizer:");
        Console.WriteLine($"Total: {soloPfizer.Count}\n");

        Console.WriteLine("4. Ciudadanos que SOLO recibieron AstraZeneca:");
        Console.WriteLine($"Total: {soloAstraZeneca.Count}\n");
    }
}
