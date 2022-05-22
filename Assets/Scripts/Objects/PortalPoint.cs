using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalPoint : MonoBehaviour {
    public int stage = 0;
    private bool _isPortal = false;

    private List<string> sceneName;

    void Awake() {
        sceneName = new List<string>();
        sceneName.Add("metros");
        sceneName.Add("Running1");
    }

    void Update() {
        if(_isPortal && Input.GetKeyDown(KeyCode.Return)) {
            SceneLoadingManager.LoadScene(sceneName[stage]);
        }
    }

    void OnTriggerEnter(Collider player) {
        if(player.tag == "Player") {
            _isPortal = true;
            LobbyUI.instance.inPortal(stage);
        }
    }
    void OnTriggerExit(Collider player) {
        if(player.tag == "Player") {
            _isPortal = false;
            LobbyUI.instance.outPortal();
        }
    }
}
