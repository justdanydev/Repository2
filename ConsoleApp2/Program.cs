using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    using System;

    public class StringLengthDelegate
    {
      
        public delegate int StringLengthDelegateType(string str);

        public static void Main(string[] args)
        {
            
            StringLengthDelegateType getLengthDelegate = GetStringLength;

            
            int length = UseDelegate(getLengthDelegate, "Привет, мир!");

            Console.WriteLine($"Длина строки: {length}"); 

          
            StringLengthDelegateType lambdaGetLength = str => str.Length;
            length = UseDelegate(lambdaGetLength, "Hello, world!");
            Console.WriteLine($"Длина строки (лямбда-выражение): {length}"); 

        }

       
        public static int UseDelegate(StringLengthDelegateType myDelegate, string str)
        {
            return myDelegate(str);
        }

        
        public static int GetStringLength(string str)
        {
            return str.Length;
        }
    }

}
