using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    Animator anim;
    string animationState;
    //0: 원최, 1: 하랑, 2: 태한
    public int characterNum;
    bool movingSideways = true;
    bool moving;
    char dir;
    string[] characterName = new string[] {"OneChoi","Harang","TaeHan","NPC1","NPC2","NPC3","NPC4","NPC5","NPC6","NPC7","NPC8"};
    const string IDLE = "_idle";
    const string WALK = "_walk";

    private void Start() {
        anim = GetComponent<Animator>();
    }

    public void CheckAnim(Vector2 movement) {
        if (movement.magnitude < 0.1f) {
            if (moving) {
                ChangeAnimationState(characterName[characterNum] + IDLE + dir);
                moving = false;
            }
        } else {
            if(movingSideways) {
                if (movement.x > 0.3f)
                    dir = 'R';
                else if (movement.x < -0.3f)
                    dir = 'L';
                else {
                    if (movement.y > 0) 
                        dir = 'U';
                    else if (movement.y <= 0)
                        dir = 'D';
                    movingSideways = false;
                }
            } else {
                if (movement.y > 0.3f) 
                    dir = 'U';
                else if (movement.y < -0.3f)
                    dir = 'D';
                else {
                    if (movement.x > 0)
                        dir = 'R';
                    else if (movement.x <= 0)
                        dir = 'L';
                    movingSideways = true;
                }
            }
            ChangeAnimationState(characterName[characterNum] + WALK + dir);
            moving = true;
        }
    }

    void ChangeAnimationState(string newState) {
        if (animationState == newState)
            return;
        
        anim.Play(newState);
        animationState = newState;
    }
}
