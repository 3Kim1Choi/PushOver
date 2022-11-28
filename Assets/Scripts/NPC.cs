using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    CharacterAnimation c_anim;
    void Start() {
        c_anim = GetComponent<CharacterAnimation>();
    }

    private void FixedUpdate() {
        
    }
}
