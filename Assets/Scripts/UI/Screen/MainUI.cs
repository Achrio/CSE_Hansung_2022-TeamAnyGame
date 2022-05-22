using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour {
    public Image glitchedLogo;
    public GameObject pressStart;
    public GameObject mainMenu;
    private Animator _glitch;

    void Start() {
        _glitch = glitchedLogo.GetComponent<Animator>();
    }

    void Update() {
        if(Input.anyKeyDown) {
            StartGame();
        }
    }

    public void StartGame() {
        pressStart.SetActive(false);
        _glitch.SetTrigger("Pressed");
        mainMenu.SetActive(true);
    }
}
