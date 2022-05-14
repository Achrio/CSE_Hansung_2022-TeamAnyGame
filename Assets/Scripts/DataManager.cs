using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//saveData form
[System.Serializable]
public class SaveData {
    public int money;
    public int HP;
    public int dash;

    //public List<int> store;
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
            GameManager.instance.moneyValue = 0;
            GameManager.instance.HPValue = 5;
            GameManager.instance.dashValue = 3;
            DataSave();
        }
        //load saveData, init fixed value in GameManager
        else {
            string loadData = File.ReadAllText(_dataPath);
            saveData = JsonUtility.FromJson<SaveData>(loadData);

            if(saveData != null) {
                GameManager.instance.moneyValue = saveData.money;
                GameManager.instance.HPValue = saveData.HP;
                GameManager.instance.dashValue = saveData.dash;
            }
        }

        //init variable values in GameManager, update all UI
        GameManager.instance.curHPValue = saveData.HP;
        GameManager.instance.curHPUpdate(saveData.HP);
        
        GameManager.instance.MoneyUpdate(saveData.money);

        GameManager.instance.curDashValue = saveData.dash;
        dashUI.Dash.initDashCount(saveData.dash); //init dash count in dashUI
    }

    public void DataSave() {
        SaveData saveData = new SaveData();

        saveData.money = GameManager.instance.moneyValue;
        saveData.HP = GameManager.instance.HPValue;
        saveData.dash = GameManager.instance.dashValue;

        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(_dataPath, json); 
    }
}
