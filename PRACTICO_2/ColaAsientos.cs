using System;
using System.Collections.Generic;

namespace ParqueDiversiones
{
    // Clase que representa a una persona en la fila
    class Persona
    {
        public string Nombre { get; private set; }

        public Persona(string nombre)
        {
            Nombre = nombre;
        }
    }

    // Clase que representa la atracción con la cola y asignación de asientos
    class Atraccion
    {
        private Queue<Persona> cola;
        private int totalAsientos;
        private int asientosVendidos;

        public Atraccion(int capacidad)
        {
            totalAsientos = capacidad;
            asientosVendidos = 0;
            cola = new Queue<Persona>();
        }

        // Agrega persona a la fila si quedan asientos
        public bool AgregarPersona(Persona p)
        {
            if (asientosVendidos + cola.Count >= totalAsientos)
            {
                return false; // No quedan asientos disponibles
            }

            cola.Enqueue(p);
            return true;
        }

        // Asigna asiento a la persona que está en la fila primero
        public Persona AsignarAsiento()
        {
            if (cola.Count == 0 || asientosVendidos >= totalAsientos)
            {
                return null; // No hay personas o no quedan asientos
            }

            Persona personaAsignada = cola.Dequeue();
            asientosVendidos++;
            return personaAsignada;
        }

        // Muestra el estado actual de la cola
        public void MostrarCola()
        {
            if (cola.Count == 0)
            {
                Console.WriteLine("No hay personas esperando en la cola.");
                return;
            }

            Console.WriteLine("Personas en la cola (orden de llegada):");
            int pos = 1;
            foreach (var p in cola)
            {
                Console.WriteLine($"{pos}. {p.Nombre}");
                pos++;
            }
        }

        public int AsientosVendidos => asientosVendidos;
        public int TotalAsientos => totalAsientos;
        public int PersonasEnCola => cola.Count;
        public int AsientosDisponibles => totalAsientos - (asientosVendidos + cola.Count);
    }

    class Program
    {
        static void Main(string[] args)
        {
            Atraccion atraccion = new Atraccion(30);

            Console.WriteLine("Simulación POO: Asignación de 30 asientos en orden de llegada.");
            Console.WriteLine("--------------------------------------------------------------\n");

            while (atraccion.AsientosVendidos < atraccion.TotalAsientos)
            {
                Console.Write("Ingrese el nombre de la persona que llega a la fila (o escriba 'reportar' para ver la cola): ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Nombre inválido. Intente de nuevo.\n");
                    continue;
                }

                if (input.ToLower() == "reportar")
                {
                    atraccion.MostrarCola();
                    Console.WriteLine($"Asientos vendidos: {atraccion.AsientosVendidos}/{atraccion.TotalAsientos}");
                    Console.WriteLine($"Asientos disponibles: {atraccion.AsientosDisponibles}\n");
                    continue;
                }

                Persona nuevaPersona = new Persona(input);

                if (!atraccion.AgregarPersona(nuevaPersona))
                {
                    Console.WriteLine("Ya no quedan asientos disponibles. No se acepta más gente.");
                    break;
                }
                else
                {
                    Console.WriteLine($"{input} se ha unido a la fila.");
                }

                Persona asignada = atraccion.AsignarAsiento();
                Console.WriteLine($"Se asigna asiento #{atraccion.AsientosVendidos} a {asignada.Nombre}.\n");
            }

            Console.WriteLine("Todos los asientos han sido vendidos.");
            Console.WriteLine("Fin de la simulación.");
            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
