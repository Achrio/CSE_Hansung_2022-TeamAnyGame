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

    [Header ("Stage Names")]
    public List<string> stageName; //stageName (add in Inspector)
    
    [Header ("Values")]
    public int money;
    public int HP;
    public int dash;
    public List<float> clearTime;

    void Awake() {
        instance = this;
        clearTime = new List<float>();
        clearTime.Add(0f);
        clearTime.Add(0f);
        clearTime.Add(0f);
    }

    void Start() {
        /* 대쉬 UI 임시
        cshTimer timer = this.gameObject.GetComponent<cshTimer>();
        timer.dashCount = this.maxDash; //init cshTimer dashCount
        timer.count = this.curDash; //init cshTimer dashCount
        */
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
    }

    //UI Update (Called by each object's func)
    public void MoneyUpdate(int changeValue) {
        money += changeValue;

        moneyUI.Money.moneyUpdate(money);
    }
    public void curHPUpdate(int changeValue) {
        HP += changeValue;

        HPUI.HP.hpUpdate(HP);
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
}