using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour {
    public GameObject caution;

    public bool mode; 
    
    public void showCaution() {
        caution.SetActive(true);
    }

    public void exitCaution() {
        caution.SetActive(false);
    }   

    public void returnToGame() {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }

    public void exitGame() {
        if(mode) returnToLobby();
        if(!mode) returnToMain();
    }

    public void LobbySelect() {
        mode = true;
    }

    public void MainSelect() {
        mode = false;
    }

    private void returnToLobby() {
        Time.timeScale = 1;
        SceneLoadingManager.LoadScene("LobbyScene");
        this.gameObject.SetActive(false);
    }

    private void returnToMain() {
        Time.timeScale = 1;
        SceneLoadingManager.LoadScene("MainScene");
        this.gameObject.SetActive(false);
    }
}
