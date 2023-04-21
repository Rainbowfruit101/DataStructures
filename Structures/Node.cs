namespace Structures;

public class Node<TValue>
{
    public TValue Value { get; set; }
    public Node<TValue> Next { get; set; }
}