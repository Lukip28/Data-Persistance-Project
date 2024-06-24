using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class NameManager : MonoBehaviour
{
    public static NameManager Instance;

    public string PlayerName;
    public string NewPlayer;
    public int BestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadPlayer();
    }
    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public int BestScore;
    }
    public void SavePlayer()
    {
        SaveData data = new SaveData();
        data.PlayerName = PlayerName;
        data.BestScore = BestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/playersavefile.json", json);
    }
    public void LoadPlayer()
    {
        string path = Application.persistentDataPath + "/playersavefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerName = data.PlayerName;
            BestScore = data.BestScore;
        }
    }
}
