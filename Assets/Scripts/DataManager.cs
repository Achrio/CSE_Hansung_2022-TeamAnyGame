using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

//saveData form
[System.Serializable]
public class SaveData {
    public int HP;
    public List<float> clearTime;
}

public class DataManager : MonoBehaviour {
    [HideInInspector] public static DataManager instance;
    private string _dataPath;
    public bool isData = false;

    void Start() {
        instance = this;
        _dataPath = Path.Combine(Application.dataPath, "data.json");
        DataLoad();
    }

    public void DataLoad() {
        SaveData saveData = new SaveData();

        //init, make saveData
        if(!File.Exists(_dataPath)) {
            DataNew();
            isData = false;
        }
        //load saveData, init fixed value in GameManager
        else {
            isData = true;
            string loadData = File.ReadAllText(_dataPath);
            saveData = JsonUtility.FromJson<SaveData>(loadData);

            if(saveData != null) {
                //Add amount of stages
                GameManager.instance.clearTime[0] = saveData.clearTime[0];
                GameManager.instance.clearTime[1] = saveData.clearTime[1];
            }
        }
    }

    public void DataSave() {
        SaveData saveData = new SaveData();

        saveData.clearTime = GameManager.instance.clearTime;

        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(_dataPath, json);
    }

    public void DataDelete() {
        System.IO.File.Delete(_dataPath);
        DataLoad();
    }

    public void DataNew() {
        GameManager.instance.clearTime[0] = 0f;
        GameManager.instance.clearTime[1] = 0f;

        DataSave();
    }
}
