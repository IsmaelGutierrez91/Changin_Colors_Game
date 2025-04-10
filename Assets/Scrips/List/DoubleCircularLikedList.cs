using UnityEngine;

public class DoubleCircularLikedList<T> : MonoBehaviour
{
    private Node<T> Head;
    public Node<T> _Head => Head;
    public virtual void Add(T value)
    {
        Node<T> newValue = new Node<T>(value);
        if (Head == null)
        {
            Head = newValue;
            return;
        }
        Node<T> Last = Head.Prev;

        Last.SetNext(newValue);
        newValue.SetPrev(Last);
        newValue.SetNext(Head);
        Head.SetPrev(newValue);
    }
}
