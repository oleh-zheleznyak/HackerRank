using System.Collections;

namespace HackerRank.Problems;

public class MinHeap2<T> : IReadOnlyCollection<T>
    where T: IComparable<T>
{
    private readonly IComparer<T> _comparer;
    private T[] _storage;
    private int _count;
    
    public MinHeap2(IReadOnlyCollection<T> data, IComparer<T>? comparer = null)
    {
        _comparer = comparer ?? Comparer<T>.Default;
        _storage = data.ToArray();
    }

    public T PopMin()
    {
        AssertNotEmpty();
        var min = _storage[0];
        Swap(0, _count-1);
        _count--;
        RestoreHeapProperty(0);
        return min;
    }

    public T PeekMin()
    {
        AssertNotEmpty();
        return _storage[0];
    }

    public void Push(T value)
    {
        EnsureCapacity();
        _storage[_count] = _storage[0];
        _storage[0] = value;
        _count++;
        RestoreHeapProperty(0);
    }

    private void Swap(int i, int j) =>
        (_storage[i], _storage[j]) = (_storage[j], _storage[i]);
    
    private void RestoreHeapProperty(int index)
    {
        if (index>=_count) return;
        var leftIndex = LeftChildIndex(index);
        var rightIndex = RightChildIndex(index);

        var value = _storage[index];
        int smallest = index;

        if (leftIndex < _count && _comparer.Compare(_storage[leftIndex], value) < 0) smallest = leftIndex;
        if (rightIndex < _count && _comparer.Compare(_storage[rightIndex], _storage[smallest]) < 0)
            smallest = rightIndex;

        if (smallest != index)
        {
            Swap(smallest, index);
            RestoreHeapProperty(smallest);
        }
    }

    // TODO - can be represented as bit operations
    private int ParentIndex(int index) => (index-1) / 2;
    private int LeftChildIndex(int index) => index * 2 +1 ;
    private int RightChildIndex(int index) => index * 2 + 2;

    private void EnsureCapacity() // this could be delegated to List<T>
    {
        if (_count == _storage.Length)
        {
            var tmp = new T[_count * 2];
            Array.Copy(_storage, tmp, _count);
            _storage = tmp;
        }
    }
    
    private void AssertNotEmpty()
    {
        if (Count == 0) throw new InvalidOperationException("min heap is empty");
    }
    
    public IEnumerator<T> GetEnumerator() => _storage.Take(_count).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public int Count => _count;
}