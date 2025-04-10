using UnityEngine;
using UnityEngine.UIElements;

public class MobileObjectController : MonoBehaviour
{
    [SerializeField] float objectSpeed;
    [Header("Values in X")]
    [SerializeField] int directionX;
    [SerializeField] float maxX;
    [SerializeField] float minX;
    [Header("Values in Y")]
    [SerializeField] int directionY;
    [SerializeField] float maxY;
    [SerializeField] float minY;
    [SerializeField] PlayerController _Player;
    Transform _componentTransfrom;
    SpriteRenderer _componentSpriteRenderer;
    BoxCollider2D _componentBoxCollider2D;

    SpriteRenderer _PlayerSR;
    private void Awake()
    {
        _componentTransfrom = GetComponent<Transform>();
        _componentBoxCollider2D = GetComponent<BoxCollider2D>();
        _componentSpriteRenderer = GetComponent<SpriteRenderer>();
        _PlayerSR = _Player.gameObject.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        //Direction changer
        if (_componentTransfrom.position.x < minX)
        {
            directionX = +1;
        }
        if (_componentTransfrom.position.x > maxX)
        {
            directionX = -1;
        }
        if (_componentTransfrom.position.y < minY)
        {
            directionY = +1;
        }
        if (_componentTransfrom.position.y > maxY)
        {
            directionY = -1;
        }
        //Position controller
        if (_PlayerSR.color != _componentSpriteRenderer.color)
        {
            _componentTransfrom.position = new Vector2(_componentTransfrom.position.x + directionX * objectSpeed * Time.deltaTime, _componentTransfrom.position.y + directionY * objectSpeed * Time.deltaTime);
        }
        //Collision modificator
        if (this.gameObject.name == "Obstacle")
        {
            if (_Player.GetComponent<SpriteRenderer>().color == _componentSpriteRenderer.color)
            {
                _componentBoxCollider2D.isTrigger = true;
            }
            else
            {
                _componentBoxCollider2D.isTrigger = false;
            }
        }
        else if (this.gameObject.name == "MobileEnemy")
        {
            _componentBoxCollider2D.isTrigger = true;
        }
    }
}
