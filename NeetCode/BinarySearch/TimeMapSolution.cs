using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using System.Collections.Generic;

namespace NeetCode.BinarySearch
{
    public class TimeMapSolution
    {
        private readonly Dictionary<string, SortedList<int, string>> _lookup;

        public TimeMapSolution()
        {
            _lookup = new Dictionary<string, SortedList<int, string>>();
        }

        public void Set(string key, string value, int timestamp)
        {
            if (_lookup.ContainsKey(key))
            {
                if (_lookup[key].ContainsKey(timestamp))
                {
                    _lookup[key][timestamp] = value;
                }
                else
                {
                    _lookup[key].Add(timestamp, value);
                }
            }
            else
            {
                _lookup.Add(key, new SortedList<int, string>()
                {
                    {timestamp, value}
                });
            }
        }

        public string Get(string key, int timestamp)
        {
            string result = "";

            if (_lookup.ContainsKey(key))
            {
                var timestamps = _lookup[key];

                var left = 0;
                var right = timestamps.Count - 1;

                while (left <= right)
                {
                    var mid = (int)Math.Floor(((double) left + right) / 2);

                    var timeStampvalue = timestamps.Keys[mid];

                    if (timeStampvalue == timestamp)
                        return timestamps.Values[mid];

                    if (timestamps.Keys[mid] < timestamp)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }

                if (right >= 0)
                {
                    result = timestamps.Values[right];
                }
            }

            return result;
        }

        [Fact]
        public void Task1()
        {
            TimeMapSolution timeMap = new TimeMapSolution();
            timeMap.Set("key1", "value1", 10);  // store the key "alice" and value "happy" along with timestamp = 1.
            var a = timeMap.Get("key1", 1);           // return "happy"
            var b = timeMap.Get("key1", 10);           // return "happy", there is no value stored for timestamp 2, thus we return the value at timestamp 1.
            var c = timeMap.Get("key1", 11);

            Assert.Equal(a, "");
            Assert.Equal(b, "value1");
            Assert.Equal(c, "value1");
        }

    }
}