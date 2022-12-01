using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrologueButton : MonoBehaviour {
    public void ButtonClick() {
        GameManager.Instance.Next();
    }

   
}
