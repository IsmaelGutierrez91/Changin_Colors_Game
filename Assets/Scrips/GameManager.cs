using NUnit.Framework;
using System;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    float maxLife = 1;
    public Image _PlayerLife;
    public int coinsRecolected = 0;
    float currentTime;
    int mins;
    int segs;
    public int CurrentColorID;
    public Color[] ColorArray = new Color[3];
    public SpriteRenderer _PlayerSR;

    private void Awake()
    {
        ColorArray[0] = Color.red;
        ColorArray[1] = Color.blue;
        ColorArray[2] = Color.green;
        CurrentColorID = 0;
    }
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
    public void SetNextColor(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Performed)
        {
            CurrentColorID = CurrentColorID + 1;
            if (CurrentColorID > ColorArray.Length - 1)
            {
                CurrentColorID = 0;
            }
            _PlayerSR.color = ColorArray[CurrentColorID];
        }
    }
    public void SetPrevColor(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Performed)
        {
            CurrentColorID = CurrentColorID - 1;
            if (CurrentColorID < 0)
            {
                CurrentColorID = ColorArray.Length - 1;
            }
            _PlayerSR.color = ColorArray[CurrentColorID];
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
