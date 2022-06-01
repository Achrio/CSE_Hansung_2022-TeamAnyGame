using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour {
    private Image _screen;
    private Color _color;
    private float alpha = 1f;

    public bool clear = false;

    [HideInInspector] public static FadeScreen instance;

    void Awake() {
        instance = this;
    }

    void Start() {
        _screen = this.gameObject.GetComponent<Image>();
        if(_screen) _color = _screen.color;
        if(clear) alpha = 0f;
    }

    void Update() {
        if(!clear) {
            Invoke("FadeIn", 0.1f);
            if(alpha < 0f) CancelInvoke("FadeIn");
        }
        if(clear) {
            Invoke("FadeOut", 0.1f);
            if(alpha > 1f) CancelInvoke("FadeOut");
        }

        _color.a = alpha;
        _screen.color = _color;
    }

    private void FadeIn() {
        alpha -= 0.025f;
    }

    private void FadeOut() {
        alpha += 0.025f;
    }

    public void fadeout() {
        clear = true;
    }
    public void fadein() {
        clear = false;
    }
}