using System;

namespace BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new BalancedParanthesesSolve();

            var arr = new string[] { "{", "}", "(", ")", "[", "]" };

            Console.WriteLine(input.AreBalanced(arr));

        
        }
    }
}
