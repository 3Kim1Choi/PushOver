using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame1UI : MenuElements
{
    public GameObject bg;
    void Start() {
        
    }

    public void GameFail() {
        LeanTween.alphaCanvas(bg.GetComponent<CanvasGroup>(), 1, 0.5f).setIgnoreTimeScale(true);
    }

    public void Button(int n) {
        if (n == 0) {
            LeanTween.alphaCanvas(bg.GetComponent<CanvasGroup>(), 0, 0.05f);
            Time.timeScale = 1;
        } if (n == 1) {
            GameManager.Instance.M1Fail();
        }
    }
}
