using System.Threading.Tasks;

namespace NeetCode.TwoPointers
{
    public class MaxProfitSolution
    {
        //https://neetcode.io/problems/buy-and-sell-crypto
        public int MaxProfit(int[] prices)
        {
            var pointerLeft = 0;
            var pointerRight = 1;

            var result = 0;

            while (pointerRight < prices.Length)
            {
                if (prices[pointerRight] < prices[pointerLeft])
                {
                    pointerLeft = pointerRight;
                }
                else
                {
                    result = Math.Max(prices[pointerRight] - prices[pointerLeft], result);
                }

                pointerRight++;
            }

            return result;
        }
    }
}