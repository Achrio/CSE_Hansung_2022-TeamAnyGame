using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveData {
    public int money;
    public int health;

    public List<int> inv = new List<int>();
}

public class DataManager : MonoBehaviour {
    private string _dataPath;

    void Start() {
        _dataPath = Path.Combine(Application.dataPath, "data.json");
        DataLoad();
    }

    public void DataLoad() {
        SaveData saveData = new SaveData();

        if(!File.Exists(_dataPath)) {
            GameManager.instance.money = 0;
            GameManager.instance.health = 5;
            DataSave();
        }
        else {
            string loadData = File.ReadAllText(_dataPath);
            saveData = JsonUtility.FromJson<SaveData>(loadData);

            if(saveData != null) {
                GameManager.instance.money = saveData.money;
                GameManager.instance.health = saveData.health;

                foreach(int item in saveData.inv) {
                    GameManager.instance.inv.Add(item);
                }
            }
        }
        GameManager.instance.curHP = GameManager.instance.health;
        GameManager.instance.hpUpdate(0);
        GameManager.instance.moneyUpdate(0);
    }

    public void DataSave() {
        SaveData saveData = new SaveData();

        foreach(int item in saveData.inv) {
            saveData.inv.Add(GameManager.instance.inv[item]);
        }

        saveData.money = GameManager.instance.money;
        saveData.health = GameManager.instance.health;

        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(_dataPath, json); 
    }
}
