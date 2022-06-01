using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTile : MonoBehaviour {
    public GameObject thisTile;

    void OnTriggerEnter(Collider player) {
        if(player.tag == "Player") {
            StageManager.instance.TileUpdate(thisTile);
            this.gameObject.SetActive(false);
        }
    }
}
