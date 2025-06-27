using System;

namespace FigurasGeometricas
{
    // Clase Circulo representa un círculo con un atributo privado 'radio'
    class Circulo
    {
        // Campo privado que almacena el valor del radio
        private double radio;

        // Constructor que recibe el valor del radio y lo asigna al campo privado
        public Circulo(double radio)
        {
            this.radio = radio;
        }

        // Método para calcular el área de un círculo
        // Fórmula: π * radio^2
        public double CalcularArea()
        {
            return Math.PI * radio * radio;
        }

        // Método para calcular el perímetro (circunferencia) de un círculo
        // Fórmula: 2 * π * radio
        public double CalcularPerimetro()
        {
            return 2 * Math.PI * radio;
        }
    }

    // Clase Rectangulo representa un rectángulo con base y altura
    class Rectangulo
    {
        // Campos privados que almacenan los valores de base y altura
        private double baseRect;
        private double altura;

        // Constructor que recibe base y altura y los asigna a los campos privados
        public Rectangulo(double baseRect, double altura)
        {
            this.baseRect = baseRect;
            this.altura = altura;
        }

        // Método para calcular el área de un rectángulo
        // Fórmula: base * altura
        public double CalcularArea()
        {
            return baseRect * altura;
        }

        // Método para calcular el perímetro de un rectángulo
        // Fórmula: 2 * (base + altura)
        public double CalcularPerimetro()
        {
            return 2 * (baseRect + altura);
        }
    }

    // Clase principal para probar el funcionamiento de las figuras geométricas
    class Program
    {
        static void Main(string[] args)
        {
            // Crear un objeto de la clase Circulo con radio 5
            Circulo miCirculo = new Circulo(5);
            Console.WriteLine("Círculo:");
            Console.WriteLine("Área: " + miCirculo.CalcularArea());
            Console.WriteLine("Perímetro: " + miCirculo.CalcularPerimetro());

            // Crear un objeto de la clase Rectangulo con base 4 y altura 6
            Rectangulo miRectangulo = new Rectangulo(4, 6);
            Console.WriteLine("\nRectángulo:");
            Console.WriteLine("Área: " + miRectangulo.CalcularArea());
            Console.WriteLine("Perímetro: " + miRectangulo.CalcularPerimetro());
        }
    }
}
