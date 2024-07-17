using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using Unity.VisualScripting.FullSerializer;
using System;
using UnityEditor;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] private Text leaderboardText;
    private List<PlayerData> leaderboardData = new List<PlayerData>();

    private string savePath;
    void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "leaderboard.json");
    }

    private void Start()
    {
        savePath = Path.Combine(Application.persistentDataPath, "leaderboard.json");
        LoadLeaderboard();
        DisplayLeaderboard();
    }
    void LoadLeaderboard()
    {
        if (File.Exists(savePath))
        {
            string jsonData = File.ReadAllText(savePath);
            leaderboardData = JsonConvert.DeserializeObject<List<PlayerData>>(jsonData);
        }
    }
    void SaveLeaderboard()
    {
        string jsonData = JsonConvert.SerializeObject(leaderboardData);
        File.WriteAllText(savePath, jsonData);
    }

    void DisplayLeaderboard()
    {
        leaderboardData = leaderboardData.OrderByDescending(player => player.score).ToList();

        string leaderboardString = "";

        foreach (PlayerData player in leaderboardData)
        {
            leaderboardString += player.playerName + " - " + player.score + "\n";
        }

        leaderboardText.text = leaderboardString;
    }

    public void SaveScore(string playerName, int score)
    {
        PlayerData player = new PlayerData
        {
            playerName = playerName,
            score = score
        };

        leaderboardData.Add(player);
        SaveLeaderboard();
        DisplayLeaderboard();
    }
}

