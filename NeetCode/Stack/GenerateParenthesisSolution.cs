using System.Collections;
using System.Text;
using System.Threading.Tasks;

namespace NeetCode.Stack
{
    public class GenerateParenthesisSolution
    {
        //https://neetcode.io/problems/generate-parentheses
        public List<string> GenerateParenthesis(int n)
        {
            //Recursive tree - where you start with a (, and you take different combinations.
            //Need a total of N open, and N Close. Can only add a Close if the number of close is less than the number of add.
            var result = new List<string>();

            Generate(n, 1, 0, "(", result);

            return result;
        }

        private void Generate(int n, int openN, int closeN, string subset, List<string> result)
        {
            if (openN == closeN && openN == n)
            {
                result.Add(subset);
                return;
            }

            if (openN < n)
            {
                Generate(n, openN + 1, closeN, subset + "(", result);
            }

            if (closeN < openN)
            {
                Generate(n, openN, closeN + 1, subset + ")", result);
            }
        }

        [Fact]
        public void Test1()
        {
            var actual = GenerateParenthesis(1);
        }


    }
}