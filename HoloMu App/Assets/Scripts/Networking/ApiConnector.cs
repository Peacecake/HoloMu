﻿using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace HoloMu.Networking
{
    public class ApiConnector : MonoBehaviour
    {
        public event ApiRequestResultHandler ResponseRetrieved;

        private UnityWebRequest _www;

        public void MakeRequest(ApiRequest request)
        {
            switch(request.Type)
            {
                case RequestType.StartRecognize:
                    StartCoroutine(Upload(request));
                    break;
                case RequestType.GetRecommendation:
                    StartCoroutine(Get(request));
                    break;
                case RequestType.Test:
                    StartCoroutine(GetTextFrom(request));
                    break;
            }
        }

        private IEnumerator Upload(ApiRequest request)
        {
            using(_www = UnityWebRequest.Put(request.URL, request.File))
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

            if (this.ResponseRetrieved != null)
            {
                this.ResponseRetrieved.Invoke(this, request);
            }
        }
    }
}
