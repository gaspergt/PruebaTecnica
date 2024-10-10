using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            DateTime now = DateTime.Now;
            Console.WriteLine("Hora actual: {0}:{1}:{2}", now.Hour.ToString("D2"), now.Minute.ToString("D2"), now.Second.ToString("D2"));
            Thread.Sleep(1000); // Pausa de 1 segundo para actualizar la hora
        }
    }
}
