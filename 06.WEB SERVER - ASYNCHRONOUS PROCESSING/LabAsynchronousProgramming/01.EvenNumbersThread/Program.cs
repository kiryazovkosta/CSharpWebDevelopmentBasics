// Print all even numbers in a given range. Printing should be executed on a separate thread. 
// After finishing print "Thread finished work".
namespace _01.EvenNumbersThread
{
    using System;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;

    public class EvenNumbersThreadDemo
    {
        public static void Main()
        {
            int min = 1;
            int max = 10;

            Task task = Task.Run(() => PrintEvenNumbers(min, max))
                .ContinueWith((result) => Console.WriteLine("Thread finished work"));

            task.Wait();
        }

        public static void PrintEvenNumbers(int start, int end)
        {
            for (int number = start; number <= end; number++)
            {
                if (number % 2==0)
                {
                    Console.WriteLine(number);
                }
            }
        }
    }
}
