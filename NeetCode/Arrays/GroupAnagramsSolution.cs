using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Globalization;
using ExpectedObjects;
using NeetCode.LinkedList;

namespace NeetCode.Arrays
{
    public class GroupAnagramsSolution
    {
        public List<List<string>> GroupAnagrams(string[] strs)
        {
            var lookup = new Dictionary<string, List<string>>();

            foreach (string str in strs)
            {
                var sorted = new string(str.ToCharArray().OrderBy(x => x).ToArray());

                if(!lookup.ContainsKey(sorted))
                {
                    lookup.Add(sorted, new List<string> { str });
                }
                else
                {
                    lookup[sorted].Add(str);
                }
            }

            var result = new List<List<string>>();

            foreach (string str in lookup.Keys)
            {
                result.Add(lookup[str]);
            }

            return result;
        }


        [Fact]
        public void Test1()
        {
            var s = "racecar";
            var t = "carrace";

            var actual = IsAnagram(s, t);

            Assert.True(actual);
        }

        [Fact]
        public void Test2()
        {
            var s = "jar";
            var t = "jam";

            var actual = IsAnagram(s, t);

            Assert.False(actual);
        }
    }
}