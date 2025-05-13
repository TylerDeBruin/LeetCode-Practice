using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Text;
using ExpectedObjects;
using NeetCode.LinkedList;

namespace NeetCode.Arrays
{
    public class EncodeAndDecodeStringSolution
    {
        public string Encode(IList<string> strs)
        {
            if (strs.Count == 0) return null;

            StringBuilder result = new StringBuilder();

            for(int i = 0; i < strs.Count; i++)
            {
                if (strs[i] != null)
                {
                    result.Append($"{strs[i]}");

                    if(i != strs.Count - 1)
                    {
                        result.Append($"{(char)004}");
                    }
                }
            }

            return result.ToString();
        }

        public List<string> Decode(string s)
        {
            if (s == null) return new List<string>();

            var result = s.Split((char)004).ToList();

            return result;
        }

        [Fact]
        public void Test1()
        {
            var input = new List<string> { "" };

            var expected = new List<string> { "" };

            var actual = Decode(Encode(input));

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Fact]
        public void Test2()
        {
            var input = new List<string> { "neet", "code", "love", "you" };

            var expected = new List<string> { "neet", "code", "love", "you" };

            var actual = Decode(Encode(input));

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Fact]
        public void Test3()
        {
            var input = new List<string> { "we", "say", ":", "yes" };

            var expected = new List<string> { "we","say",":","yes" };

            var actual = Decode(Encode(input));

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Fact]
        public void Test4()
        {
            var input = new List<string> {  };

            var expected = new List<string> { };

            var actual = Decode(Encode(input));

            expected.ToExpectedObject().ShouldMatch(actual);
        }
    }
}