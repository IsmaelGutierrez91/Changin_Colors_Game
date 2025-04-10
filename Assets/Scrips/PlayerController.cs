using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [Header("Player Modifications")]
    [SerializeField] float playerSpeed;
    [SerializeField] float playerJumpStrength;
    private float horizontal;
    Rigidbody2D _componentRigidbody2D;
    SpriteRenderer _componentSpriteRenderer;
    public Image _HealBarr;
    bool canJump = false;
    bool canDoubleJump = false;
    public bool canChangeColor = true;
    bool canBeDanmaged = true;
    float cooldown = 2;

    [Header("RayCast Modifications")]
    [SerializeField] Transform originPoint;
    [SerializeField] float rayCastLength;
    [SerializeField] LayerMask layerMask;
    public Color inCollision = Color.white;
    public Color outCollision = Color.white;

    //Events
    public static event Action OnReachTheEndGame;
    public static event Action OnReachCoin;
    public static event Action<string> OnReachLifeModificatorObject;
    void Awake()
    {
        Time.timeScale = 1;
        _componentRigidbody2D = GetComponent<Rigidbody2D>();
        _componentSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        /*
        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            _componentRigidbody2D.AddForce(Vector2.up * playerJumpStrength, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump == true && canJump == false)
        {
            _componentRigidbody2D.AddForce(Vector2.up * playerJumpStrength, ForceMode2D.Impulse);
            canDoubleJump = false;
        }*/
        if (_HealBarr.fillAmount <= 0)
        {
            OnReachTheEndGame?.Invoke();
        }
        if (cooldown <= 0)
        {
            cooldown = 2;
            canBeDanmaged = true;
        }
        cooldown = cooldown - Time.deltaTime;
    }
    void FixedUpdate()
    {
        _componentRigidbody2D.linearVelocity = new Vector2(horizontal * playerSpeed, _componentRigidbody2D.linearVelocity.y);
        RaycastHit2D hit = Physics2D.Raycast(originPoint.position, Vector2.down, rayCastLength, layerMask);
        if (hit.collider != null)
        {
            Debug.DrawRay(originPoint.position, Vector2.down * hit.distance, inCollision);
            canJump = true;
            canDoubleJump = true;
        }
        else
        {
            Debug.DrawRay(originPoint.position, Vector2.down * rayCastLength, outCollision);
            canJump = false;

        }
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log($"Jumpeando {context.phase}");
        if (canJump == true)
        {
            _componentRigidbody2D.AddForce(Vector2.up * playerJumpStrength, ForceMode2D.Impulse);
        }
        if (canDoubleJump == true && canJump == false)
        {
            _componentRigidbody2D.AddForce(Vector2.up * playerJumpStrength, ForceMode2D.Impulse);
            canDoubleJump = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            OnReachCoin?.Invoke();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Heart")
        {
            OnReachLifeModificatorObject?.Invoke("Healt");
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        SpriteRenderer _SR = collision.GetComponent<SpriteRenderer>();
        if (collision.tag == "Obstacle")
        {
            canChangeColor = false;
            if (_SR.color != _componentSpriteRenderer.color && canBeDanmaged == true)
            {
                OnReachLifeModificatorObject?.Invoke("Danmage");
                canBeDanmaged = false;
            }
        }
        if (collision.tag == "DeathZone")
        {
            OnReachLifeModificatorObject?.Invoke("DeathZone");
        }
        if (collision.tag == "Goal")
        {
            OnReachTheEndGame?.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            canChangeColor = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        SpriteRenderer _SR = collision.gameObject.GetComponent<SpriteRenderer>();
        if (collision.gameObject.tag == "Obstacle")
        {
            canChangeColor = false;
            if (_SR.color != _componentSpriteRenderer.color && canBeDanmaged == true)
            {
                _HealBarr.fillAmount = _HealBarr.fillAmount - 0.1f;
                canBeDanmaged = false;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            canChangeColor = true;
        }
    }
}
