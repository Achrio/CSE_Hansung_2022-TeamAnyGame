using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

//saveData form
[System.Serializable]
public class SaveData {
    public int money;
    public int HP;
    public int dash;
    public int isShield;
    public List<float> clearTime;

}

public class DataManager : MonoBehaviour {
    private string _dataPath;

    void Start() {
        _dataPath = Path.Combine(Application.dataPath, "data.json");
        DataLoad();
    }

    public void DataLoad() {
        SaveData saveData = new SaveData();

        //init, make saveData
        if(!File.Exists(_dataPath)) {
            GameManager.instance.money= 0;
            GameManager.instance.HP = 5;
            GameManager.instance.dash = 3;
            GameManager.instance.isShield = 0;

            //Add amount of stages
            GameManager.instance.clearTime[0] = 0f;
            GameManager.instance.clearTime[1] = 0f;
            GameManager.instance.clearTime[2] = 0f;

            DataSave();
        }
        //load saveData, init fixed value in GameManager
        else {
            string loadData = File.ReadAllText(_dataPath);
            saveData = JsonUtility.FromJson<SaveData>(loadData);

            if(saveData != null) {
                GameManager.instance.money = saveData.money;
                GameManager.instance.HP = saveData.HP;
                GameManager.instance.dash = saveData.dash;
                GameManager.instance.isShield = saveData.isShield;

                //Add amount of stages
                GameManager.instance.clearTime[0] = saveData.clearTime[0];
                GameManager.instance.clearTime[1] = saveData.clearTime[1];
                GameManager.instance.clearTime[2] = saveData.clearTime[2];
            }
        }

        //update all UI
        GameManager.instance.curHPUpdate(0);
        GameManager.instance.MoneyUpdate(0);
        //dashUI.Dash.initDashCount(GameManager.instance.dash); //init dash count in dashUI
    }

    public void DataSave() {
        SaveData saveData = new SaveData();

        saveData.money = GameManager.instance.money;
        saveData.HP = GameManager.instance.HP;
        saveData.dash = GameManager.instance.dash;
        saveData.clearTime = GameManager.instance.clearTime;

        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(_dataPath, json);
    }

    public void DataDelete() {
        System.IO.File.Delete(_dataPath);
        DataLoad();
    }
}
