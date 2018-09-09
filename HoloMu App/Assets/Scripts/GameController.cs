using HoloMu.Persistance;
using System.IO;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameSettings Settings { get; private set; }

    string _settingsPath;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        LoadSettings();
    }

    void LoadSettings()
    {
        _settingsPath = Path.Combine(Application.persistentDataPath, "settings.json");
        if (!File.Exists(_settingsPath))
        {
            Settings = new GameSettings();
            PersistSettings();
        }
        else
        {
            string jsonString = File.ReadAllText(_settingsPath);
            Settings = JsonUtility.FromJson<GameSettings>(jsonString);
        }
    }

    void PersistSettings()
    {
        string jsonString = JsonUtility.ToJson(Settings);
        File.WriteAllText(_settingsPath, jsonString);
    }

    public void UpdateSettings(GameSettings newSettings)
    {
        Settings = newSettings;
        PersistSettings();
    }
}
