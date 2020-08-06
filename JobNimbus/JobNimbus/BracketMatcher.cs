using System;
using System.Collections.Generic;

namespace JobNimbus
{
    /// <summary>
    /// Class provides functionality to match brackets in a string
    /// </summary>
    public class BracketMatcher
    {
        /// <summary>
        /// Verifies if the string input has matching opening and closing brackets
        /// </summary>
        /// <param name="input">
        /// The input string to check
        /// </param>
        /// <returns>
        /// true if the brackets match. false otherwise
        /// </returns>
        public static Boolean Match(string input)
        {
            Boolean result = false;
            if (string.IsNullOrWhiteSpace(input))
            {
                return true;
            }

            if (input.StartsWith("}"))
            {
                return false;
            }

            Stack<char> stk = new Stack<char>();
            char[] arrInput = input.ToCharArray();
            for (int i = 0; i < arrInput.Length; i++)
            {
                if (arrInput[i] == '{')
                {
                    stk.Push(arrInput[i]);
                }
                if (arrInput[i] == '}')
                {
                    if (stk.Count > 0)
                    {
                        stk.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            //If we reach the end of the string and the stack has items left , means the brackets are not matching
            result = stk.Count == 0 ? true : false;

            return result;
        }
    }
}
