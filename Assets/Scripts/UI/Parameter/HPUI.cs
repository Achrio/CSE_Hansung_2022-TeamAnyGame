using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour {
    private int _curHP;
    public Text HPText; //add in Inspector

    [HideInInspector] public static HPUI HP;

    void Awake() {
        HP = this;
    }

    //HP UI Update
    public void hpUpdate(int updatedHP) {
        _curHP = updatedHP;
        if(_curHP < 0) _curHP = 0;

        HPText.text = _curHP.ToString();
    }
}