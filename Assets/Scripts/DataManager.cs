using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string playerName;
    public int score;
    public string playerNameHS;
    public int scoreHS;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void SetName(string name)
    {
        playerName = name;
    }
     public void SetScore(int scorei)
    {
        score = scorei;
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int highScore;
    }

    public void SaveHS()
    {
        SaveData data = new SaveData();
        data.name = playerNameHS;
        data.highScore = scoreHS;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHS()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerNameHS = data.name;
            scoreHS = data.highScore; 

        }
    }
}
