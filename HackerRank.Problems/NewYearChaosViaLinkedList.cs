namespace HackerRank.Problems;

public class NewYearChaosViaLinkedList : INewYearChaos
{
    public int? CalculateNumberOfBribes(IList<int> shuffeledQueue)
    {
        var numbers = Enumerable.Range(1, shuffeledQueue.Count).Reverse().ToArray();
        var linkedList = new LinkedList<int>(shuffeledQueue);
        var sum = 0;

        foreach (var valueToSeek in numbers)
        {
            var counter = 0;
            var current = linkedList.Last;
            while (current != null && current.Value != valueToSeek)
            {
                current = current.Previous;
                counter++;

                if (counter >= 3) return null;
            }
            linkedList.Remove(current);

            sum += counter;
        }

        return sum;
    }
}
