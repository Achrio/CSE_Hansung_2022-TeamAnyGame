using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public bool isPause = false;
    public bool isOver = false;
    
    [HideInInspector] public static GameManager instance;

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