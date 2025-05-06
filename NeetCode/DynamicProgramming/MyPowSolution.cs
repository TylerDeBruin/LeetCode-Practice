namespace NeetCode.DynamicProgramming
{
    public class MyPowSolution
    {
        //https://neetcode.io/problems/pow-x-n
        //Take n, divide it by half - and throw away half the work. 
        //Round the result to match the expected.
        public double MyPow(double x, int n)
        {
            var result = Factor(x, n);

            if (n < 0)
                return Math.Round(1 / result, 5);

            return Math.Round(result, 5);
        }

        private double Factor(double x, int n)
        {
            if (x == 0)
                return 0;

            if (n == 0)
                return 1;

            var result = Factor(x, n / 2);

            result *= result;

            if(n % 2 != 0)
                return result * x;

            return result;
        }



        [Fact]
        public void Test1()
        {
            var expected = 32.00000;

            var actual = MyPow(2, 5);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test2()
        {
            var expected = 2.59374;

            var actual = MyPow(1.1, 10);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test3()
        {
            var expected = 0.12500;

            var actual = MyPow(2, -3);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test4()
        {
            var expected = 54.83508;

            var actual = MyPow(0.44894, -5);

            Assert.Equal(expected, actual);
        }
    }
}