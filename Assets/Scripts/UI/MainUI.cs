using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour {
    public void StartGame() {
        SceneLoadingManager.LoadScene("LobbyScene");
    }
}