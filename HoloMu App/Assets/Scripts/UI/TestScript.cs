using HoloMu.Networking;
using HoloToolkit.Unity.InputModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloMu.UI
{
    public class TestScript : MonoBehaviour, IInputClickHandler
    {

        public ApiConnector ApiConnector;
        public Exhibit exhibit;

        private void Start()
        {
            ApiConnector.OnApiResult += OnApiResult;
        }

        private void OnApiResult(object sender, bool isSuccessful, string result)
        {
            if (isSuccessful)
            {
                exhibit.InitializeFromXmlString(result);
                Debug.Log(exhibit);
            }
            else
            {
                Debug.LogError(result);
            }
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            ApiConnector.MakeTextRequest();
        }
    }
}
