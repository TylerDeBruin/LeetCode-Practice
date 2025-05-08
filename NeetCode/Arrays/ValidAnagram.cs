using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using ExpectedObjects;
using NeetCode.LinkedList;

namespace NeetCode.Arrays
{
    public class TwoArraysSolution
    {
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;

            var s_charDictionary = new Dictionary<char, int>();
            var t_charDictionary = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if(!s_charDictionary.ContainsKey(s[i]))
                {
                    s_charDictionary.Add(s[i], 1);
                }
                else
                {
                    s_charDictionary[s[i]]++;
                }

                if (!t_charDictionary.ContainsKey(t[i]))
                {
                    t_charDictionary.Add(t[i], 1);

                }
                else
                {
                    t_charDictionary[t[i]]++;
                }
            }

            var allValues = new HashSet<char>(s_charDictionary.Keys);

            allValues.UnionWith(t_charDictionary.Keys);

            foreach(var key in allValues)
            {
                s_charDictionary.TryGetValue(key, out int value1);
                t_charDictionary.TryGetValue(key, out int value2);

                if (value1 != value2)
                    return false;
                 
            }

            return true;
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