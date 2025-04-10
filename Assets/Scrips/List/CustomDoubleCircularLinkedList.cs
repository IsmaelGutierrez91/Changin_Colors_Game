using UnityEngine;
using UnityEngine.InputSystem;

public class CustomDoubleCircularLinkedList : DoubleCircularLikedList<Color>
{
    [SerializeField]public Node<Color> currentColor;
}
