using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class moneyUI : MonoBehaviour {
    private int _curMoney;
    public TextMeshProUGUI moneyText; //add in Inspector

    [HideInInspector] public static moneyUI Money;

    void Awake() {
        Money = this;
    }

    //Money Update (called by GameManager)
    public void moneyUpdate(int updatedMoney) {
        int fromMoney = _curMoney;
        int toMoney = updatedMoney;
        if(toMoney < 0) toMoney = 0;
        
        _curMoney = updatedMoney;
        StartCoroutine(ChangingNum(1, moneyText, fromMoney, toMoney));
    }

    //Changing Numbers Continuously
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
