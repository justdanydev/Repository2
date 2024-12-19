using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    using System;

    public class ProductDelegate
    {
        
        public delegate double ProductDelegateType(double a, double b);

        public static void Main(string[] args)
        {
            
            ProductDelegateType calculateProductDelegate = CalculateProduct;

            
            double product = UseDelegate(calculateProductDelegate, 10.5, 2.2);

            Console.WriteLine($"Произведение: {product}"); 


           
            ProductDelegateType lambdaProduct = (a, b) => a * b;
            product = UseDelegate(lambdaProduct, 5.7, 3.1);
            Console.WriteLine($"Произведение (лямбда-выражение): {product}"); 
        }

       
        public static double UseDelegate(ProductDelegateType myDelegate, double num1, double num2)
        {
            return myDelegate(num1, num2);
        }

       
        public static double CalculateProduct(double a, double b)
        {
            return a * b;
        }
    }

}
