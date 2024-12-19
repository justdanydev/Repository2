using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    using System;

    public class UppercaseDelegate
    {
       
        public delegate string UppercaseDelegateType(string str);

        public static void Main(string[] args)
        {
            
            UppercaseDelegateType toUppercaseDelegate = ToUppercase;

           
            string uppercaseString = UseDelegate(toUppercaseDelegate, "привет, мир!");

            Console.WriteLine($"Строка в верхнем регистре: {uppercaseString}"); 

            
            UppercaseDelegateType lambdaToUppercase = str => str.ToUpper();
            uppercaseString = UseDelegate(lambdaToUppercase, "hello, world!");
            Console.WriteLine($"Строка в верхнем регистре (лямбда-выражение): {uppercaseString}"); 


           
            string nullString = null;
            try
            {
                uppercaseString = UseDelegate(lambdaToUppercase, nullString);
                Console.WriteLine($"Строка в верхнем регистре (null): {uppercaseString}");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"Ошибка для null строки: {ex.Message}"); 
            }

        }

        
        public static string UseDelegate(UppercaseDelegateType myDelegate, string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str), "Строка не может быть null");
            }
            return myDelegate(str);
        }

        
        public static string ToUppercase(string str)
        {
            return str.ToUpper();
        }
    }

}
