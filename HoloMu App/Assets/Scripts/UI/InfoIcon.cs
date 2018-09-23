using HoloToolkit.Unity.InputModule;
using System;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;

namespace HoloMu.UI
{
    public class InfoIcon : MonoBehaviour, IInputClickHandler
    {
        [Serializable]
        public class OnClickEvent : UnityEvent<GameObject> { }
        public OnClickEvent OnIconClick;

        private Rotate _rotator;

        private void Start()
        {
            _rotator = GetComponent<Rotate>();
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            OnIconClick?.Invoke(gameObject);
        }

        public void SetEnabled(bool isEnabled)
        {
            _rotator.Enabled = isEnabled;
            gameObject.SetActive(isEnabled);
            if (isEnabled) TrackerManager.Instance.GetTracker<ObjectTracker>().Start();
            else TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();
        }
    }
}
