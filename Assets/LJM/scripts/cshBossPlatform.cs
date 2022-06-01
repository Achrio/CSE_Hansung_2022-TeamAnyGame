using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshBossPlatform : MonoBehaviour
{
    public bool isEnabled;
    private void Awake()
    {
        isEnabled = true;
    }

    private void Update()
    {
        StartCoroutine(Blink());
    }

    IEnumerator Blink() {
        yield return new WaitForSeconds(15f);
        if (isEnabled)
        {
            isEnabled = false;
        }
        else if (!isEnabled)
        {
            isEnabled = true;
        }
        gameObject.SetActive(isEnabled);
    }
}
