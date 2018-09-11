using HoloMu;
using HoloMu.Networking;
using HoloMu.Persistance;
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
    public Loader Loader = null;
    public ApiConnector Api = null;
    public GameObject ARCamera = null;
    public GameController Controller = null;

    private TouchScreenKeyboard _keyboard;
    private GameSettings _settings;

    public void OnChangeIPClick()
    {
        _keyboard = TouchScreenKeyboard.Open(_settings.baseUrl, TouchScreenKeyboardType.Default, false, false, false, false);
    }

    public void OnStartSetupClick()
    {
        if (Loader != null)
            Loader.SetLoading(true);

        if (Api != null)
        {
            Controller.UpdateSettings(_settings);
            ApiRequest request = new ApiRequest(RequestType.setup);
            Api.BaseUrl = _settings.baseUrl;
            Api.MakeRequest(request);
        }
    }

    private void Start()
    {
        if (Loader != null)
            Loader.SetLoading(false);
        if (Api != null)
        {
            Api.ResponseRetrieved += OnApiResultRetrieved;
            Api.ErrorOccurred += OnApiError;
        }
        if (ARCamera != null)
            ARCamera.SetActive(false);
        if (Controller != null)
            _settings = Controller.Settings;
    }

    private void OnApiError(object sender, Error error)
    {
        Loader.SetLoading(false, error.Message);
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
            if (_settings == null)
                _settings = this.Controller.Settings;
            switch (_keyboard.status)
            {
                case TouchScreenKeyboard.Status.Done:
                    if (!_keyboard.text.Equals("")) 
                        _settings.baseUrl = _keyboard.text;
                    _keyboard = null;
                    break;
                case TouchScreenKeyboard.Status.Canceled:
                    _keyboard = null;
                    break;
            }
        }

        IPText.text = _settings.baseUrl;
    }
}
