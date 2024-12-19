using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    using System;
    using System.Linq;

    public class PalindromeDelegate
    {
        
        public delegate bool IsPalindromeDelegateType(string str);

        public static void Main(string[] args)
        {
            
            IsPalindromeDelegateType isPalindromeDelegate = IsPalindrome;

            
            string[] testStrings = { "racecar", "hello", "madam", "level", "rotor", "A man, a plan, a canal: Panama" };

            foreach (string str in testStrings)
            {
                bool result = UseDelegate(isPalindromeDelegate, str);
                Console.WriteLine($"'{str}' is a palindrome: {result}");
            }

            
            IsPalindromeDelegateType lambdaIsPalindrome = str => {
                string cleanStr = new string(str.Where(c => char.IsLetterOrDigit(c)).ToArray()).ToLower();
                return string.Equals(cleanStr, new string(cleanStr.Reverse().ToArray()));
            };


            foreach (string str in testStrings)
            {
                bool result = UseDelegate(lambdaIsPalindrome, str);
                Console.WriteLine($"'{str}' is a palindrome (лямбда-выражение): {result}");
            }

            
            string nullString = null;
            try
            {
                bool result = UseDelegate(lambdaIsPalindrome, nullString);
                Console.WriteLine($"'{nullString}' is a palindrome (лямбда-выражение): {result}");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Ошибка для null строки: {ex.Message}"); 
            }
        }

        
        public static bool UseDelegate(IsPalindromeDelegateType myDelegate, string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str), "Строка не может быть null");
            }
            return myDelegate(str);
        }

        
        public static bool IsPalindrome(string str)
        {
            string cleanStr = new string(str.Where(c => char.IsLetterOrDigit(c)).ToArray()).ToLower(); 
            return string.Equals(cleanStr, new string(cleanStr.Reverse().ToArray()));
        }
    }

}
