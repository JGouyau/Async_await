using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async_await
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Task<int>> listeDeTache = new Dictionary<int, Task<int>> { { 1, Tache() }, { 2, Tache() } };
            Task.WhenAll(listeDeTache.Values);
            foreach(var tache in listeDeTache)
            {
                Console.WriteLine("la tache " + tache.Key + " a attendu "+ tache.Value.Result);
            }

            Console.ReadLine();
        }

        static async Task<int> Tache()
        {
            Random rng = new Random();
            Int32 waitTime = rng.Next(1000, 5000);
            await Task.Delay(waitTime);
            return waitTime;
        }
    }
}
