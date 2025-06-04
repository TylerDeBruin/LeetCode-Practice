using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace NeetCode.Greedy
{
    public class MinRemoveToMakeValidSolution
    {
        //https://leetcode.com/problems/minimum-remove-to-make-valid-parentheses/?envType=company&envId=facebook&favoriteSlug=facebook-thirty-days
        public string MinRemoveToMakeValid(string s)
        {
            //Iterate through the string, matching parentheses and popping when they match.
            var stack = new Stack<int>();

            var invalidIndex = new HashSet<int>();

            for( int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else if (s[i] == ')')
                {
                    if(stack.Count > 0)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        invalidIndex.Add(i);
                    }
                }
            }

            //When done, there might still be '(' left. Add them to the list of bad indexes.
            while(stack.Count > 0)
            {
                var badOpen = stack.Pop();

                invalidIndex.Add(badOpen);
            }

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                if(!invalidIndex.Contains(i))
                    result.Append(s[i]);
            }

            return result.ToString();
        }

    }
}