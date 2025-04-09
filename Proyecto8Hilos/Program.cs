using System; //importación de librerías, permnite usar funciones básicas (writeLine)
using System.Threading;//importa la funcionalidad necesaria para utilizar hilos 
class Program
{

    static DateTime horaAlarma;
    static bool alarmaActivada = false;

    static void Main(string[] args)
    {
        Console.WriteLine("-------- Reloj con Alarma ----------");
        Console.Write("Ingresa la hora de la alarma (formato HH:mm:ss Tomando en cuenta el formato de 24 hrs): ");

        string entrada = Console.ReadLine();

    }
}