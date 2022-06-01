using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class cshTimer : MonoBehaviour
{
 
    public float setTime = 0.0f;
    public int maxDashCount;
    public int curDashcount;
    [SerializeField] Text countdownText;
    [SerializeField] Text DashcountText;

    void Awake()
    {
        
        if(countdownText) countdownText.text = setTime.ToString();
    }
    
    // Update is called once per frame
    void Update()
    {
        Timer();
        if(countdownText) countdownText.text = Mathf.Round(setTime).ToString();
        if(DashcountText) DashcountText.text = Mathf.Round(maxDashCount).ToString();
    }
    void Timer()
    {
        if (setTime <= 5)
            setTime += Time.deltaTime;
        else if (setTime > 5)
        {
            setTime = 0.0f;
            if (curDashcount < maxDashCount) {
                curDashcount++;

                if(dashUI.Dash)
                    dashUI.Dash.curDashUpdate(curDashcount);
            }
        }
    }
}
