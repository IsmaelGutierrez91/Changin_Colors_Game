using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class TextController : MonoBehaviour
{
    public GameManager gameManager;
    public Image _PlayerLife;
    TextMeshProUGUI _ComponentTextMeshProUGUI;
    private void Awake()
    {
        _ComponentTextMeshProUGUI = GetComponent<TextMeshProUGUI>();
        _ComponentTextMeshProUGUI.text = gameManager.TimerUpdate() + "";
    }
    private void Update()
    {
        UpdateText();
    }
    public void UpdateText()
    {
        if (gameObject.tag == "TimeText")
        {
            _ComponentTextMeshProUGUI.text = gameManager.TimerUpdate() + "";
        }else if(gameObject.tag == "EndGameText")
        {
            if (_PlayerLife.fillAmount <= 0)
            {
                _ComponentTextMeshProUGUI.text = "You Lose";
            }
            else
            {
                _ComponentTextMeshProUGUI.text = "You Win";
            }
        } else if (gameObject.tag == "CoinText")
        {
            _ComponentTextMeshProUGUI.text = "x " + gameManager.coinsRecolected;
        }
    }
}
