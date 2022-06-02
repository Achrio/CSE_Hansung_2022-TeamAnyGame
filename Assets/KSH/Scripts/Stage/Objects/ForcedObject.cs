using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcedObject : MonoBehaviour {
    private Rigidbody _rb;
    private Collider _col;

    public float power = 5000;
    
    void Start() {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<Collider>();
    }

    void Update() {
        
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Shot") {
            Vector3 moveDir = other.gameObject.transform.forward;
            _col.enabled = false;

            moveDir = new Vector3(0, 60, 0);

            _rb.AddForce(transform.up * power);
            _rb.AddTorque(transform.forward * power);
        }
    }
}