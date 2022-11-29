using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame1UI : MenuElements
{
    public GameObject bg;
    bool gameFail;
    void Start() {
        gameFail = false;
    }

    public void GameFail() {
        Debug.Log("fali");
        LeanTween.alphaCanvas(bg.GetComponent<CanvasGroup>(), 1, 0.5f).setOnComplete(() => {gameFail = true;});
    }

    public void Button(int n) {
        if (gameFail) {
            if (n == 0) {
                LeanTween.alphaCanvas(bg.GetComponent<CanvasGroup>(), 0, 0.05f);
                GameManager.Instance.M3Start();
            } if (n == 1) {
                GameManager.Instance.M3Fail();
            }

        }
    }
}
