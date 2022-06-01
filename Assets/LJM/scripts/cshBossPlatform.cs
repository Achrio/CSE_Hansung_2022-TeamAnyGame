using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshBossPlatform : MonoBehaviour
{
    public bool isEnabled;
    public float time;

    private void Awake()
    {
        isEnabled = true;
    }

    private void Start()
    {
        StartCoroutine(Blink());
    }

    IEnumerator Blink() {
        yield return new WaitForSeconds(10f);
        if (isEnabled)
        {
            isEnabled = false;
        }
        else if (!isEnabled)
        {
            isEnabled = true;
        }
        gameObject.GetComponent<MeshRenderer>().enabled = isEnabled;
        gameObject.GetComponent<BoxCollider>().enabled = isEnabled;
        StartCoroutine(Blink());
    }
}
