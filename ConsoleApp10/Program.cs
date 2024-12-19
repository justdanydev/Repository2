using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    using System;

    public class DelegateExample
    {
        
        public delegate int SumDelegate(int a, int b);

        public static void Main(string[] args)
        {
            
            SumDelegate sumDelegate = Sum;

            
            int result = UseDelegate(sumDelegate, 10, 5);

            Console.WriteLine($"Сумма: {result}"); 


            
            SumDelegate anonymousSum = delegate (int x, int y) { return x + y; };
            result = UseDelegate(anonymousSum, 20, 30);
            Console.WriteLine($"Сумма (анонимный метод): {result}");


            
            SumDelegate lambdaSum = (x, y) => x + y;
            result = UseDelegate(lambdaSum, 40, 60);
            Console.WriteLine($"Сумма (лямбда-выражение): {result}"); 

        }

       
        public static int UseDelegate(SumDelegate myDelegate, int num1, int num2)
        {
            return myDelegate(num1, num2);
        }

       
        public static int Sum(int a, int b)
        {
            return a + b;
        }
    }

}
