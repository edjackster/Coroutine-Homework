using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _timerDelay = 0.5f;
    [SerializeField] private TextMeshProUGUI _text;

    public int TimerCount { get; private set; }

    private bool _isRunning = false;

    public void SwitchTimer()
    {
        if (_isRunning)
            _isRunning = false;
        else
            StartCoroutine(CountTime());

    }

    private void Start()
    {
        TimerCount = 0;
    }

    private IEnumerator CountTime()
    {
        _isRunning = true;
        var wait = new WaitForSeconds(0.5f);

        while (_isRunning)
        {
            TimerCount++;
            _text.text = TimerCount.ToString();
            yield return wait;
        }
    }
}
