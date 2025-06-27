using System;
using System.Collections.Generic;
using System.Linq;

namespace AgendaTurnosClinica
{
    // Clase que representa un paciente
    class Paciente
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }

        public Paciente(string cedula, string nombre, int edad)
        {
            Cedula = cedula;
            Nombre = nombre;
            Edad = edad;
        }
    }

    // Clase que representa un turno médico
    class Turno
    {
        public Paciente Paciente { get; set; }
        public DateTime FechaHora { get; set; }

        public Turno(Paciente paciente, DateTime fechaHora)
        {
            Paciente = paciente;
            FechaHora = fechaHora;
        }

        public void Mostrar()
        {
            Console.WriteLine($"Paciente: {Paciente.Nombre} | Cédula: {Paciente.Cedula} | Edad: {Paciente.Edad} | Fecha y hora: {FechaHora}");
        }
    }

    // Clase que representa la agenda de turnos
    class Agenda
    {
        private List<Turno> turnos = new List<Turno>();
        private List<Paciente> pacientes = new List<Paciente>();

        // Agrega un nuevo paciente
        public void AgregarPaciente()
        {
            Console.Write("Ingrese cédula del paciente: ");
            string cedula = Console.ReadLine();
            Console.Write("Ingrese nombre del paciente: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese edad del paciente: ");
            int edad;

            while (!int.TryParse(Console.ReadLine(), out edad))
            {
                Console.Write("Edad inválida. Ingrese un número entero: ");
            }

            pacientes.Add(new Paciente(cedula, nombre, edad));
            Console.WriteLine("✅ Paciente registrado con éxito.\n");
        }

        // Asigna un turno a un paciente existente
        public void AsignarTurno()
        {
            Console.Write("Ingrese cédula del paciente: ");
            string cedula = Console.ReadLine();
            Paciente paciente = pacientes.FirstOrDefault(p => p.Cedula == cedula);

            if (paciente == null)
            {
                Console.WriteLine("❌ Paciente no encontrado. Regístrelo primero.\n");
                return;
            }

            Console.Write("Ingrese fecha del turno (YYYY-MM-DD): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime fecha))
            {
                Console.WriteLine("❌ Fecha inválida.\n");
                return;
            }

            Console.Write("Ingrese hora del turno (HH:MM): ");
            if (!TimeSpan.TryParse(Console.ReadLine(), out TimeSpan hora))
            {
                Console.WriteLine("❌ Hora inválida.\n");
                return;
            }

            DateTime fechaHora = fecha.Date + hora;

            // Verificar si ya hay un turno en esa fecha y hora
            if (turnos.Any(t => t.FechaHora == fechaHora))
            {
                Console.WriteLine("⚠️ Ya existe un turno en esa fecha y hora. Elija otro horario.\n");
                return;
            }

            turnos.Add(new Turno(paciente, fechaHora));
            Console.WriteLine("✅ Turno asignado exitosamente.\n");
        }

        // Muestra todos los turnos registrados
        public void MostrarAgenda()
        {
            Console.WriteLine("\n📅 Turnos registrados:");
            if (turnos.Count == 0)
            {
                Console.WriteLine("No hay turnos registrados aún.\n");
                return;
            }

            foreach (var turno in turnos.OrderBy(t => t.FechaHora))
            {
                turno.Mostrar();
            }
            Console.WriteLine();
        }

        // Busca turnos por nombre del paciente
        public void BuscarPorNombre()
        {
            Console.Write("Ingrese nombre del paciente a buscar: ");
            string nombre = Console.ReadLine();

            var resultados = turnos.Where(t => t.Paciente.Nombre.ToLower().Contains(nombre.ToLower())).ToList();

            if (resultados.Count == 0)
            {
                Console.WriteLine("❌ No se encontraron turnos con ese nombre.\n");
                return;
            }

            Console.WriteLine($"🔎 Turnos encontrados para \"{nombre}\":");
            foreach (var turno in resultados)
            {
                turno.Mostrar();
            }
            Console.WriteLine();
        }

        // Busca turnos por fecha
        public void BuscarPorFecha()
        {
            Console.Write("Ingrese la fecha (YYYY-MM-DD): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime fecha))
            {
                Console.WriteLine("❌ Fecha inválida.\n");
                return;
            }

            var resultados = turnos.Where(t => t.FechaHora.Date == fecha.Date).ToList();

            if (resultados.Count == 0)
            {
                Console.WriteLine("❌ No hay turnos registrados para esa fecha.\n");
                return;
            }

            Console.WriteLine($"🔎 Turnos para el día {fecha:dd/MM/yyyy}:");
            foreach (var turno in resultados)
            {
                turno.Mostrar();
            }
            Console.WriteLine();
        }
    }

    // Clase principal del programa
    class Program
    {
        static void Main(string[] args)
        {
            Agenda agenda = new Agenda();
            int opcion;

            do
            {
                Console.WriteLine("=== Menú Principal ===");
                Console.WriteLine("1. Registrar paciente");
                Console.WriteLine("2. Asignar turno");
                Console.WriteLine("3. Mostrar todos los turnos");
                Console.WriteLine("4. Buscar turno por nombre");
                Console.WriteLine("5. Buscar turno por fecha");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                while (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.Write("Opción inválida. Ingrese un número: ");
                }

                Console.WriteLine();

                switch (opcion)
                {
                    case 1:
                        agenda.AgregarPaciente();
                        break;
                    case 2:
                        agenda.AsignarTurno();
                        break;
                    case 3:
                        agenda.MostrarAgenda();
                        break;
                    case 4:
                        agenda.BuscarPorNombre();
                        break;
                    case 5:
                        agenda.BuscarPorFecha();
                        break;
                    case 0:
                        Console.WriteLine("¡Gracias por usar la agenda de turnos!");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.\n");
                        break;
                }

            } while (opcion != 0);
        }
    }
}
