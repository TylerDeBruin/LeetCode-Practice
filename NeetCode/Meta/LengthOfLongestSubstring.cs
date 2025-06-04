using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCode.Meta
{
    public class LengthOfLongestSubstringSolution
    {
        //https://leetcode.com/problems/longest-substring-without-repeating-characters/submissions/1646204106/?envType=company&envId=facebook&favoriteSlug=facebook-thirty-days
        //Create a left pointer - and a right pointer (i). 
        //Loop through all characters - add each value to the hashset. If you encounter one you've already seen, move the pointer up to remove that character in the wiondow.
        public int LengthOfLongestSubstring(string s)
        {
            var hashSet = new HashSet<char>();

            var left = 0;
            var result = 0;

            for (int i = 0; i < s.Length; i++)
            {
                char viewed = s[i];

                // Shrink the window until the duplicate is gone
                while (hashSet.Contains(viewed))
                {
                    hashSet.Remove(s[left]);
                    left++;
                }

                hashSet.Add(viewed);
                result = Math.Max(result, i - left + 1);
            }

            return result;
        }
    }

} 
