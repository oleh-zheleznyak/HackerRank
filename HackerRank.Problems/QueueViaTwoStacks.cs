namespace HackerRank.Problems;

public class QueueViaTwoStacks<T>
{
    private Stack<T>? stack = new();
    private Stack<T>? reversedStack = null;

    public void Enqueue(T value)
    {
        if (stack == null) stack = Reverse(reversedStack);
        stack.Push(value);
        reversedStack = null;
    }
    public T Dequeue()
    {
        if (reversedStack == null) reversedStack = Reverse(stack);
        stack = null;
        return reversedStack.Pop();
    }

    public T Peek()
    {
        if (reversedStack == null) reversedStack = Reverse(stack);
        stack = null;
        return reversedStack.Peek();
    }

    private static Stack<T> Reverse(Stack<T>? stack)
    {
        if (stack is null) throw new ArgumentNullException(nameof(stack));
        var reversedStack = new Stack<T>(stack.Count);
        while (stack.Count > 0) reversedStack.Push(stack.Pop());
        return reversedStack;
    }
}
