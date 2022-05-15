using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour {
    private StatusManage _status = new StatusManage();
    [HideInInspector] public static GameManager instance;

    [Header ("Screens")]
    public GameObject pauseScreen;              //pause UI Screen (add in Inspector)
    public GameObject deathScreen;              //death UI Screen (add in Inspector)
    
    [Header ("Fixed Values")]
    public int HPValue;       //max HP (saveFile value), fixed
    public int dashValue;     //max Dash count (saveFile value), fixed

    [Header ("Variable Values")]
    public int curHPValue;    //current HP (game value), variable
    public int curDashValue;  //current Dash count (game value), variable
    public int moneyValue;    //current Money (game value), fixed first then variable

    void Awake() {
        instance = this;
    }

    void Start() {
        cshTimer timer = this.gameObject.GetComponent<cshTimer>();
        timer.dashCount = this.dashValue; //init cshTimer dashCount
        timer.count = this.curDashValue; //init cshTimer dashCount
    }

    //Game Status Change
    void Update() {
        //pause action
        if(!_status.isPause && Input.GetKeyDown(KeyCode.Escape)) {
            _status.onPause();
            pauseScreen.SetActive(true);
            return;
        }
        //resume action
        if(_status.isPause && Input.GetKeyDown(KeyCode.Escape)) {
            _status.onResume();
            pauseScreen.SetActive(false);
            return;
        }

        //game over action
        if(curHPValue <= 0) {
            _status.gameOver();
        }
    }

    //UI Update (Called by each object's func)
    public void MoneyUpdate(int changeValue) {
        moneyValue += changeValue;

        moneyUI.Money.moneyUpdate(moneyValue);
    }
    public void curHPUpdate(int changeValue) {
        if(curHPValue + changeValue > HPValue) curHPValue = HPValue;
        else curHPValue += changeValue;

        HPUI.HP.hpUpdate(curHPValue);
    }
    public void curDashUpdate(int changeValue) {
        curDashValue = changeValue;

        dashUI.Dash.curDashUpdate(curDashValue);
    }
}

public class StatusManage {
    public bool isPause = false;
    public bool isOver = false;

    public void onPause() {
        isPause = true;
        Time.timeScale = 0;
    }

    public void onResume() {
        isPause = false;
        Time.timeScale = 1;
    }

    public void gameStart() {
        onResume();
        isOver = false;
    }

    public void gameOver() {
        //onPause();
        isOver = true;
    }
}