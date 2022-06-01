using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfField : MonoBehaviour {
    void OnTriggerEnter(Collider player) {
        if(player.tag == "Player") {
            StageManager.instance.Revive(player.gameObject);
        }
    }
}
