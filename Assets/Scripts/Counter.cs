using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _timerDelay = 0.5f;
    [SerializeField] private ClickListener _listener;

    private bool _isRunning = false;

    public event Action CountChange;

    public int TimerCount { get; private set; }

    private void OnEnable()
    {
        _listener.Click += SwitchTimer;
    }

    private void OnDisable()
    {
        _listener.Click -= SwitchTimer;
    }

    private void Start()
    {
        TimerCount = 0;
    }

    public void SwitchTimer()
    {
        if (_isRunning)
            _isRunning = false;
        else
            StartCoroutine(CountTime());

    }

    private IEnumerator CountTime()
    {
        _isRunning = true;
        var wait = new WaitForSeconds(_timerDelay);

        while (_isRunning)
        {
            TimerCount++;

            CountChange?.Invoke();
            
            yield return wait;
        }
    }
}
