using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticeUI : MonoBehaviour
{
    public GameObject subbox;
    public Text subintext;
    public Animator subani;


    // Start is called before the first frame update
    void Start()
    {
        subbox.SetActive(false);
    }
    public void SUB(string message)
    {
        subintext.text = message;
        subbox.SetActive(true);
        subani.SetBool("isOn", true);

    }
    public void SUBDEL()
    {
        
        subani.SetBool("isOn", false);
        Invoke("SUBD", 0.3f);
    }
    public void SUBD()
    {
        subbox.SetActive(false);
    }
}
