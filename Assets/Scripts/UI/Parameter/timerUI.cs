using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timerUI : MonoBehaviour {
    public TextMeshProUGUI timerText; //add in Inspector
    public float time;
    public bool isClear = false;
    
    [HideInInspector] public static timerUI instance;

    void Awake() {
        instance = this;
    }

    //Time Update (Stops when Pause(delatTime))
    void Update() {
        if(!isClear) {
        //time ticking
            time += Time.deltaTime;
            TimeSpan timespan = TimeSpan.FromSeconds(time);
            timerText.text = timespan.ToString("mm': 'ss'. 'fff");
        }
    }
}
