using System;

namespace MusicIS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Информация о музыке";

            Console.WriteLine("Программа для вывода информации о музыке");
            try
            {
                View.Console myConsole = new View.Console("music.bin");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
