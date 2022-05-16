using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moneyUI : MonoBehaviour {
    private int _curMoney;
    public Text moneyText; //add in Inspector

    [HideInInspector] public static moneyUI Money;

    void Awake() {
        if(!Money) Money = this;
    }

    //Money Update (called by GameManager)
    public void moneyUpdate(int updatedMoney) {
        int fromMoney = _curMoney;
        int toMoney = updatedMoney;
        if(toMoney < 0) toMoney = 0;
        
        _curMoney = updatedMoney;
        StartCoroutine(ChangingNum(moneyText, fromMoney, toMoney));
    }

    //Changing Numbers Continuously
    IEnumerator ChangingNum(Text text, float current, float toChange) {
        float speed = 0.5f;
        float change = (toChange - current) / speed;

        while(current < toChange) {
            current += change * Time.deltaTime;
            text.text = "$ " + ((int)current).ToString();

            yield return null;
        }

        current = toChange;
        text.text = "$ " + ((int)current).ToString();
    }
}
