using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace NeetCode.HashTable
{
    public class RomanToIntSolution
    {
        public Dictionary<string, int> _lookup = new Dictionary<string, int>
        {
            { "I",  1 },
            { "IV", 4 },
            { "V",  5 },
            { "IX", 9 },
            { "X",  10 },
            { "XL", 40 },
            { "L",  50 },
            { "XC", 90 },
            { "C",  100 },
            { "CD", 400 },
            { "D",  500 },
            { "CM", 900 },
            { "M", 1000 },
        };


        //Starting with 1000 - Subtract 1000 from the input, and add its key.
        //Go until 0.
        public int RomanToInt(string s)
        {
            var result = 0;

            var romanNumeral = s;
            while (!string.IsNullOrEmpty(romanNumeral))
            {
                foreach (var key in _lookup.Keys.Reverse())
                    if (romanNumeral.StartsWith(key))
                    {
                        result += _lookup[key];
                        romanNumeral = romanNumeral.Substring(key.Length);
                        break;
                    }
            }

            return result;
        }
    }
}