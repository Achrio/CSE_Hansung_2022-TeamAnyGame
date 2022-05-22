using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPoint : MonoBehaviour {
    [Header ("Camera Move and Rotate Value")]
    public Vector3 movePos;
    public Vector3 moveRot;

    [Header ("Camera Shake Value")]
    public float time;
    public float intensity;


    //트리거 범위 진입하면 설정됨
    void OnTriggerEnter(Collider player) {
        if(player.tag == "Player") {
            CameraManager.instance.setPos(movePos);
            CameraManager.instance.setRot(moveRot);
            CameraManager.instance.isShake = true;
            CameraManager.instance.setShake(time, intensity);
        }
    }
}
