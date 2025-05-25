using System.Collections;
using System.Threading.Tasks;

namespace NeetCode.Stack
{
    public class EvalRPNSolution
    {
        //https://neetcode.io/problems/evaluate-reverse-polish-notation
        public int EvalRPN(string[] tokens)
        {
            var stack = new Stack<int>();

            var result = 0;

            foreach (var token in tokens)
            {

                if (int.TryParse(token, out var value))
                {
                    stack.Push(value);
                }
                else
                {
                    int b_value = stack.Pop();
                    int a_value = stack.Pop();
                    var op = token;

                    var backToTheStack = Evaluate(a_value, b_value, op);

                    stack.Push(backToTheStack);
                }
            }

            if (stack.Count > 0)
            {
                result = stack.Pop();
            }

            return result;
        }

        private int Evaluate(int a, int b, string op)
        {
            if (op == "+")
            {
                return a + b;
            }
            else if (op == "-")
            {
                return a - b;
            }
            else if (op == "*")
            {
                return a * b;
            }
            else if (op == "/")
            {
                return a / b;
            }

            throw new Exception();
        }

        [Fact]
        public async Task Test1()
        {
            Assert.Equal(5, EvalRPN(new string[]{ "1", "2", "+", "3", "*", "4", "-" }));
        }
    }
}