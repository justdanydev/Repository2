using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    using System;

    public class DifferenceDelegate
    {
      
        public delegate int DifferenceDelegateType(int a, int b);

        public static void Main(string[] args)
        {
           
            DifferenceDelegateType calculateDifferenceDelegate = CalculateDifference;

            
            int difference = UseDelegate(calculateDifferenceDelegate, 10, 5);

            Console.WriteLine($"Разность: {difference}"); 


            
            DifferenceDelegateType lambdaDifference = (a, b) => a - b;
            difference = UseDelegate(lambdaDifference, 20, 8);
            Console.WriteLine($"Разность (лямбда-выражение): {difference}"); 
        }

        
        public static int UseDelegate(DifferenceDelegateType myDelegate, int num1, int num2)
        {
            return myDelegate(num1, num2);
        }

        
        public static int CalculateDifference(int a, int b)
        {
            return a - b;
        }
    }

}
