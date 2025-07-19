using System;
using System.Collections.Generic;

namespace AsignacionAsientos
{
    public class Persona
    {
        public string Nombre { get; set; }
        public int ID { get; set; }

        public Persona(string nombre, int id)
        {
            Nombre = nombre;
            ID = id;
        }
    }

    public class ColaAsientos
    {
        private Queue<Persona> cola = new Queue<Persona>();
        private int capacidadMaxima = 30;

        public void AgregarPersona(Persona persona)
        {
            if (cola.Count < capacidadMaxima)
            {
                cola.Enqueue(persona);
                Console.WriteLine($"[+] {persona.Nombre} ha sido agregado a la cola.");
            }
            else
            {
                Console.WriteLine("[!] No hay más asientos disponibles.");
            }
        }

        public void MostrarCola()
        {
            Console.WriteLine("\n--- Lista de Personas en la Cola ---");
            int asiento = 1;
            foreach (var p in cola)
            {
                Console.WriteLine($"Asiento {asiento++}: {p.Nombre} (ID: {p.ID})");
            }
        }

        public void AsignarAsientos()
        {
            Console.WriteLine("\nAsignando asientos...");
            int asiento = 1;
            while (cola.Count > 0)
            {
                Persona p = cola.Dequeue();
                Console.WriteLine($"[✓] {p.Nombre} asignado al asiento {asiento++}.");
            }
        }
    }
}