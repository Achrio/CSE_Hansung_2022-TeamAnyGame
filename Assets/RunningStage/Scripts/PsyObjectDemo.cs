using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsyObjectDemo : MonoBehaviour {
    [HideInInspector] public GameObject player;

    public bool isGrab = false;
    public bool isShot = false;
    public float speed = 0.5f;
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
        if(isGrab && player.transform.rotation.eulerAngles.y == 90f) {
            _curPos.position = new Vector3(player.transform.position.x - 3, player.transform.position.y + 2, player.transform.position.z);
            _curPos.Rotate(new Vector3(30f, 30f, 30f) * Time.deltaTime);
        }

        if(isGrab && player.transform.rotation.eulerAngles.y == 270f) {
            _curPos.position = new Vector3(player.transform.position.x + 3, player.transform.position.y + 2, player.transform.position.z);
            _curPos.Rotate(new Vector3(30f, 30f, 30f) * Time.deltaTime);
        }

        if(isShot) {
            _curPos.position = Vector3.MoveTowards(_curPos.position, maxPos, speed);
            if(_curPos.position.x == maxPos.x) {
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