using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttons : MonoBehaviour
{
    NoticeUI _notice;

    // Start is called before the first frame update
    void Awake()
    {
        _notice = FindObjectOfType<NoticeUI>();
    }

    void OnTriggerEnter(Collider _col)
    {
        if(_col.gameObject.tag == "Player")
        {
            _notice.SUB("");
        }
    }
    void OnTriggerExit(Collider _col)
    {
        if (_col.gameObject.tag == "Player")
        {
            _notice.SUBDEL();
        }
    }
}
