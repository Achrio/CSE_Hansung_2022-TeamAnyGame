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
    public int HP;
    public List<float> clearTime;

    void Awake() {
        instance = this;
        clearTime = new List<float>();
        for(int i = 0; i< stageName.Count; i++) {
            clearTime.Add(0f);
        }
    }

    public void curHPUpdate(int changeValue) {
        HP += changeValue;

        HPUI.HP.hpUpdate(HP);
    }
}