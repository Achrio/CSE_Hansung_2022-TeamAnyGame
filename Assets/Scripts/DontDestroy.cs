using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {
    public static DontDestroy instance;

    private void Awake() {
        if(instance != null) {
            Destroy(this.gameObject);
            return;
        } 
        instance = this;
        DontDestroyOnLoad(gameObject); 
    }
}
