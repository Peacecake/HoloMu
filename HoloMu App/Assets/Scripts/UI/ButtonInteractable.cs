using HoloToolkit.Unity.InputModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonInteractable : MonoBehaviour, IInputClickHandler
{

    [Serializable]
    public class MyEventType : UnityEvent { }

    public MyEventType OnEvent;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        OnEvent.Invoke();
    }
}
