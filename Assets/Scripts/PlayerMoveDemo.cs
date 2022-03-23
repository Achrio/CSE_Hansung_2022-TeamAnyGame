using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveDemo : MonoBehaviour {
    public float speed = 10f;
    void Start() {
        
    }

    void Update() {
        this.transform.Translate(speed * Time.deltaTime, 0, 0);
        speed *= 1.01f;
        if(speed >= 20f) speed = 20f;
    }
}
