using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();        
    }

    private void UpdateText()
    {
        _text.text = _counter.TimerCount.ToString();
    }

    private void OnEnable()
    {
        _counter.OnCountChange += UpdateText;
    }

    private void OnDisable()
    {
        _counter.OnCountChange -= UpdateText;
    }
}
