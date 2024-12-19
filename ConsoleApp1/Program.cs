using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    using System;
    using System.Linq;

    public class AverageDelegate
    {
       
        public delegate double AverageDelegateType(int[] numbers);

        public static void Main(string[] args)
        {
            int[] numbers1 = { 1, 2, 3, 4, 5 };
            int[] numbers2 = { 10, 20, 30, 40, 50 };
            int[] emptyNumbers = { };
            int[] nullNumbers = null;

            
            AverageDelegateType averageDelegate = CalculateAverage;

            
            try
            {
                double avg1 = UseDelegate(averageDelegate, numbers1);
                Console.WriteLine($"Среднее значение массива numbers1: {avg1}"); 

                double avg2 = UseDelegate(averageDelegate, numbers2);
                Console.WriteLine($"Среднее значение массива numbers2: {avg2}"); 

                double avg3 = UseDelegate(averageDelegate, emptyNumbers);
                Console.WriteLine($"Среднее значение пустого массива: {avg3}"); 

                double avg4 = UseDelegate(averageDelegate, nullNumbers);
                Console.WriteLine($"Среднее значение null массива: {avg4}");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}"); 
            }



            //Использование лямбда-выражения
            AverageDelegateType lambdaAverage = numbers => numbers.Length == 0 ? 0 : numbers.Average();

            try
            {
                double lambdaAvg1 = UseDelegate(lambdaAverage, numbers1);
                Console.WriteLine($"Среднее значение массива numbers1 (лямбда): {lambdaAvg1}"); 

                double lambdaAvg2 = UseDelegate(lambdaAverage, numbers2);
                Console.WriteLine($"Среднее значение массива numbers2 (лямбда): {lambdaAvg2}"); 
                double lambdaAvg3 = UseDelegate(lambdaAverage, emptyNumbers);
                Console.WriteLine($"Среднее значение пустого массива (лямбда): {lambdaAvg3}"); 

                double lambdaAvg4 = UseDelegate(lambdaAverage, nullNumbers);
                Console.WriteLine($"Среднее значение null массива (лямбда): {lambdaAvg4}");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}"); 
            }
        }

        
        public static double UseDelegate(AverageDelegateType myDelegate, int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers), "Массив чисел не может быть null");
            }
            return myDelegate(numbers);
        }

       
        public static double CalculateAverage(int[] numbers)
        {
            if (numbers.Length == 0)
            {
                return 0; 
            }
            return numbers.Average();
        }
    }

}
