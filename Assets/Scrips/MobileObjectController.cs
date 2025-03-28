using UnityEngine;

public class MobileObjectController : MonoBehaviour
{
    [SerializeField] float objectSpeed;
    [Header("Values in X")]
    [SerializeField] int directionX = 1;
    [SerializeField] float maxX;
    [SerializeField] float minX;
    [Header("Values in Y")]
    [SerializeField] int directionY = 1;
    [SerializeField] float maxY;
    [SerializeField] float minY;
    Rigidbody2D _componentRigidbody2D;
    private void Awake()
    {
        _componentRigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (_componentRigidbody2D.position.x <= minX)
        {
            directionX = 1;
        }
        if (_componentRigidbody2D.position.x >= maxX)
        {
            directionX = -1;
        }
        if (_componentRigidbody2D.position.y <= minX)
        {
            directionY = 1;
        }
        if (_componentRigidbody2D.position.y >= maxY)
        {
            directionY = -1;
        }
    }
    private void FixedUpdate()
    {
        _componentRigidbody2D.linearVelocity = new Vector2(directionX * objectSpeed, directionY * objectSpeed);
    }

}
