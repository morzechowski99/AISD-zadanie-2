using System;
using System.Threading;

namespace zadanie_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int result=0;
            
            Lochy.ReadData();
            Thread t = new Thread(() => result = Lochy.GetResult(), 2048 * 2048 *2);
            t.Start();
            t.Join();
            //  Lochy.WriteData();
            Console.WriteLine("Wynik: {0}",result);
            Console.WriteLine("Ilosc operacji: {0}",Lochy.GetCounter());
            Console.WriteLine("Ilosc wywolan funkcji {0}", Lochy.GetRecursioncounter());
        }
          
    }
}
