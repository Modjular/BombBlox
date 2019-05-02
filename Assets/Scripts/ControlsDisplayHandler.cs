using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsDisplayHandler : MonoBehaviour
{
    [SerializeField] GameObject gameControlsMenu;
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = gameControlsMenu.GetComponent<Text>();
        text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C)) {
            text.enabled = !text.enabled;
        }
    }
}
