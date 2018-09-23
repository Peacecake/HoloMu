using HoloMu;
using HoloMu.Networking;
using HoloMu.Persistance;
using HoloMu.UI;
using System.IO;
using UnityEngine;
using Vuforia;

[RequireComponent(typeof(ApiConnector))]
[RequireComponent(typeof(PhotoCapturer))]
[RequireComponent(typeof(MainUIManager))]
public class GameController : MonoBehaviour
{
    public GameSettings Settings { get { return LoadSettings(); } }
    public ApiConnector Api { get { return LoadApiConnector(); } }
    public PhotoCapturer PhotoCapturer { get { return LoadPhotoCapturer(); } }
    public MainUIManager Ui { get; private set; }

    public GameObject SetupManager;
    public InfoPanelManager InfoPanelManager;

    string _settingsPath;
    ApiConnector _api;
    PhotoCapturer _photo;
    GameSettings _settings;

    void Start()
    {
        VuforiaBehaviour.Instance.enabled = false;
        this.InfoPanelManager.InfoPanelDestroyed += OnInfoPanelDestroyed; 
        Ui = GetComponent<MainUIManager>();
    }

    public void OnInfoIconClick(GameObject clickedObject)
    {
        InfoIcon icon = clickedObject.GetComponent<InfoIcon>();
        icon.SetEnabled(false);
        this.InfoPanelManager.Add(icon);
        this.PhotoCapturer.TakePicture(0);
    }

    void OnInfoPanelDestroyed(object sender)
    {
        this.Api.MakeRequest(new ApiRequest(RequestType.recommend));
    }

    ApiConnector LoadApiConnector()
    {
        if (_api == null)
        {
            _api = GetComponent<ApiConnector>();
            _api.BaseUrl = Settings.baseUrl;
            _api.ResponseRetrieved += OnApiResponseRetrieved;
            _api.ErrorOccurred += OnApiError;
        }
        return _api;
    }

    void OnApiResponseRetrieved(object sender, ApiRequest request)
    {
        if (request.Result.IsSuccessful)
        {
            switch (request.Type)
            {
                case RequestType.recommend:
                    RecommenderResult recResult = request.Result as RecommenderResult;
                    Ui.ShowMessage("Unsere Empfehlung", recResult.Recommendation);
                    break;
                case RequestType.recognize:
                    ImageRecognitionResult irResult = request.Result as ImageRecognitionResult;
                    this.InfoPanelManager.SetExhibit(irResult.SExhibit);
                    break;
                case RequestType.setup:
                    VuforiaBehaviour.Instance.enabled = true;
                    Destroy(this.SetupManager);
                    break;
            }
        }
        else
        {
            switch (request.Type)
            {
                case RequestType.recognize:
                    this.InfoPanelManager.Remove();
                    break;
            }
        }
    }

    PhotoCapturer LoadPhotoCapturer()
    {
        if (_photo == null)
        {
            _photo = GetComponent<PhotoCapturer>();
            _photo.PhotoTaken += OnPhotoTaken;
            _photo.ErrorOccured += OnPhotoError;
        }
        return _photo;
    }

    void OnPhotoTaken(object sender, int instanceId, byte[] file)
    {
        this.Api.MakeRequest(new ApiRequest(RequestType.recognize, file));
    }

    void OnPhotoError(object sender, Error error)
    {
        Debug.Log(error.Message);
        Ui.ShowMessage("Kamera Fehler", error.Message);
    }

    void OnApiError(object sender, Error error)
    {
        Debug.LogError(error.Message);
        Ui.ShowMessage("Netzwerk Fehler", error.Message);
    }

    GameSettings LoadSettings()
    {
        if (_settings == null)
        {
            _settingsPath = Path.Combine(Application.persistentDataPath, "settings.json");
            if (!File.Exists(_settingsPath))
            {
                _settings = new GameSettings();
                PersistSettings();
            }
            else
            {
                string jsonString = File.ReadAllText(_settingsPath);
                _settings = JsonUtility.FromJson<GameSettings>(jsonString);
            }
        }
        return _settings;
    }

    void PersistSettings()
    {
        string jsonString = JsonUtility.ToJson(Settings);
        File.WriteAllText(_settingsPath, jsonString);
    }

    public void UpdateSettings(GameSettings newSettings)
    {
        _settings = newSettings;
        PersistSettings();
    }

    public void HandleExhibitClose(SerializeableExhibit exhibit)
    {
        ApiRequest recommendRequest = new ApiRequest(RequestType.recommend);
        _api.MakeRequest(recommendRequest);
    }
}
