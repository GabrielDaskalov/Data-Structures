using System;
using System.Collections.Generic;
using System.Text;

namespace BalancedParentheses
{
    public class BalancedParanthesesSolve : ISolvable
    {
        public bool AreBalanced(string[] arr)
        {
            char[] firstCouple = new char[] { '{', '}' };
            char[] secondCouple = new char[] { '[', ']' };
            char[] thirdCouple = new char[] { '(', ')' };


            int balancedCouples = 0;

            for (int i = 0; i < arr.Length / 2; i++)
            {
                for (int j = arr.Length / 2; j < arr.Length; j++)
                {
                    if (i + j == arr.Length - 1)
                    {
                        if (arr[i] == firstCouple[0].ToString() ||
                            arr[i] == secondCouple[0].ToString() ||
                            arr[i] == thirdCouple[0].ToString())
                        {
        
                           CheckCouples(arr, firstCouple, secondCouple, thirdCouple, ref balancedCouples, i, j);

                        }
                        
                    }

                }

            }

            bool areBalanced = balancedCouples == arr.Length / 2;

            return areBalanced;
        }

        private static void CheckCouples(string[] arr, char[] firstCouple, char[] secondCouple, char[] thirdCouple,  ref int balancedCouples , int i, int j)
        {
            switch (arr[i])
            {
                case "{":
                    if (arr[j] == firstCouple[1].ToString())
                    {
                        balancedCouples++;
                    }
                 
                    break;
                case "[":
                    if (arr[j] == secondCouple[1].ToString())
                    {
                        balancedCouples++;
                    }
                 
                    break;
                case "(":
                    if (arr[j] == thirdCouple[1].ToString())
                    {
                        balancedCouples++;
                    }
                    
                    break;
            }
        }
    }
}
