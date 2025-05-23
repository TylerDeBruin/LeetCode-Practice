using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCode.WarmUps
{
    public class WarmUps
    {
        public string getWrongAnswers(int N, string C)
        {
            var result = new StringBuilder();

            foreach (var item in C)
            {
                if(item == 'A')
                    result.Append('B');

                else if (item == 'B')
                    result.Append('A');
            }

            return result.ToString();
        }


        public double getHitProbability(int R, int C, int[,] G)
        {
            int total = R * C;

            int encountered = 0;

            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    encountered += G[i, j];
                }
            }

            return Math.Round( (double)encountered / total, 6);
        }

        //K - distancing
        //
        public long getMaxAdditionalDinersCount(long N, long K, int M, long[] S)
        {

            var sorted = S.OrderBy(x => x).ToArray();

            var totalSpots = 0L;

            for(int i = 0; i < S.Length; i++)
            {
                //First in the array, Compare to 0 and n+1
                if( i == 0 )
                {
                    //Spots between 0 and i
                    var totalBetweenZero = (sorted[i] - 1) / (K*2);

                    totalSpots+= Math.Max(0, totalBetweenZero);
                }

                if( i == S.Length - 1)
                {
                    var totalBetweenZero = (N - sorted[i] - 1) / (K * 2);

                    totalSpots += Math.Max(0, totalBetweenZero);

                    break;
                }

                //Calculate the Spots between n, and n+1
                totalSpots += (sorted[i + 1] - sorted[i]) / (K * 2);
            }

            return totalSpots;
        }


        [Fact]
        public async Task getMaxAdditionalDinersCount_1()
        {
            var result = getMaxAdditionalDinersCount(10, 1, 2, new long[] { 2, 6 });

            Assert.Equal(3, result);
        }

        [Fact]
        public async Task getMaxAdditionalDinersCount_2()
        {
            var result = getMaxAdditionalDinersCount(15, 2, 3, new long[] { 11, 6, 14 });

            Assert.Equal(1, result);
        }


        [Fact]
        public async Task ArrayTest()
        {
            var result = new int[] { 1, 2, 3, 4, 5 };

            var expected = result.Skip(1).Take(3);
        }
    }



} 
