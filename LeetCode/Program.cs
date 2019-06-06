using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //Algorithm.Simple.Reverse(10);
            //Console.WriteLine(Algorithm.Simple.RomanToInt("III"));
            //string[] strArr = { "aca","cba"};
            //Console.WriteLine(Algorithm.Simple.LongestCommonPrefix(strArr));
            Console.WriteLine(Algorithm.Simple.IsValid(")([]{}"));
            //isCJ();
            Console.ReadKey();
        }
        public static void isCJ()
        {
            List<string> A = new List<string>() { "A", "B", "C" };
            List<string> B = new List<string>() { "B", "C", "D" };
            var C = A.Union(B).ToList();
            foreach (var item in C)
            {
                Console.WriteLine(item);
            }
        }
    }
}
