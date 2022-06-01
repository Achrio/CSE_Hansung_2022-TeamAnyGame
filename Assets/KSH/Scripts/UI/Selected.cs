using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selected : MonoBehaviour {
    public Text text;
    public bool highlight = true;
    private float _time = 0f;
    public float duration = 1f;

    void Start() {
        _time = 0f;
    }

    void Update() {
        if(highlight) {
            _time += Time.deltaTime;
            if(_time < duration) {
                text.color = new Color(1, 1, 1, 1f - (_time / duration));
            }
            if(_time > duration) {
                text.color = new Color(1, 1, 1, (_time / duration) - duration);
            }
            if(_time >= duration * 2) _time = 0f;
        }
        if(!highlight) {
            text.color = new Color(1, 1, 1, 0.25f);
        }
    }
}
