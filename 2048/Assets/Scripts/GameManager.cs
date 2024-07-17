using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private string _nickname;
    [SerializeField] private ScoreSaver _scoreSaver;
    [SerializeField] private Button _restartBtn;

    [SerializeField] private GameObject _cubePrefab;

    private int _score = 0;
    private void Start()
    {
        _nickname = MainMenuManager.Nickname;
        _restartBtn.onClick.AddListener(RestartLevel);
    }
    public void SpawnCube()
    {
        Invoke("Spawn", 1f);
    }
    private void OnApplicationQuit()
    {
        SaveScore();
    }
    public void SaveScore()
    {
        _scoreSaver.SaveScore(_nickname,_score);
    }    
    public void UpdateScore(int score)
    { 
       _scoreText.text = (_score += score).ToString();
    }

    void Spawn()
    {
        Instantiate(_cubePrefab, new Vector2(0f, 3f), Quaternion.identity);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
