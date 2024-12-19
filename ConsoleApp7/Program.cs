using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    using System;
    using System.Linq;

    public class ConcatenateStringsDelegate
    {
        
        public delegate string ConcatenateStringsDelegateType(string[] strings);

        public static void Main(string[] args)
        {
            string[] myStrings = { "apple", "banana", "cherry", "date" };

            
            ConcatenateStringsDelegateType concatenateDelegate = Concatenate;

            
            string result = UseDelegate(concatenateDelegate, myStrings);

            Console.WriteLine($"Объединенная строка: {result}");


           
            ConcatenateStringsDelegateType lambdaConcatenate = strings => string.Join(",", strings);
            result = UseDelegate(lambdaConcatenate, myStrings);
            Console.WriteLine($"Объединенная строка (лямбда-выражение): {result}"); 


           
            string[] nullStrings = null;
            string[] emptyStrings = { };

            try
            {
                result = UseDelegate(lambdaConcatenate, nullStrings);
                Console.WriteLine($"Объединенная строка (null): {result}");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Ошибка для null массива: {ex.Message}"); 
            }

            result = UseDelegate(lambdaConcatenate, emptyStrings);
            Console.WriteLine($"Объединенная строка (пустой массив): {result}"); 
        }

       
        public static string UseDelegate(ConcatenateStringsDelegateType myDelegate, string[] strings)
        {
            if (strings == null)
            {
                throw new ArgumentNullException(nameof(strings), "Массив строк не может быть null");
            }
            return myDelegate(strings);
        }

        
        public static string Concatenate(string[] strings)
        {
            return string.Join(",", strings);
        }
    }

}
