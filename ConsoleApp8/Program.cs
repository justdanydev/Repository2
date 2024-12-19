using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    using System;

    public class DivisionDelegate
    {
       
        public delegate double DivisionDelegateType(double a, double b);

        public static void Main(string[] args)
        {
            
            DivisionDelegateType calculateDivisionDelegate = CalculateDivision;

            
            try
            {
                double result = UseDelegate(calculateDivisionDelegate, 10, 2);
                Console.WriteLine($"Результат деления: {result}"); 
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            try
            {
                double result = UseDelegate(calculateDivisionDelegate, 10, 0);
                Console.WriteLine($"Результат деления: {result}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}"); 
            }


            
            DivisionDelegateType lambdaDivision = (a, b) => {
                if (b == 0)
                {
                    throw new DivideByZeroException("Деление на ноль");
                }
                return a / b;
            };
            try
            {
                double result = UseDelegate(lambdaDivision, 15, 3);
                Console.WriteLine($"Результат деления (лямбда-выражение): {result}"); 
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }


            try
            {
                double result = UseDelegate(lambdaDivision, 20, 0);
                Console.WriteLine($"Результат деления (лямбда-выражение): {result}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}"); 
            }
        }


       
        public static double UseDelegate(DivisionDelegateType myDelegate, double num1, double num2)
        {
            return myDelegate(num1, num2);
        }

       
        public static double CalculateDivision(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Деление на ноль");
            }
            return a / b;
        }
    }

}
