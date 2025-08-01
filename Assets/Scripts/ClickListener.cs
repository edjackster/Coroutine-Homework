using System;
using UnityEngine;

public class ClickListener : MonoBehaviour
{
    public event Action Click;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
            Click?.Invoke();
    }
}
