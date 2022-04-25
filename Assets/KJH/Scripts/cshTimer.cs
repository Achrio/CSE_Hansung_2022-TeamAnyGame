using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class cshTimer : MonoBehaviour
{
 
    public float setTime = 0.0f;
    public int count = 3;
    [SerializeField] Text countdownText;
    [SerializeField] Text DashcountText;

    void Start()
    {
        //countdownText.text = setTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        countdownText.text = Mathf.Round(setTime).ToString();
        DashcountText.text = Mathf.Round(count).ToString();
    }
    void Timer()
    {
        if (setTime <= 5)
            setTime += Time.deltaTime;
        else if (setTime > 5)
        {
            setTime = 0.0f;
            if (count < 3)
                count++;
        }
    }
}
