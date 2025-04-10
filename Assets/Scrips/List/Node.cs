using UnityEngine;

public class Node <T>
{
    private T value;
    private Node<T> next;
    private Node<T> prev;

    public T Value => value;
    public Node<T> Next => next;
    public Node<T> Prev => prev;

    public Node(T value)
    {
        this.value = value;
        this.next = null;
    }
    public void SetNext(Node<T> next)
    {
        this.next = next;
    }
    public void SetPrev(Node<T> prev)
    {
        this.prev = prev;
    }
}
