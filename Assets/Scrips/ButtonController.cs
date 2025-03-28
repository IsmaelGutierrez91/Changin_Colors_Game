using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public SpriteRenderer _Player;
    public PlayerController _player;
    Image _componentImage;
    private void Awake()
    {
        _componentImage = GetComponent<Image>();
    }
    public void ChangePlayerColor()
    {
        if (_player.canChangeColor == true)
        {
            _Player.color = _componentImage.color;
        }
    }
}
