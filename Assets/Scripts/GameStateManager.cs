using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    int state = 0;



    public void setState(int new_state) {
        state = new_state;
    }
}
