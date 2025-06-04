using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Globalization;
using ExpectedObjects;
using NeetCode.LinkedList;

namespace NeetCode.Meta
{
    public class GroupAnagramsSolution
    {
        //https://leetcode.com/problems/group-anagrams/
        public IList<IList<string>> GroupAnagrams(string[] strs)
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

            var result = new List<IList<string>>();

            foreach (string str in lookup.Keys)
            {
                result.Add(lookup[str]);
            }

            return result;
        }
    }
}