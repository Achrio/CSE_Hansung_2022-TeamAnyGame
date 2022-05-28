using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPoint : MonoBehaviour {
    private bool clear = false;
    private AudioSource _audioSource;

    void Awake() {
        _audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider player) {
        if(player.gameObject.tag == "Player") {
            clear = true;
            ClearUI.clear.clearStage();
            timerUI.instance.isClear = true;
            this.gameObject.GetComponent<Collider>().enabled = false;
            _audioSource.Play();
            StageManager.instance._audioSource.Stop();
        }
    }

    void Update() {
        if(clear) {
            Invoke("ClearFadeout", 7f);
            Invoke("ClearLobby", 9f);
        }
    }

    private void ClearFadeout() {
        if(FadeScreen.instance)
            FadeScreen.instance.clear = true;
    }

    private void ClearLobby() {
        SceneLoadingManager.LoadScene("LobbyScene");
    }
}
