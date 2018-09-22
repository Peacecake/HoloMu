using HoloMu.Networking;
using HoloToolkit.Unity.InputModule;
using UnityEngine;
using Vuforia;

namespace HoloMu.UI
{
    public class InfoIcon : MonoBehaviour, IInputClickHandler
    {
        public GameController GameController;
        public InfoPanelManager InfoPanelManager;

        private SerializeableExhibit _exhibit;
        private Rotate _rotator;

        private void Start()
        {
            _rotator = GetComponent<Rotate>();
            if (GameController == null)
                GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
            GameController.Api.ResponseRetrieved += OnApiResult;
            // GameController.PhotoCapturer.PhotoTaken += OnPhotoTaken;
        }

        //private void OnPhotoTaken(object sender, int instanceId, byte[] file)
        //{
        //    if (instanceId == GetInstanceID())
        //    {
        //        Debug.LogWarning("On PhotoTaken: " + transform.parent.name + " InstanceId: " + gameObject.GetInstanceID());
        //        GameController.Api.MakeRequest(new ApiRequest(RequestType.recognize, file));
        //    }
        //}

        private void OnApiResult(object sender, ApiRequest request)
        {
            if (request.Type.Equals(RequestType.recognize))
            {
                ImageRecognitionResult result = request.Result as ImageRecognitionResult;
                if (result.IsSuccessful)
                {
                    _exhibit = result.SExhibit;
                    this.InfoPanelManager.SetExhibit(gameObject, _exhibit);
                }
                else
                {
                    SetEnabled(true);
                    this.InfoPanelManager.Remove(gameObject);
                }
            }
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            Debug.LogWarning("Click on: " + transform.parent.name + " InstanceID: " + gameObject.GetInstanceID());

            SetEnabled(false);
            InfoPanelManager.Add(gameObject);

            //if (_exhibit == null)
                GameController.PhotoCapturer.TakePicture(GetInstanceID());
            //else
            //    this.InfoPanelManager.SetExhibit(gameObject, _exhibit);
        }

        public void SetEnabled(bool isEnabled)
        {
            _rotator.Enabled = isEnabled;
            gameObject.SetActive(isEnabled);
            // GetComponent<MeshRenderer>().enabled = isEnabled;
            if (isEnabled)
                TrackerManager.Instance.GetTracker<ObjectTracker>().Start();
            else
                TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();
        }
    }
}
