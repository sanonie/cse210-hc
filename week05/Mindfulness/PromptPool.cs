using System;
using System.Collections.Generic;

namespace Mindfulness
{
    public class PromptPool<T>
    {
        private readonly List<T> _allItems;
        private readonly Random _rng = new Random();
        private List<T> _remaining;

        public PromptPool(IEnumerable<T> items)
        {
            _allItems = new List<T>(items);
            _remaining = new List<T>(_allItems);
        }

        public T GetNext()
        {
            if (_remaining.Count == 0)
            {
                _remaining = new List<T>(_allItems);
            }

            var index = _rng.Next(_remaining.Count);
            var item = _remaining[index];
            _remaining.RemoveAt(index);
            return item;
        }
    }
}
