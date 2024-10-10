using System;
using System.Collections.Generic;

class Triangulo
{
    public string Nombre { get; set; }
    public double Base { get; set; }
    public double Altura { get; set; }
    public double Area => (Base * Altura) / 2;
}

class Program
{
    static void Main(string[] args)
    {
        List<Triangulo> triangulos = new List<Triangulo>();

        while (true)
        {
            Console.WriteLine("Ingrese el nombre del triángulo (o 'salir' para terminar): ");
            string nombre = Console.ReadLine();
            if (nombre.ToLower() == "salir") 
            {
                break;  
            }

            Console.WriteLine("Ingrese la base del triángulo: ");
            if (!double.TryParse(Console.ReadLine(), out double baseTriangulo))
            {
                Console.WriteLine("Valor inválido para la base, intente nuevamente.");
                continue;  
            }

            Console.WriteLine("Ingrese la altura del triángulo: ");
            if (!double.TryParse(Console.ReadLine(), out double alturaTriangulo))
            {
                Console.WriteLine("Valor inválido para la altura, intente nuevamente.");
                continue;  
            }

            Triangulo triangulo = new Triangulo
            {
                Nombre = nombre,
                Base = baseTriangulo,
                Altura = alturaTriangulo
            };

            triangulos.Add(triangulo);  
        }

        
        if (triangulos.Count > 0)
        {
            Console.WriteLine("\nResultados:");
            Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10}", "Nombre", "Base", "Altura", "Área");

            foreach (var t in triangulos)
            {
                Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10}", t.Nombre, t.Base, t.Altura, t.Area);
            }
        }
        else
        {
            Console.WriteLine("No se ingresaron triángulos.");
        }
    }
}
