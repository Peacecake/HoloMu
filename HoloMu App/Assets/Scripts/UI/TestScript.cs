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

        private void Start()
        {
            ApiConnector.ResponseRetrieved += OnApiResult;
            PhotoCapturer.PhotoTaken += OnPhotoTaken;
        }

        private void OnPhotoTaken(object sender, byte[] file)
        {
            ApiConnector.MakeRequest(new ApiRequest(RequestType.Test, file));
        }

        private void OnApiResult(object sender, ApiRequest request)
        {
            _infoPanel.GetComponent<InfoPanel>().SetLoadingState(false);

            ImageRecognitionResult result = request.Result as ImageRecognitionResult;
            if (result.IsSuccessful)
            {
                _exhibit = result.Exhibit;
                GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                Destroy(_infoPanel);
                Debug.LogError(result.ErrorMessage);
            }
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            _infoPanel = Instantiate(InfoPanel, transform.position, Quaternion.identity);
            _infoPanel.GetComponent<InfoPanel>().SetLoadingState(true);
            PhotoCapturer.TakePicture();
        }
    }
}
