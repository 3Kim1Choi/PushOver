using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleLetters : MonoBehaviour
{
    [SerializeField] GameObject[] letters;
    [SerializeField] GameObject bg, stopSign;

    private void Start() {
        MoveLetters();
    }

    void MoveLetters() {
        LeanTween.rotate(letters[0],new Vector3(0,0,90),1);
    }
}
