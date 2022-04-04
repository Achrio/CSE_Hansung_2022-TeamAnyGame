using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPoint : MonoBehaviour {
    private GameObject mainCamera;
    private CameraControl _cameraControl;

    [Header ("Camera Move and Rotate Value")]
    public Vector3 extraPos;
    public Vector3 extraRot;

    void Awake() {
        mainCamera = GameObject.FindWithTag("MainCamera");
        _cameraControl = mainCamera.GetComponent<CameraControl>();
    }

    //트리거 범위 진입하면 설정됨
    void OnTriggerEnter(Collider mainCam) {
        if(mainCam.gameObject.tag == "MainCamera") {
            _cameraControl.setExtraPos(extraPos);
            _cameraControl.setExtraRot(extraRot);
        }
    }

    //트리거 범위 벗어나면 초기화
    /*
    void OnTriggerExit(Collider mainCam) {
        if(mainCam.gameObject.tag == "MainCamera") {
            _cameraControl.initExtra();
        }
    }
    */
}
