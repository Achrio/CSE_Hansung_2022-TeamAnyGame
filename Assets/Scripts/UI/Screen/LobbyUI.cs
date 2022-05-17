using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUI : MonoBehaviour {
    public GameObject stageInfo;
    [HideInInspector] public static LobbyUI instance;
    private bool _portal = false;
    private int _stage;

    [Header ("Stage Info")]
    public Text stageName;
    public Text stageClearTime;

    void Awake() {
        instance = this;
    }

    public void inPortal(int stage) {
        _portal = true;
        stageInfo.SetActive(true);
        
        _stage = stage;
        stageName.text = GameManager.instance.stageName[stage];

        float clearTime = GameManager.instance.clearTime[stage];
        TimeSpan timespan = TimeSpan.FromSeconds(clearTime);
        
        if(clearTime == 0f) stageClearTime.text = "No Record";
        else stageClearTime.text = timespan.ToString("mm': 'ss'. 'fff");
    }
    public void outPortal() {
        _portal = false;
        stageInfo.SetActive(false);
    }
}
