using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace HoloMu.Networking
{
    public class ApiConnector : MonoBehaviour
    {
        public event ApiRequestResultHandler ResponseRetrieved;

        public string BaseUrl;

        private UnityWebRequest _www;

        public void MakeRequest(ApiRequest request)
        {
            request.URL = this.BaseUrl;
            switch(request.Type)
            {
                case RequestType.recognize:
                    StartCoroutine(Upload(request));
                    break;
                case RequestType.setup:
                    StartCoroutine(Get(request));
                    break;
                case RequestType.recommend:
                    StartCoroutine(Get(request));
                    break;
            }
        }

        private IEnumerator Upload(ApiRequest request)
        {
            List<IMultipartFormSection> formData = new List<IMultipartFormSection>
            {
                new MultipartFormFileSection("file", request.File, "test-image.png", "image/png")
            };
            using (_www = UnityWebRequest.Post(request.URL, formData))
            {
                yield return _www.SendWebRequest();
                HandleRequestResult(_www, request);
            }
        }

        private IEnumerator Get(ApiRequest request)
        {
            using (_www = UnityWebRequest.Get(request.URL))
            {
                yield return _www.SendWebRequest();
                HandleRequestResult(_www, request);
            }
        }

        private IEnumerator GetTextFrom(ApiRequest request)
        {
            using (_www = UnityWebRequest.Get(request.URL))
            {
                yield return _www.SendWebRequest();
                HandleRequestResult(_www, request);
            }
        }

        private void HandleRequestResult(UnityWebRequest www, ApiRequest request)
        {
            request.HandleResult(!(www.isNetworkError || www.isHttpError), www.downloadHandler.text, www.error);
            this.ResponseRetrieved?.Invoke(this, request);
        }
    }
}
