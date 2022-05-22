using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartUI : MonoBehaviour {
    public int stageNum;

    [Header ("Prefabs")]
    public Text stageName;
    public Image underline;

    private Color _color = Color.white;
    private float alpha = 0f;

    private bool _appeared = false;

    void Start() {
        if(GameManager.instance)
            stageName.text = GameManager.instance.stageName[stageNum];
        InvokeRepeating("Appear", 2f, 0.1f);
    }

    void Update() {
        if(alpha > 1f) {
            CancelInvoke("Appear");

            InvokeRepeating("Disappear", 2f, 0.1f);
        }
        if(alpha < 0f) {
            CancelInvoke("Disappear");
        }

        _color.a = alpha;
        underline.color = _color;
        stageName.color = _color;
    }

    private void Disappear() {
        alpha -= 0.05f;
    }

    private void Appear() {
        alpha += 0.025f;
    }
}