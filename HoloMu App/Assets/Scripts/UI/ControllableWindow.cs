using HoloToolkit.Unity.InputModule;
using UnityEngine;

namespace HoloMu.UI
{
    [RequireComponent(typeof(FaceTarget))]
    [RequireComponent(typeof(HandDraggable))]
    public class ControllableWindow : MonoBehaviour, IInputClickHandler
    {
        FaceTarget _faceTarget;
        HandDraggable _handDraggable;

        void Start()
        {
            _faceTarget = GetComponent<FaceTarget>();
            _handDraggable = GetComponent<HandDraggable>();
            _handDraggable.IsDraggingEnabled = false;
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            _faceTarget.enabled = false;
            _handDraggable.IsDraggingEnabled = true;
        }
    }
}
