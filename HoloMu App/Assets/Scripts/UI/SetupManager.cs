using HoloMu;
using HoloMu.Networking;
using HoloToolkit.UI.Keyboard;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetupManager : MonoBehaviour
{

    public Keyboard Keyboard = null;
    public TextMesh IPText = null;
    public GameObject Loader = null;
    public ApiConnector Api = null;
    public GameObject ARCamera = null;

    private TouchScreenKeyboard _keyboard;

    public void OnChangeIPClick()
    {
        _keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, false, false);
    }

    public void OnStartSetupClick()
    {
        if (Loader != null)
            Loader.SetActive(true);

        if (Api != null)
        {
            ApiRequest request = new ApiRequest(RequestType.setup);
            Api.BaseUrl = IPText.text;
            Api.MakeRequest(request);
        }
    }

    private void Start()
    {
        if (Loader != null)
            Loader.SetActive(false);
        if (Api != null)
        {
            Api.ResponseRetrieved += OnApiResultRetrieved;
            Api.ErrorOccurred += OnApiError;
        }
        if (IPText != null)
        {
            IPText.text = "http://192.168.0.52:5000";
        }
        if (ARCamera != null)
            ARCamera.SetActive(false);
    }

    private void OnApiError(object sender, Error error)
    {
        Debug.LogError(error.Message);
    }

    private void OnApiResultRetrieved(object sender, ApiRequest request)
    {
        if (request.Result.IsSuccessful)
        {
            ARCamera.SetActive(true);
            SceneManager.LoadScene("MainScene");
        }
    }

    private void Update()
    {
        if (TouchScreenKeyboard.visible == false && _keyboard != null)
        {
            if (_keyboard.status.Equals(TouchScreenKeyboard.Status.Done))
            {
                _keyboard = null;
                IPText.text = _keyboard.text;
            }
        }
    }
}
