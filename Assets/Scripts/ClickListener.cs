using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickListener : MonoBehaviour
{
    public event Action OnClick;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            OnClick?.Invoke();
    }
}
