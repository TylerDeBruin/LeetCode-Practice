using System.Collections;
using System.Threading.Tasks;

namespace NeetCode.TwoPointers
{
    public class MinStackSolution
    {
        //https://neetcode.io/problems/minimum-stack
        public class MinStack
        {
            private readonly LinkedList<int> _linkedList;
            private readonly SortedList<int, int> _minimumElements;

            public MinStack()
            {
                _linkedList = new LinkedList<int>();
                _minimumElements = new SortedList<int, int>();
            }

            public void Push(int val)
            {
                _linkedList.AddFirst(val);

                if (_minimumElements.ContainsKey(val))
                {
                    _minimumElements[val]++;
                }
                else
                {
                    _minimumElements.Add(val, 1);
                }
            }

            public void Pop()
            {
                if (_linkedList.Count > 0)
                {
                    var result = _linkedList.First.Value;

                    if (_minimumElements.ContainsKey(result))
                    {
                        _minimumElements[result]--;

                        if (_minimumElements[result] <= 0)
                        {
                            _minimumElements.Remove(result);
                        }
                    }

                    _linkedList.RemoveFirst();

                    return;
                }

                throw new Exception("Stack must have 1 element.");
            }

            public int Top()
            {
                if (_linkedList.Count > 0)
                {
                    var result = _linkedList.First.Value;

                    return result;
                }

                throw new Exception("Stack must have 1 element.");
            }

            public int GetMin()
            {
                if (_linkedList.Count > 0)
                {
                    return _minimumElements.GetKeyAtIndex(0);
                }

                throw new Exception("Stack must have 1 element.");
            }
        }
    }
}