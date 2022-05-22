using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearUI : MonoBehaviour {
    public int stageNum;

    [HideInInspector] public static ClearUI clear;

    public GameObject Underline;
    public Text StageName;
    public Text ClearTime;
    public Text Record;
    public Text NewRecord;

    private bool isClear = false;
    private float timer;
    private float curTime;
    private bool newRecord = false;

    void Awake() {
        clear = this;
    }

    void Update() {
        if(isClear) {
            StartCoroutine("showResult");
            timer += Time.deltaTime;
            if(timer > 1.5f) {
                StartCoroutine("showClearTime");
            }
            if(timer > 3f) {
                StartCoroutine("showRecord");
            }
            if(timer > 5f && newRecord) {
                showNewRecord();
                GameManager.instance.clearTime[stageNum] = timerUI.instance.time;
                DataManager.instance.DataSave();
            }
        }
    }

    public void clearStage() {
        isClear = true;
        timerUI.instance.isClear = true;
        timerUI.instance.gameObject.SetActive(false);

        //get Stage Name and Clear Time
        StageName.text = GameManager.instance.stageName[stageNum] + " Clear!";
        ClearTime.text = timerUI.instance.timerText.text;

        //get Stage Clear Record
        curTime = GameManager.instance.clearTime[stageNum];
        TimeSpan timespan = TimeSpan.FromSeconds(curTime);
        Record.text = "record : " + timespan.ToString("mm': 'ss'. 'fff");

        if(GameManager.instance.clearTime[stageNum] > timerUI.instance.time || GameManager.instance.clearTime[stageNum] == 0) {
            if(GameManager.instance.clearTime[stageNum] == 0) Record.text = "";
            newRecord = true;
        }
    }

    private IEnumerator showResult() {
        float time = 0f;
        RectTransform _curPos = Underline.gameObject.GetComponent<RectTransform>();
        Vector3 _fromPos = _curPos.anchoredPosition3D;
        
        while(time < 1f) {
            _curPos.anchoredPosition3D = Vector3.Lerp(_fromPos, new Vector3(-300, 0, 0), time);
            time += Time.deltaTime * 2f;
            yield return null;
        }
    }

    private IEnumerator showClearTime() {
        float time = 0f;
        RectTransform _curPos = ClearTime.gameObject.GetComponent<RectTransform>();
        Vector3 _fromPos = _curPos.anchoredPosition3D;
        
        while(time < 1f) {
            _curPos.anchoredPosition3D = Vector3.Lerp(_fromPos, new Vector3(-350, -50, 0), time);
            time += Time.deltaTime * 1f;
            yield return null;
        }
    }

    private IEnumerator showRecord() {
        float time = 0f;
        RectTransform _curPos = Record.gameObject.GetComponent<RectTransform>();
        Vector3 _fromPos = _curPos.anchoredPosition3D;
        
        while(time < 1f) {
            _curPos.anchoredPosition3D = Vector3.Lerp(_fromPos, new Vector3(-350, -115, 0), time);
            time += Time.deltaTime * 1f;
            yield return null;
        }
    }

    private void showNewRecord() {
        RectTransform _curPos = NewRecord.gameObject.GetComponent<RectTransform>();
        
        _curPos.anchoredPosition3D = new Vector3(-300, -50, 0);
    }
}
