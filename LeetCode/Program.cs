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
            string[] strArr = { "aca","cba"};
            Console.WriteLine(Algorithm.Simple.LongestCommonPrefix(strArr));
            Console.ReadKey();
        }
    }
}
