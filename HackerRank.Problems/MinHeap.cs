namespace HackerRank.Problems
{
    public class MinHeap<T> where T: IComparable<T>
    {
        private T[] _storage;
        private int _count;
        private IComparer<T> comparer = Comparer<T>.Default; // todo: ability to supply via ctor

        public MinHeap(IReadOnlyCollection<T> data)
        {
            if (data is null) throw new ArgumentNullException(nameof(data));
            _count = data.Count;
            _storage = data.ToArray();
            BuildMinHeap();
        }

        public MinHeap(int capacity)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException(nameof(capacity));

            _storage = new T[capacity];
            _count = 0;
        }

        public int Count => _count; 

        private void BuildMinHeap()
        {
            var n = _count / 2;
            for (var i = n; i >= 0; i--)
                RestoreHeapProperty(i);
        }

        public T Peek() => _count > 0 ? _storage[0] : throw new InvalidOperationException("heap is empty");

        public T Pop()
        {
            if (_count <= 0) throw new InvalidOperationException("heap is empty");
            var value = _storage[0];
            _storage[0] = _storage[_count - 1];
            _count--;
            RestoreHeapProperty(0);
            return value;
        }
        
        public void Push(T value)
        {
            if (_count >= _storage.Length-1) throw new NotImplementedException("resizing not implemented");
            _storage[_count] = value;
            Swap(0, _count);
            _count++;
            RestoreHeapProperty(0);
        }

        private void RestoreHeapProperty(int index)
        {
            var value = _storage[index];

            var leftIndex = LeftChild(index);
            var rightIndex = RightChild(index);
            int? nextIndex = null;

            if (leftIndex < _count && comparer.Compare(_storage[leftIndex], value) < 0) nextIndex = leftIndex;
            else if (rightIndex < _count && comparer.Compare(_storage[rightIndex], value) < 0) nextIndex = rightIndex;

            if (nextIndex.HasValue)
            {
                Swap(nextIndex.Value, index);
                RestoreHeapProperty(nextIndex.Value);
            }
        }

        private int Parent(int index) => index >> 1;
        private int LeftChild(int index) => index >> 1;
        private int RightChild(int index) => index >> 1+1;
        private void Swap(int i, int j)
        {
            var temp = _storage[i];
            _storage[i] = _storage[j];
            _storage[j] = temp;
        }
    }
}
