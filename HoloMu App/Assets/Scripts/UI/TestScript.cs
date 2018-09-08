using HoloMu.Networking;
using HoloMu.Persistance;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

namespace HoloMu.UI
{
    public class TestScript : MonoBehaviour, IInputClickHandler
    {
        public ApiConnector ApiConnector;
        public PhotoCapturer PhotoCapturer;
        public InfoPanelManager InfoPanelManager;

        private SerializeableExhibit _exhibit;
        private Rotate _rotator;
        private bool _isClickable;

        private void Start()
        {
            _isClickable = true;
            _rotator = GetComponent<Rotate>();
            if (ApiConnector != null && PhotoCapturer != null)
            {
                ApiConnector.ResponseRetrieved += OnApiResult;
                PhotoCapturer.PhotoTaken += OnPhotoTaken;
            }
            else
                Debug.LogError("ApiConnector or PhotoCapturer are not set");
        }

        private void OnPhotoTaken(object sender, int instanceId, byte[] file)
        {
            if (instanceId == GetInstanceID())
            {
                Debug.LogWarning("On PhotoTaken: " + transform.parent.name + " InstanceId: " + gameObject.GetInstanceID());
                ApiConnector.MakeRequest(new ApiRequest(RequestType.recognize, file));
            }
        }

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
            if (!_isClickable) return;
            Debug.LogWarning("Click on: " + transform.parent.name + " InstanceID: " + gameObject.GetInstanceID());

            SetEnabled(false);
            InfoPanelManager.Add(gameObject);

            if (_exhibit == null)
                PhotoCapturer.TakePicture(GetInstanceID());
            else
                this.InfoPanelManager.SetExhibit(gameObject, _exhibit);
        }

        public void SetEnabled(bool isEnabled)
        {
            _isClickable = isEnabled;
            _rotator.Enabled = isEnabled;
            GetComponent<MeshRenderer>().enabled = isEnabled;
        }
    }
}
