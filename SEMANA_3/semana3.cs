using System;

namespace RegistroEstudiantes
{
    // Definimos la clase Estudiante
    public class Estudiante
    {
        // Atributos básicos del estudiante
        public long Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }

        // Array para guardar los tres teléfonos
        public string[] Telefonos = new string[3];

        // Constructor de la clase
        public Estudiante(long id, string nombres, string apellidos, string direccion, string[] telefonos)
        {
            Id = id;
            Nombres = nombres;
            Apellidos = apellidos;
            Direccion = direccion;

            // Validamos que se ingresen 3 teléfonos
            if (telefonos.Length == 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    Telefonos[i] = telefonos[i];
                }
            }
            else
            {
                Console.WriteLine("Error: Debe ingresar exactamente 3 teléfonos.");
            }
        }

        // Método para mostrar los datos del estudiante
        public void MostrarInformacion()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Nombres: " + Nombres);
            Console.WriteLine("Apellidos: " + Apellidos);
            Console.WriteLine("Dirección: " + Direccion);
            Console.WriteLine("Teléfonos:");
            for (int i = 0; i < Telefonos.Length; i++)
            {
                Console.WriteLine($"Teléfono {i + 1}: {Telefonos[i]}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Creamos un array con los tres teléfonos reales
            string[] telefonos = {
                "0981869752", // mi teléfono
                "0939559103", // Teléfono de mi mamá
                "0989488790"  // Teléfono de mi hermana
            };

            // Creamos una instancia del estudiante con mis datos
            Estudiante estudiante1 = new Estudiante(
                2101137244,
                "William Alexander",
                "Camacho Sanchez",
                "Barrio 11 de Abril",
                telefonos
            );

            // Mostramos la información en consola
            estudiante1.MostrarInformacion();
        }
    }
}
