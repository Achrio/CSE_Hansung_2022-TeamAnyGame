using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsyActionDemo : MonoBehaviour {
    public GameObject player;

    private Vector3 curPos;
    private Vector3 maxPos;

    static bool pressed = false;

    private bool _isGrabbing = false;
    private GameObject _detactedObject;
    private GameObject _grabbingObject;
    private GameObject _shotObject;
    private PsyObjectDemo objectScript;

    void Update() {
        this.gameObject.transform.position = player.transform.position;

        if(_isGrabbing && _grabbingObject) {
            _grabbingObject.transform.position = player.transform.position;
        }

        if(!pressed && !_isGrabbing && _detactedObject && Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Grabbed");
            OnGrab();
            pressed = true;
        }

        if(!pressed && _isGrabbing && _grabbingObject && Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Shot");
            OnShot();
            pressed = true;
        }

        pressed = false;
    }

    //일정 범위 내 집을 수 있는 물체를 탐지
    private void OnTriggerEnter(Collider grabbable) {
        if(!_isGrabbing && grabbable.gameObject.tag == "Throwable") {
            Debug.Log("Throwable Object Detected");
            _detactedObject = grabbable.gameObject;
            objectScript = _detactedObject.GetComponent<PsyObjectDemo>();
            objectScript.OnDetect();
        }
    }

    //범위에서 벗어나면 탐지 제외
    private void OnTriggerExit(Collider grabbable) {
        if(grabbable.gameObject.tag == "Throwable") {
            Debug.Log("Throwable Object Out of Range");
            _detactedObject = null;
            objectScript.OutDetect();
            objectScript = null;
        }
    }

    private void OnGrab() {
        _grabbingObject = _detactedObject;
        _detactedObject = null;
        _isGrabbing = true;

        objectScript = _grabbingObject.GetComponent<PsyObjectDemo>();
        objectScript.OutDetect();

        _grabbingObject.GetComponent<Collider>().enabled = false;
    }

    private void OnShot() {
        _shotObject = _grabbingObject;
        _grabbingObject = null;
        _isGrabbing = false;
        
        _shotObject.tag = "Untagged";
        _shotObject.GetComponent<Collider>().enabled = true;

        curPos = _shotObject.transform.position;
        objectScript.maxPos = new Vector3(curPos.x + 100, curPos.y, curPos.z);
        objectScript.isShot = true;

        objectScript = null;
    }
}
