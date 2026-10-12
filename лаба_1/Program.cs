using System;

namespace варіант6
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            try
            {
                TTriangle t = new TTriangle();
                t.Input();
                t.Output();
                Console.WriteLine("Периметр: " + t.Perimeter());
                Console.WriteLine("Площа: " + t.Area());
            }
            catch (Exception e)
            {
                Console.WriteLine("Помилка: " + e.Message);
            }
        }
    }
}