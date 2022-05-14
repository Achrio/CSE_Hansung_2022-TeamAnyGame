using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyObject : MonoBehaviour {
    public int money = 500;
    public GameObject effect;

    void OnTriggerEnter(Collider player) {
        if(player.gameObject.tag == "Player") {
            CameraShake.instance.OnShakeCamera();
            GameManager.instance.MoneyUpdate(money);
            Instantiate(effect, this.gameObject.transform.position, this.gameObject.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
