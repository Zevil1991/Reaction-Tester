using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    [SerializeField] private UnityEvent ClickEvt;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickEvt?.Invoke();
            Debug.Log("Mouse Button has been pressed");
        }

    }
}
