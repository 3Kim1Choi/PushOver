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


}
