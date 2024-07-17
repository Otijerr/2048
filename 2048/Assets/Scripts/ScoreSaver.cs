using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreSaver : MonoBehaviour
{
    private List<PlayerData> leaderboardData = new List<PlayerData>();

    private string savePath;
    void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "leaderboard.json");
    }
    private void Start()
    {
        savePath = Path.Combine(Application.persistentDataPath, "leaderboard.json");
        LoadData();
    }
    public void SaveScore(string playerName, int score)
    {
        PlayerData player = new PlayerData
        {
            playerName = playerName,
            score = score
        };

        leaderboardData.Add(player);
        SaveData();
    }
    void SaveData()
    {
        string jsonData = JsonConvert.SerializeObject(leaderboardData);
        File.WriteAllText(savePath, jsonData);
    }
    void LoadData()
    {
        if (File.Exists(savePath))
        {
            string jsonData = File.ReadAllText(savePath);
            leaderboardData = JsonConvert.DeserializeObject<List<PlayerData>>(jsonData);
        }
    }
}

