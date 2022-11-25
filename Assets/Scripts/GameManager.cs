using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState {
    Title,
    Menu,
    Tutorial,
    ChapterOne,
    ChapterTwo,
    Ending
}

//게임의 전체적인 흐름과 중요 정보를 저장한다
//SINGLETON 클래스
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;
    public static event Action<GameState> OnGameStateChanged;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void Start() {
        UpdateGameState(GameState.Title);
    }

    public void UpdateGameState(GameState newState) {
        State = newState;
        switch (newState) {
            case GameState.Title:
                //SceneManager.LoadScene("Start");
                break;
            case GameState.Menu:
                break;
            case GameState.Tutorial:
                break;
            case GameState.ChapterOne:
                break;
            case GameState.ChapterTwo:
                break;
            case GameState.Ending:
                break;
            default:
                break;
        }
        OnGameStateChanged?.Invoke(newState);
    }

    public void GameStart() {
        SceneManager.LoadScene("SejongUniv");
    }

    public void Credit() {
        SceneManager.LoadScene("Credit");
    }

    public void Quit() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
            Application.Quit();
    }

    public void ToTitile() {
        SceneManager.LoadScene("Title");
    }

    public void M1Fail() {
        SceneManager.LoadScene("SejongUniv");
    }
    public void M1Clear() {
        SceneManager.LoadScene("SejongUniv");
    }

}
