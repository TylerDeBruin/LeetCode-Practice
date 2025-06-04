using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCode.BinaryTreeDepthSolution
{
    public class MyAtoiSolution
    {
        //https://leetcode.com/problems/string-to-integer-atoi/
        public int MyAtoi(string s)
        {
            int sign = 1;
            string parsedString = s;

            while (parsedString.StartsWith(" "))
            {
                parsedString = parsedString.Substring(1);
            }

            if (parsedString.StartsWith("-"))
            {
                sign = -1;
                parsedString = parsedString.Substring(1);
            }
            else if (parsedString.StartsWith("+"))
            {
                parsedString = parsedString.Substring(1);
            }

            var right = 0;
            long number = 0;
            while (right < parsedString.Length && char.IsDigit(parsedString[right]))
            {
                //Shift the digits to the left by multiplying by 10, add the next digit.
                number = (number * 10) + (int.Parse(parsedString[right].ToString()));

                if (sign == 1 && number > int.MaxValue)
                    return int.MaxValue;
                if (sign == -1 && -number < int.MinValue)
                    return int.MinValue;

                right++;
            }

            return (int)(sign * number);
        }
    }


} 
