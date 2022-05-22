using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPObject : MonoBehaviour {
    public GameObject effect;
    public int hp = 1;

    void OnTriggerEnter(Collider player) {
        if(player.gameObject.tag == "Player") {
            GameManager.instance.curHPUpdate(hp);
            Instantiate(effect, this.gameObject.transform.position, this.gameObject.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
