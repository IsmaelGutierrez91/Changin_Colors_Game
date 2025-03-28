using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    public PlayerController _Player;
    public TMP_Text _Text;
    void Update()
    {
        _Text.text = "Player lives: " + _Player.playerLives;
    }
}
