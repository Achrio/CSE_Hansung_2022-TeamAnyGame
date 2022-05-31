using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour {
    public List<Button> menu;
    private List<Selected> selected;
    public List<Button> caution;
    private List<Selected> cautionSelected;
    public GameObject NewCaution;

    private int highlight = 0;
    private bool isData = true;
    private bool isCaution = false;

    void Start() {
        selected = new List<Selected>();
        cautionSelected = new List<Selected>();
        for(int i = 0; i < menu.Count; i++) {
            selected.Add(menu[i].gameObject.GetComponent<Selected>());
        }
        for(int i = 0; i < caution.Count; i++) {
            cautionSelected.Add(caution[i].gameObject.GetComponent<Selected>());
        }
        if (!DataManager.instance.isData) {
            isData = false;
            menu[0].gameObject.SetActive(false);
            selected[1].highlight = true;
            highlight = 1;
        }
    }

    void Update() {
        if(!isCaution) {
            //Do Function by Enter Key
            if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) {
                switch(highlight) {
                    case 0: ContinueGame();
                    break;
                    case 1:
                        if(!isData) ContinueGame();
                        else NewGame();
                    break;
                    case 2: ExitGame();
                    break;
                }
            }

            //Switch Selected Menu by ArrowKeys
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) ) {
                selected[highlight].highlight = false;
                --highlight;
                if(isData && highlight == -1) highlight = 2;
                if(!isData && highlight == 0) highlight = 2;
                selected[highlight].highlight = true;
            }
            if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow)) {
                selected[highlight].highlight = false;
                ++highlight;
                if(isData && highlight == 3) highlight = 0;
                if(!isData && highlight == 3) highlight = 1;
                selected[highlight].highlight = true;
            }
        }

        //New Game Caution Menu
        else {
            //Switch Selected Menu by ArrowKeys
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) ) {
                cautionSelected[highlight].highlight = false;
                --highlight;
                if(highlight == -1) highlight = 1;
                cautionSelected[highlight].highlight = true;
            }
            if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow)) {
                cautionSelected[highlight].highlight = false;
                ++highlight;
                if(highlight == 2) highlight = 0;
                cautionSelected[highlight].highlight = true;
            }

            //Do Function by Enter Key
            if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) {
                switch(highlight) {
                    case 0: NewGameCancel();
                    break;
                    case 1: NewGameAccept();
                    break;
                }
            }
        }
    }

    public void ContinueGame() {
        SceneLoadingManager.LoadScene("LobbyScene");
    }

    public void NewGame() {
        isCaution = true;
        NewCaution.SetActive(true);
        for(int i = 0; i < menu.Count; i++) {
            menu[i].gameObject.SetActive(false);
        }
        highlight = 0;
    }
    
    public void NewGameCancel() {
        isCaution = false;
        NewCaution.SetActive(false);
        for(int i = 0; i < menu.Count; i++) {
            menu[i].gameObject.SetActive(true);
        }
        highlight = 1;
    }

    public void NewGameAccept() {
        DataManager.instance.DataDelete();
        SceneLoadingManager.LoadScene("LobbyScene");
    }

    //End Application
    public void ExitGame() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
