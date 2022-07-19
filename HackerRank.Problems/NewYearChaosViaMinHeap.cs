namespace HackerRank.Problems;

public class NewYearChaosViaMinHeap: INewYearChaos
{
    public int? CalculateNumberOfBribes(IList<int> shuffeledQueue)
    {
        var minHeap = new MinHeap<int>(shuffeledQueue.Count+1);
        minHeap.Push(shuffeledQueue[shuffeledQueue.Count - 1]);

        var sum = 0;
        var stack = new Stack<int>(3);
        for (int i = shuffeledQueue.Count-2; i >=0; i--)
        {
            var counter = 0;
            var value = shuffeledQueue[i];
            while (minHeap.Count>0 && value > minHeap.Peek())
            {
                var removed = minHeap.Pop();
                stack.Push(removed);
                counter++;
                if (counter > 2) return null;
            }
            sum += counter;
            minHeap.Push(value);
            while (stack.Count > 0) minHeap.Push(stack.Pop());
        }
        return sum;
    }
}
