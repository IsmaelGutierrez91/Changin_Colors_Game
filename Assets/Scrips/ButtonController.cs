using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [Header("Change Color Mechanic")]
    public SpriteRenderer _Player;
    public PlayerController _player;
    Image _componentImage;
    [Header("Change Scene")]
    [SerializeField] string sceneToChange;

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
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneToChange);
    }
    public void CloseGame()
    {
        Application.Quit();
    }
}
