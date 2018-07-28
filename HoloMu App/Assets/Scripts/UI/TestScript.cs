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

        private Exhibit _exhibit;

        private void Start()
        {
            ApiConnector.ResponseRetrieved += OnApiResult;
            PhotoCapturer.PhotoTaken += OnPhotoTaken;
        }

        private void OnPhotoTaken(object sender, byte[] file)
        {
            ApiConnector.MakeRequest(new ApiRequest(RequestType.StartRecognize, file));
        }

        private void OnApiResult(object sender, ApiRequest request)
        {
            ImageRecognitionResult result = request.Result as ImageRecognitionResult;
            if (result.IsSuccessful)
            {
                _exhibit = result.Exhibit;
                Debug.Log(_exhibit);
                Debug.Log("Call to " + request.URL + " successful!");
            }
            else
            {
                Debug.LogError(result.ErrorMessage);
            }
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            PhotoCapturer.TakePicture();
        }
    }
}
