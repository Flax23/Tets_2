using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public bool menuAudioIsDisabled;
    public bool gameAudioIsDisabled;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadSoundState();
    }

    [System.Serializable]
    class SaveData
    {
        public bool menuAudioIsDisabled;
        public bool gameAudioIsDisabled;
    }

    public void SaveSoundState()
    {
        SaveData data = new SaveData();
        data.menuAudioIsDisabled = menuAudioIsDisabled;
        data.gameAudioIsDisabled = gameAudioIsDisabled;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/soundstate.json", json);
    }

    public void LoadSoundState()
    {
        string path = Application.persistentDataPath + "/soundstate.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            menuAudioIsDisabled = data.menuAudioIsDisabled;
            gameAudioIsDisabled = data.gameAudioIsDisabled;
        }
    }
}
