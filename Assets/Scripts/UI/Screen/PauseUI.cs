using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour {
    [Header ("menus and buttons")]
    public GameObject filterScreen;
    public GameObject cautionMenu;
    public GameObject pauseMenu;
    public List<Text> pauseButton;
    public List<Text> cautionButton;

    private bool mode;
    private bool isPause = false;
    private bool isCaution = false;
    private int highlight = 0;

    void Update() {
        //In Pause Menu
        if(!isCaution) {
            //Pause Menu On/OFF
            if(Input.GetKeyDown(KeyCode.Escape)) {
                if(!isPause) OnPause();
                else OffPause();
            }

            if(isPause) {
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
                            LobbySelect();
                            showCaution();
                        break;
                        case 2:
                            MainSelect();
                            showCaution();
                        break;
                    }
                }
            }
        }

        //In Caution Menu
        else {
            if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow)) {
                cautionButton[highlight].color = new Color(0.5f, 0.5f, 0.5f, 1f);
                ++highlight;
                if(highlight == 2) highlight = 0;
                cautionButton[highlight].color = new Color(1f, 1f, 1f, 1f);
            }
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) {
                cautionButton[highlight].color = new Color(0.5f, 0.5f, 0.5f, 1f);
                --highlight;
                if(highlight == -1) highlight = 1;
                cautionButton[highlight].color = new Color(1f, 1f, 1f, 1f);
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

    public void OnPause() {
        Debug.Log("pause");
        isPause = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        GameManager.instance.isPause = true;
        filterScreen.SetActive(true);

        //menu selected
        highlight = 0;
        pauseButton[0].color = Color.white;
        pauseButton[1].color = Color.gray;
        pauseButton[2].color = Color.gray;     
    }

    public void OffPause() {
        Debug.Log("pause off");
        isPause = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        GameManager.instance.isPause = false;
        filterScreen.SetActive(false);
    }
    
    //Caution Menu On/Off
    public void showCaution() {
        isCaution = true;
        pauseMenu.SetActive(false);
        cautionMenu.SetActive(true);

        highlight = 0;
        cautionButton[0].color = Color.white;
        cautionButton[1].color = Color.gray;
    }

    public void exitCaution() {
        isCaution = false;
        pauseMenu.SetActive(true);
        cautionMenu.SetActive(false);
        
        highlight = 0;
        pauseButton[0].color = Color.white;
        pauseButton[1].color = Color.gray;
        pauseButton[2].color = Color.gray;  
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
