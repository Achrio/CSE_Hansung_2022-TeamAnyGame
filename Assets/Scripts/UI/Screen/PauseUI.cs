using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour {
    [Header ("menus and buttons")]
    public GameObject cautionMenu;
    public GameObject pauseMenu;
    public List<Text> pauseButton;
    public List<Text> causeButton;

    private bool mode;
    private bool isPause = false;
    private bool isCaution = false;
    private int highlight = 0;

    void Update() {
        //Pause Menu On
        if(!isPause && Input.GetKeyDown(KeyCode.Escape)) {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            highlight = 0;
            pauseButton[0].color = Color.white;
            pauseButton[1].color = Color.gray;
            pauseButton[2].color = Color.gray;
            isPause = true;
            GameManager.instance.isPause = true;
        }
        
        //In Pause Menu
        if(!isCaution && isPause) {
            //Select Menu by Arrow Keys in Pause Menu
            if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow)) {
                pauseButton[highlight].color = Color.gray;
                ++highlight;
                if(highlight == 3) highlight = 0;
                pauseButton[highlight].color = Color.white;
            }
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) {
                pauseButton[highlight].color = Color.gray;
                --highlight;
                if(highlight == -1) highlight = 2;
                pauseButton[highlight].color = Color.white;
            }

            //Do Function by Enter Key
            if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) {
                switch(highlight) {
                    case 0:
                    returnToGame();
                    break;
                    case 1:
                    showCaution();
                    LobbySelect();
                    break;
                    case 2:
                    showCaution();
                    MainSelect();
                    break;
                }
            }

            //Pause Menu Exit
            if(Input.GetKeyDown(KeyCode.Escape)) {
                isPause = false;
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
                GameManager.instance.isPause = false;
            }
        }

        //In Caution Menu
        if(isCaution && isPause) {
            if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow)) {
                pauseButton[highlight].color = new Color(0.5f, 0.5f, 0.5f, 1f);
                ++highlight;
                if(highlight == 2) highlight = 0;
                pauseButton[highlight].color = new Color(1f, 1f, 1f, 1f);
            }
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) {
                pauseButton[highlight].color = new Color(0.5f, 0.5f, 0.5f, 1f);
                --highlight;
                if(highlight == -1) highlight = 1;
                pauseButton[highlight].color = new Color(1f, 1f, 1f, 1f);
            }

            //Do Function by Enter Key
            if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) {
                switch(highlight) {
                    case 0:
                        exitCaution();
                    break;
                    case 1:
                        exitGame();
                    break;
                }
            }
        }
    }
    
    //Caution Menu On/Off
    public void showCaution() {
        isCaution = true;
        pauseMenu.SetActive(false);
        cautionMenu.SetActive(true);
        highlight = 0;
    }
    public void exitCaution() {
        isCaution = false;
        pauseMenu.SetActive(true);
        cautionMenu.SetActive(false);
        highlight = 0;
    }   

    //Set Bool (for Button.OnClick())
    public void LobbySelect() {
        mode = true;
    }
    public void MainSelect() {
        mode = false;
    }

    //Menu Select Destination
    public void returnToGame() {
        isPause = false;
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
    private void returnToLobby() {
        Time.timeScale = 1;
        SceneLoadingManager.LoadScene("LobbyScene");
        GameManager.instance.isPause = false;
    }
    private void returnToMain() {
        Time.timeScale = 1;
        SceneLoadingManager.LoadScene("MainScene");
        GameManager.instance.isPause = false;
    }
    public void exitGame() {
        if(mode) returnToLobby();
        if(!mode) returnToMain();
    }

}
