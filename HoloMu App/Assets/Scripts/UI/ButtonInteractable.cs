using HoloToolkit.Unity.InputModule;
using System;
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
