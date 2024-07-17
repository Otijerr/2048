using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public static string Nickname;

    [SerializeField] private Button _playBtn;
    [SerializeField] private Button _startBtn;
    [SerializeField] private Button _leadersBtn;
    [SerializeField] private Button _backBtn;

    [SerializeField] private InputField _inputNickname;

    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _leaderboard;
    [SerializeField] private GameObject _player;
    
    void Start()
    {
        _playBtn.onClick.AddListener(ShowUserCreate);
        _startBtn.onClick.AddListener(StartGame);
        _leadersBtn.onClick.AddListener(ShowLeaderBoard);
        _backBtn.onClick.AddListener(HideLeaderBoard);
    }
    void ShowUserCreate()
    {
        _menu.SetActive(false);
        _player.SetActive(true);
    }
    void ShowLeaderBoard()
    {
        _menu.SetActive(false);
        _leaderboard.SetActive(true);
    }
    void HideLeaderBoard()
    {
        _leaderboard.SetActive(false);
        _menu.SetActive(true);
    }
    void StartGame()
    {
        Nickname = _inputNickname.text;
        SceneManager.LoadScene("SampleScene");
    }
}
