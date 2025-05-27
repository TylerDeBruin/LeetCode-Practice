using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace NeetCode.HashTable
{
    public class IntToRomanSolution
    {
        public Dictionary<int, string> _lookup = new Dictionary<int, string>
        {
            { 1, "I"},
            { 4, "IV"},
            { 5, "V"},
            { 9, "IX"},
            { 10, "X"},
            { 40, "XL"},
            { 50, "L"},
            { 90, "XC"},
            { 100, "C"},
            { 400, "CD"},
            { 500, "D"},
            { 900, "CM"},
            { 1000, "M"},
        };

        //Starting with 1000 - Subtract 1000 from the input, and add its key.
        //Go until 0.
        public string IntToRoman(int num)
        {

            StringBuilder stringBuilder = new StringBuilder();

            foreach(var key in _lookup.Keys.OrderByDescending(x => x))
            {
                while (num >= key)
                {
                    stringBuilder.Append(_lookup[key]);
                    num -= key;
                }
            }

            return stringBuilder.ToString();
        }
    }
}