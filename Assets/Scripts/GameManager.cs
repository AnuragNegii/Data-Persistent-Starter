using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string CurrentPlayerName;
    public  int score;

    public int NewHighScore = 0;
    public string NewHighScorePlayerName = "";

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadNameAndScore();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    class SaveData
    {
        public int HighScore;
        public string HighScorePlayerName;
    }

    public void SaveNameAndScore()
    {
        SaveData data = new SaveData();
        data.HighScorePlayerName = NewHighScorePlayerName;
        data.HighScore = NewHighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/saveFile.json", json);
    }

    public void LoadNameAndScore()
    {
        string path = Application.persistentDataPath + "/saveFile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            NewHighScore = data.HighScore;
            NewHighScorePlayerName = data.HighScorePlayerName;
        }
        else
        {
            Debug.Log("save file not Found");
        }

    }
}
