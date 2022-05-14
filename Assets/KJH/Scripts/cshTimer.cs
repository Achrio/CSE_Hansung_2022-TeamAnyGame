using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class cshTimer : MonoBehaviour
{
 
    public float setTime = 0.0f;
    public int dashCount;
    public int count;
    [SerializeField] Text countdownText;
    [SerializeField] Text DashcountText;

    void Awake()
    {
        if(GameManager.instance) dashCount = GameManager.instance.dashValue; //(김승현 수정) 대시 최대값 GameManager에서 전달받음
        if(countdownText) countdownText.text = setTime.ToString();
    }
    
    // Update is called once per frame
    void Update()
    {
        Timer();
        if(countdownText) countdownText.text = Mathf.Round(setTime).ToString();
        if(DashcountText) DashcountText.text = Mathf.Round(dashCount).ToString();
    }
    void Timer()
    {
        if (setTime <= 5)
            setTime += Time.deltaTime;
        else if (setTime > 5)
        {
            setTime = 0.0f;
            if (count < dashCount) {
                count++;

                //(김승현 추가) UI 업데이트 목적으로 count 증가됐을 때 GameManager에 count 전달하는 라인
                if(GameManager.instance)
                    GameManager.instance.curDashUpdate(count);
            }
        }
    }
}
