using System; //importación de librerías, permnite usar funciones básicas (writeLine)
using System.Threading;//importa la funcionalidad necesaria para utilizar hilos 
class Program
{

    static DateTime horaAlarma;
    static bool alarmaActivada = false;

    static void Main(string[] args)
    {
        Console.WriteLine("-------- Reloj con Alarma ----------");// encabezado de comentario en consola de alarma
        Console.Write("Ingresa la hora de la alarma (formato HH:mm:ss Tomando en cuenta el formato de 24 hrs): ");

        string entrada = Console.ReadLine();
        while (!DateTime.TryParseExact(entrada, "HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out horaAlarma))
        {
            Console.Write("Formato inválido. Intenta de nuevo (HH:mm:ss): ");
            entrada = Console.ReadLine();
        }

        alarmaActivada = true;

        // Iniciar hilos
        Thread hiloReloj = new Thread(MostrarHora);
        Thread hiloAlarma = new Thread(EsperarAlarma);

        hiloReloj.Start();
        hiloAlarma.Start();

        // Esperar que el usuario quiera salir
        Console.WriteLine("Presiona ENTER para salir del programa...");
        Console.ReadLine();
        alarmaActivada = false;
    }
    static void MostrarHora()
    {
        while (alarmaActivada)
        {
            Console.Clear();
            Console.WriteLine("Hora actual: " + DateTime.Now.ToLongTimeString());
            Console.WriteLine("Hora de la alarma: " + horaAlarma.ToLongTimeString());
            Thread.Sleep(1000);
        }
    }

    static void EsperarAlarma()
    {
        while (alarmaActivada)
        {
            if (DateTime.Now.Hour == horaAlarma.Hour &&
                DateTime.Now.Minute == horaAlarma.Minute &&
                DateTime.Now.Second == horaAlarma.Second)
            {
                Console.Beep(); // Opcional: sonido de alarma
                Console.WriteLine("\n\n¡Alarmaaaaa! Ha llegado la hora: " + horaAlarma.ToLongTimeString());
                alarmaActivada = false;
            }

            Thread.Sleep(500); // Verifica dos veces por segundo
        }
    }

}
