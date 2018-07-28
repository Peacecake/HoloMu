using HoloMu.Networking;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

namespace HoloMu.UI
{
    public class TestScript : MonoBehaviour, IInputClickHandler
    {
        public ApiConnector ApiConnector;

        private Exhibit _exhibit;

        private void Start()
        {
            ApiConnector.OnApiResult += OnApiResult;
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
            ApiConnector.MakeRequest(new ApiRequest(RequestType.Test));
        }
    }
}
