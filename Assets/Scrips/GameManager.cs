using System;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    float maxLife = 1;
    public Image _PlayerLife;
    public int coinsRecolected = 0;
    float currentTime;
    int mins;
    int segs;
    void Update()
    {
        currentTime = currentTime + Time.deltaTime;
        mins = (int)(currentTime / 60);
        segs = (int)(currentTime % 60);
        if (_PlayerLife.fillAmount > maxLife)
        {
            _PlayerLife.fillAmount = maxLife;
        }
    }
    public string TimerUpdate()
    {
        string textTime;
        if (segs < 10)
        {
            textTime = (mins + " : 0" + segs);
        }
        else
        {
            textTime = (mins + " : " + segs);
        }
        return textTime;
    }
    public void StopTheGameTime()
    {
        Time.timeScale = 0;
    }
    public void UpdateCoins()
    {
        coinsRecolected++;
    }
    public void UpdateLife(string action)
    {
        if (action == "Danmage")
        {
            _PlayerLife.fillAmount = _PlayerLife.fillAmount - 0.1f;
        }
        else if (action == "Healt")
        {
            _PlayerLife.fillAmount = _PlayerLife.fillAmount + 0.1f;
        }
        else if (action == "DeathZone")
        {
            _PlayerLife.fillAmount = 0f;
        }
    }

    private void OnDisable()
    {
        PlayerController.OnReachTheEndGame -= StopTheGameTime;
        PlayerController.OnReachCoin -= UpdateCoins;
        PlayerController.OnReachLifeModificatorObject -= UpdateLife;
    }
    private void OnEnable()
    {
        Time.timeScale = 1;
        PlayerController.OnReachTheEndGame += StopTheGameTime;
        PlayerController.OnReachCoin += UpdateCoins;
        PlayerController.OnReachLifeModificatorObject += UpdateLife;
    }
}
