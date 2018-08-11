using System;
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
        public GameObject InfoPanel;

        private Exhibit _exhibit;
        private GameObject _infoPanel;
        private Rotate _rotator;
        private bool _isClickable;

        private void Start()
        {
            _isClickable = true;
            _rotator = GetComponent<Rotate>();
            ApiConnector.ResponseRetrieved += OnApiResult;
            PhotoCapturer.PhotoTaken += OnPhotoTaken;
        }

        private void OnPhotoTaken(object sender, byte[] file)
        {
            ApiConnector.MakeRequest(new ApiRequest(RequestType.recognize, file));
        }

        private void OnApiResult(object sender, ApiRequest request)
        {
            _infoPanel.GetComponent<InfoPanel>().SetLoadingState(false);

            ImageRecognitionResult result = request.Result as ImageRecognitionResult;
            if (result.IsSuccessful)
            {
                _exhibit = result.Exhibit;
                PopulateInfoPanel();
            }
            else
            {
                SetEnabled(true);
                Destroy(_infoPanel);
            }
        }

        private void PopulateInfoPanel()
        {
            _infoPanel.GetComponent<InfoPanel>().Exhibit = _exhibit;
        }

        private void InitInfoPanel()
        {
            _infoPanel = Instantiate(InfoPanel, transform.position, Quaternion.identity);
            _infoPanel.GetComponent<InfoPanel>().SetLoadingState(true);
            _infoPanel.transform.SetParent(transform);
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            if (!_isClickable) return;

            SetEnabled(false);
            InitInfoPanel();

            if (_exhibit == null)
            {
                PhotoCapturer.TakePicture();
            }
            else
            {
                _infoPanel.GetComponent<InfoPanel>().SetLoadingState(false);
                PopulateInfoPanel();
            }
        }

        public void SetEnabled(bool isEnabled)
        {
            _isClickable = isEnabled;
            _rotator.Enabled = isEnabled;
            GetComponent<MeshRenderer>().enabled = isEnabled;
        }
    }
}
