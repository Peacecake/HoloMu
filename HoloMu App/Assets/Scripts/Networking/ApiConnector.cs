using HoloMu.Persistance;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace HoloMu.Networking
{
    public class ApiConnector : MonoBehaviour
    {
        public event ApiRequestResultHandler ResponseRetrieved;
        public event ErrorHandler ErrorOccurred;

        public string BaseUrl;

        private UnityWebRequest _www;
        private GameSettings _settings;

        private void Start()
        {
            _settings = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().Settings;
            this.BaseUrl = _settings.baseUrl;
        }

        public void MakeRequest(ApiRequest request)
        {
            request.URL = this.BaseUrl;
            switch(request.Type)
            {
                case RequestType.recognize:
                    StartCoroutine(Upload(request));
                    break;
                case RequestType.setup:
                case RequestType.recommend:
                    StartCoroutine(Get(request));
                    break;
                case RequestType.Test:
                    StartCoroutine(GetTextFrom(request));
                    break;
            }
        }

        private IEnumerator Upload(ApiRequest request)
        {
            List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
            formData.Add(new MultipartFormFileSection("file", request.File, "test-image.png", "image/png"));
            using(_www = UnityWebRequest.Post(request.URL, formData))
            {
                // _www.SetRequestHeader("Content-Type", "multipart/form-data");
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
            if (!request.Result.IsSuccessful && this.ErrorOccurred != null)
            {
                this.ErrorOccurred.Invoke(this, new Error(ErrorType.ApiRequest, www.error));
            }

            if (this.ResponseRetrieved != null)
            {
                this.ResponseRetrieved.Invoke(this, request);
            }
        }
    }
}
