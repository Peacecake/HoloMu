﻿using HoloMu.Networking;
using HoloMu.Persistance;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace HoloMu.UI
{
    public class MainUIManager : MonoBehaviour {

        public ApiConnector ApiConnector;
        public PhotoCapturer PhotoCapturer;

        public Text ErrorText;
        public float DisplayTextDuration = 4f;

	    private void Start ()
        {
            this.ApiConnector.ErrorOccurred += OnErrorOccured;
            this.ApiConnector.ResponseRetrieved += OnApiResponseRetrieved;
            this.PhotoCapturer.ErrorOccured += OnErrorOccured;
            this.ErrorText.text = "";
	    }

        private void OnApiResponseRetrieved(object sender, ApiRequest request)
        {
            if (request.Type.Equals(RequestType.recommend))
            {
                RecommenderResult result = request.Result as RecommenderResult;
                if (result.IsSuccessful)
                {
                    Debug.Log(result.Recommendation);
                }
            }
        }

        private void OnErrorOccured(object sender, Error error)
        {
            StartCoroutine(ShowTextForSeconds(ErrorText, error.Message, DisplayTextDuration));
        }

        private IEnumerator ShowTextForSeconds(Text textField, string text, float time)
        {
            textField.text = text;
            yield return new WaitForSeconds(time);
            ErrorText.text = "";
        }

        public void HandleExhibitClose(Exhibit exhibit)
        {
            ApiRequest recommendRequest = new ApiRequest(RequestType.recommend);
            ApiConnector.MakeRequest(recommendRequest);
        }
    }
}
