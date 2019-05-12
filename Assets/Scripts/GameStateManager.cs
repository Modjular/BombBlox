using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    // state 1 = win
    // state 2 = lose
    int state = 0;



    public void setState(int new_state) {
        state = new_state;
    }
}
