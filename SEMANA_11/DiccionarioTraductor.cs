using System;
using System.Collections.Generic;

class Traductor
{
    static void Main()
    {
        // Diccionario inicial con palabras básicas
        Dictionary<string, string> diccionario = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            {"time", "tiempo"},
            {"person", "persona"},
            {"year", "año"},
            {"way", "camino"},
            {"day", "día"},
            {"thing", "cosa"},
            {"man", "hombre"},
            {"world", "mundo"},
            {"life", "vida"},
            {"hand", "mano"},
            {"part", "parte"},
            {"child", "niño"},
            {"eye", "ojo"},
            {"woman", "mujer"},
            {"place", "lugar"},
            {"work", "trabajo"},
            {"week", "semana"},
            {"case", "caso"},
            {"point", "punto"},
            {"government", "gobierno"},
            {"company", "empresa"}
        };

        int opcion;
        do
        {
            Console.WriteLine("\n==================== MENÚ ====================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            
            // Validar la opción
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Por favor, ingrese un número válido.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese la frase a traducir: ");
                    string frase = Console.ReadLine();
                    string[] palabras = frase.Split(' ');

                    Console.Write("Traducción: ");
                    foreach (string palabra in palabras)
                    {
                        string limpia = palabra.Trim(',', '.', ';', ':', '!', '?'); // quitar signos
                        if (diccionario.ContainsKey(limpia.ToLower()))
                        {
                            Console.Write(diccionario[limpia.ToLower()] + " ");
                        }
                        else
                        {
                            Console.Write(palabra + " "); // palabra sin traducir
                        }
                    }
                    Console.WriteLine();
                    break;

                case 2:
                    Console.Write("Ingrese la palabra en inglés: ");
                    string ingles = Console.ReadLine().ToLower();

                    Console.Write("Ingrese su traducción en español: ");
                    string espanol = Console.ReadLine().ToLower();

                    if (!diccionario.ContainsKey(ingles))
                    {
                        diccionario.Add(ingles, espanol);
                        Console.WriteLine("Palabra agregada correctamente ✅");
                    }
                    else
                    {
                        Console.WriteLine("La palabra ya existe en el diccionario.");
                    }
                    break;

                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

        } while (opcion != 0);
    }
}
