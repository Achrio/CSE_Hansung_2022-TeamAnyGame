using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightInteract : MonoBehaviour {
    public Light _light;
    
    void Awake() {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            _light.intensity = 20;
        }
    }
}
