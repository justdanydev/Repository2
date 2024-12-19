using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    using System;
    using System.Linq;

    public class MaxValueDelegate
    {
       
        public delegate int MaxValueDelegateType(int[] arr);

        public static void Main(string[] args)
        {
            int[] numbers = { 10, 5, 20, 15, 3, 25 };

            
            MaxValueDelegateType findMaxDelegate = FindMax;

            
            int max = UseDelegate(findMaxDelegate, numbers);

            Console.WriteLine($"Максимальное значение: {max}"); 


            
            MaxValueDelegateType lambdaFindMax = arr => arr.Max();
            max = UseDelegate(lambdaFindMax, numbers);
            Console.WriteLine($"Максимальное значение (лямбда-выражение): {max}"); 

            
            int[] emptyArray = { };
            try
            {
                max = UseDelegate(lambdaFindMax, emptyArray);
                Console.WriteLine($"Максимальное значение (пустой массив): {max}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Ошибка для пустого массива: {ex.Message}"); 
            }
        }

        
        public static int UseDelegate(MaxValueDelegateType myDelegate, int[] arr)
        {
            return myDelegate(arr);
        }

       
        public static int FindMax(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                throw new ArgumentException("Массив не может быть null или пустым.");
            }
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            return max;
        }
    }

}
