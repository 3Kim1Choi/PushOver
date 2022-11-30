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
    public int minigame;
    public int positivity;
    public bool m1clear,m2clear,m3clear;
    public float transitionTime;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void Start() {
        positivity = 0;
        m1clear = false;
        m2clear = false;
        m3clear = false;
        UpdateGameState(GameState.Title);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {
            M1Start();
        }
        if (Input.GetKeyDown(KeyCode.O)) {
            M2Start();
        }
        if (Input.GetKeyDown(KeyCode.P)) {
            M3Start();
        }
        if (Input.GetKeyDown(KeyCode.J)) {
            M1Clear();
        }
        if (Input.GetKeyDown(KeyCode.K)) {
            M1Clear();
        }
        if (Input.GetKeyDown(KeyCode.L)) {
            M1Clear();
        }
        SceneManager.sceneLoaded += NewSceneLoaded;
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
        SceneManager.LoadScene("Prologue");
    }

    public void Next() {
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

    public void M1Start() {
        minigame = 1;
        SceneManager.LoadScene("JumpMinigame");
    }
    public void M1Fail() {
        SceneManager.LoadScene("SejongUniv");
    }
    public void M1Clear() {
        if (!m1clear)
            positivity++;
        m1clear = true;
        StartCoroutine("Transition1");
    }
    public void M2Start() {
        minigame = 2;
        SceneManager.LoadScene("Run&JumpMinigame");
    }
    public void M2Fail() {
        SceneManager.LoadScene("SejongUniv");
    }
    public void M2Clear() {
        if (!m2clear)
            positivity++;
        m2clear = true;
        StartCoroutine("Transition1");
    }
    public void M3Start() {
        minigame = 3;
        SceneManager.LoadScene("StealthMinigame");
    }
    public void M3Fail() {
        SceneManager.LoadScene("SejongUniv");
    }
    public void M3Clear() {
        if (!m3clear)
            positivity++;
        m3clear = true;
        StartCoroutine("Transition1");
    }
    public void ToUniv() {
        SceneManager.LoadScene("SejongUniv");
    }
    IEnumerator Transition1() {
        FindObjectOfType<SceneTransition>().EndAnimation();
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Clear");
        FindObjectOfType<SceneTransition>().StartAnimation();
    }
    void NewSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (SceneManager.GetActiveScene().name == "Clear") {
            Debug.Log("load");
            FindObjectOfType<SceneTransition>().StartAnimation();
        }
    }

}
