using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var task = CountPrimes(2, 200000);
            Console.Write("Waiting for task to complete...");
            while (!task.IsCompleted)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }

            Console.WriteLine("\nCalculation is over");
            Console.WriteLine("Total Primes "+task.Result);

        }


        static async Task<int> CountPrimes(int min, int max)
        {
            int count = 0;

            for (int i = min; i < max; i++)
            {
                var result = await IsPrime(i);
                if (result)
                    count++;
            }

            return count;
        }




        static int CountPrimesSync(int min,int max)
        {
            int count = 0;

            for(int i=min;i<max;i++)
            {
                var task = IsPrime(i);
                task.Wait();
                var result = task.Result;
                if (result)
                    count++;
            }

            return count;
        }



        static Task<bool> IsPrime(int number)
        {
            //let us create a task to this job

            return Task.Factory.StartNew(() =>
            {
                if (number < 2)
                    return false;
                for (int i = 2; i < number; i++)
                    if (number % i == 0)
                        return false;

                return true;
            });

        }
    }
}
