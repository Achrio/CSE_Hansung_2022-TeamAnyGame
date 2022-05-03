using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusManager {
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
        onPause();
        isOver = true;
    }
}

public class GameManager : MonoBehaviour {
    private StatusManager _status = new StatusManager();
    [HideInInspector] public static GameManager instance;

    [Header ("Text UI")]
    public TextMeshProUGUI hpUI;
    public TextMeshProUGUI moneyUI;
    public TextMeshProUGUI timerUI;
    public TextMeshProUGUI questUI;
    
    [HideInInspector] public int health;
    [HideInInspector] public int money;
    [HideInInspector] public int curHP;
    private float _time;

    [HideInInspector] public List<int> inv = new List<int>();

    void Awake() {
        instance = this;
    }

    void Update() {
        //pause
        if(!_status.isPause && Input.GetKeyDown(KeyCode.Escape)) {
            _status.onPause();
            return;
        }

        //resume
        if(!_status.isPause && Input.GetKeyDown(KeyCode.Escape)) {
            _status.onResume();
            return;
        }

        //time ticking
        if(!_status.isPause && !_status.isOver) {
            _time += Time.deltaTime;
            TimeSpan timespan = TimeSpan.FromSeconds(_time);
            timerUI.text = timespan.ToString("mm': 'ss'. 'fff");
        }

        //game over
        if(curHP <= 0) {
            _status.gameOver();
        }
    }

    public void hpUpdate(int change) {
        int fromHP = curHP;
        int toHP = curHP + change;
        if(toHP < 0) toHP = 0;

        curHP = toHP;

        StartCoroutine(ChangingNum(0, hpUI, fromHP, toHP));
    }

    public void moneyUpdate(int change) {
        int fromMoney = money;
        int toMoney = money + change;
        if(toMoney < 0) toMoney = 0;
        
        money += change;

        StartCoroutine(ChangingNum(1, moneyUI, fromMoney, toMoney));
    }

    public void invGetUpdate(int itemCode) {
        inv.Add(itemCode);
    }

    IEnumerator ChangingNum(int type, TextMeshProUGUI text, float current, float toChange) {
        float speed = 0.5f;
        float change = (toChange - current) / speed;

        while(current < toChange) {
            current += change * Time.deltaTime;
            if(type == 1) {
                text.text = "$ " + ((int)current).ToString();
            }
            else text.text = ((int)current).ToString();

            yield return null;
        }

        current = toChange;

        if(type == 1) {
                text.text = "$ " + ((int)current).ToString();
        }
        else text.text = ((int)current).ToString();
    }
}