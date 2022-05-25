using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsyObjectDemo : MonoBehaviour {
    public bool isGrab = false;
    public bool isShot = false;
    public float speed = 2.0f;
    public Vector3 maxPos;

    private Transform _curPos;
    private Material _curMat;

    private Material _onDetect;
    private Material _outDetect;

    void Start() {
        _curPos = this.gameObject.transform;
        _curMat = this.gameObject.GetComponent<MeshRenderer>().material;
        _onDetect = Resources.Load<Material>("DetectedDemo");
        _outDetect = Resources.Load<Material>("DefaultDemo");
    }

    void Update() {
        if(isGrab) {
            _curPos.Rotate(new Vector3(30f, 30f, 30f) * Time.deltaTime);
        }
        if(!isGrab && isShot) {
            _curPos.position = Vector3.MoveTowards(_curPos.position, maxPos, speed);
            if(_curPos.position.x >= maxPos.x) {
                Destroy(this.gameObject);
            }
        }
    }

    public void OnDetect() {
        _curMat.color = Color.yellow;
    }

    public void OutDetect() {
        _curMat.color = Color.black;
    }

    private void OnCollisionEnter(Collision other) {
        if(isShot) {
            Destroy(this.gameObject);
        }
    }
}