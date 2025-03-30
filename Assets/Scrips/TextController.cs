using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    TextMeshProUGUI _TMPro;
    public float currentTime;
    int mins;
    int segs;
    public TextController _OriginalTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _TMPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        TimerUpdate();
        currentTime = currentTime + Time.deltaTime;
        mins = (int)(currentTime / 60);
        segs = (int)(currentTime % 60);
    }
    public void TimerUpdate()
    {
        currentTime = _OriginalTime.currentTime;
        if (segs < 10)
        {
            _TMPro.SetText(mins + " : 0" + segs);
        }
        else
        {
            _TMPro.SetText(mins + " : " + segs);
        }
    }
}
