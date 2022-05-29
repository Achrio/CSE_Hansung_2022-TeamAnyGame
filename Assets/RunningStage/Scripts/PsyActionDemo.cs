using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsyActionDemo : MonoBehaviour {
    private GameObject player;

    private Vector3 curPos;
    private Vector3 maxPos;

    static bool pressed = false;

    private bool _isGrabbing = false;
    private GameObject _detactedObject;
    private GameObject _grabbingObject;
    private GameObject _shotObject;
    private PsyObjectDemo objectScript;

    void Awake() {
        player = GameObject.Find("Player");
    }

    void Update() {
        this.gameObject.transform.position = player.transform.position;

        if(_isGrabbing && _grabbingObject) {
            _grabbingObject.transform.position = new Vector3(player.transform.position.x - 3, player.transform.position.y + 2, player.transform.position.z);
        }

        if(!pressed && !_isGrabbing && _detactedObject && Input.GetKeyDown(KeyCode.LeftControl)) {
            Debug.Log("Grabbed");
            OnGrab();
            pressed = true;
        }

        if(!pressed && _isGrabbing && _grabbingObject && Input.GetKeyDown(KeyCode.LeftControl)) {
            Debug.Log("Shot");
            _grabbingObject.transform.position = new Vector3(player.transform.position.x + 3, player.transform.position.y + 2, player.transform.position.z);
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
        objectScript.isGrab = true;

        _grabbingObject.GetComponent<Collider>().enabled = false;

        //objectScript.OnGrab();
    }

    private void OnShot() {
        _shotObject = _grabbingObject;
        _grabbingObject = null;
        _isGrabbing = false;
        
        _shotObject.tag = "Throwed";
        _shotObject.GetComponent<Collider>().enabled = true;

        curPos = _shotObject.transform.position;
        objectScript.maxPos = new Vector3(curPos.x + 100, curPos.y, curPos.z);
        objectScript.isShot = true;
        objectScript.isGrab = false;

        objectScript = null;
    }
}