using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPoint : MonoBehaviour {
    private bool clear = false;

    private void OnTriggerEnter(Collider player) {
        if(player.gameObject.tag == "Player") {
            clear = true;
            ClearUI.clear.clearStage();
            timerUI.instance.isClear = true;
        }
    }

    void Update() {
        if(clear) {
            Invoke("ClearFadeout", 7f);
            Invoke("ClearLobby", 9f);
        }
    }

    private void ClearFadeout() {
        FadeScreen.instance.clear = true;
    }

    private void ClearLobby() {
        SceneLoadingManager.LoadScene("LobbyScene");
    }
}
