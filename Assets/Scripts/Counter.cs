using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _timerDelay = 0.5f;
    [SerializeField] private ClickListener _listener;

    public event Action OnCountChange;
    public int TimerCount { get; private set; }

    private bool _isRunning = false;

    public void SwitchTimer()
    {
        if (_isRunning)
            _isRunning = false;
        else
            StartCoroutine(CountTime());

    }

    private void OnEnable()
    {
        _listener.OnClick += SwitchTimer;
    }

    private void OnDisable()
    {
        _listener.OnClick -= SwitchTimer;
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

            OnCountChange?.Invoke();
            
            yield return wait;
        }
    }
}
