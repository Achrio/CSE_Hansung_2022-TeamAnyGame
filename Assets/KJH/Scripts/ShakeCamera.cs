using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    private float shakeTime;
    private float shakeInensity;

    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            OnShakeCamera(0.1f, 0.2f);
        }
    }
    public void OnShakeCamera(float shakeTime = 1.0f, float shakeIntensity = 0.05f)
    {
        this.shakeTime = shakeTime;
        this.shakeInensity = shakeIntensity;

        StopCoroutine("ShakeByPosition");
        StartCoroutine("ShakeByPosition");
    }

    private IEnumerator ShakeByPosition()
    {
        Vector3 startPosition = transform.position;

        while ( shakeTime > 0.0f )
        {
            transform.position = startPosition + Random.insideUnitSphere * shakeInensity;

            shakeTime -= Time.deltaTime;

            yield return null;
        }

        transform.position = startPosition;
    }
}
