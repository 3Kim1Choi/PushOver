using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame1UI : MenuElements
{
    public GameObject bg;
    bool gameFail;
    public int gameNum;
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
                if (gameNum == 1)
                    GameManager.Instance.M1Start();
                if (gameNum == 2)
                    GameManager.Instance.M2Start();
                if (gameNum == 3)
                    GameManager.Instance.M3Start();
            } if (n == 1) {
                if (gameNum == 1)
                    GameManager.Instance.M1Fail();
                if (gameNum == 2)
                    GameManager.Instance.M2Fail();
                if (gameNum == 3)
                    GameManager.Instance.M3Fail();
            }

        }
    }
}
