namespace HackerRank.Problems;

public class QueueViaTwoStacks<T>
{
    private Stack<T>? stack = new();
    private Stack<T>? reversedStack = new();

    public void Enqueue(T value)
    {
        stack.Push(value);
    }
    public T Dequeue()
    {
        if (reversedStack.Count == 0) ReFillReversedStack();
        return reversedStack.Pop();
    }

    public T Peek()
    {
        if (reversedStack.Count == 0) ReFillReversedStack();
        return reversedStack.Peek();
    }

    private void ReFillReversedStack()
    {
        while (stack.Count > 0) reversedStack.Push(stack.Pop());
    }
}
