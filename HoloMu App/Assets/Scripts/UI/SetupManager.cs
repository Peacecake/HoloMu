using HoloMu;
using HoloMu.Networking;
using HoloMu.Persistance;
using HoloToolkit.UI.Keyboard;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SetupManager : MonoBehaviour
{
    public Button SetupButton;
    public Button ChangeIPButton;
    public TextMesh IPText = null;
    public Loader Loader = null;
    public GameController Controller = null;

    private TouchScreenKeyboard _keyboard;
    private GameSettings _settings;

    public void OnChangeIPClick()
    {
        _keyboard = TouchScreenKeyboard.Open(_settings.baseUrl, TouchScreenKeyboardType.Default, false, false, false, false);
    }

    public void OnStartSetupClick()
    {
        this.SetupButton.interactable = false;
        this.ChangeIPButton.interactable = false;
        Loader.SetLoading(true);
        
        Controller.UpdateSettings(_settings);
        ApiRequest request = new ApiRequest(RequestType.setup);
        Controller.Api.BaseUrl = _settings.baseUrl;
        Controller.Api.MakeRequest(request);
    }

    private void Start()
    {
        Loader.SetLoading(false);
        _settings = Controller.Settings;

        // Controller.Api.ErrorOccurred += OnApiError;
    }

    public void HandleSetupError(string errorMessage)
    {
        this.SetupButton.interactable = true;
        this.ChangeIPButton.interactable = true;
        Loader.SetLoading(false, errorMessage);
    }

    //private void OnApiError(object sender, Error error)
    //{
    //    this.SetupButton.interactable = true;
    //    this.ChangeIPButton.interactable = true;
    //    Loader.SetLoading(false, error.Message);
    //}

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
