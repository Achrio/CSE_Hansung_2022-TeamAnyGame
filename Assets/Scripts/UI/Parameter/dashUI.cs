using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dashUI : MonoBehaviour {
    [SerializeField] private int _maxDash;
    [SerializeField] private int _dashCount;

    [Header ("UI Layout Contents")]
    public GameObject LayOutObj;    //dash count block Layout (add in inspector)
    public GameObject Content;   //dash count block LayoutContent prefab (add in inspector)
    public Sprite chargedBlock;   //available dash count sprite (add in inspector)
    public Sprite unchargedBlock; //disable dash count sprite (add in inspector)

    private List<GameObject> _countBlock; //dash count block status List

    [HideInInspector] public static dashUI Dash;

    float alpha = 1f;

    void Awake() {
        Dash = this;
    }

    void Update() {
        if(_dashCount == _maxDash) {
            Invoke("ChangeAlpha", 0.5f);
            UIFade(alpha);
        }
        if(_dashCount != _maxDash) {
            alpha = 1f;
            UIFade(alpha);
        }
    }

    public void initDashCount(int maxDash) {
        _maxDash = maxDash;
        _dashCount = _maxDash;

        //set layout width
        LayOutObj.GetComponent<RectTransform>().sizeDelta = new Vector2((_maxDash * 0.5f), 1);

        //init block sprites to chargedBlock
        _countBlock = new List<GameObject>();
        for(int block = 0; block < _maxDash; block++) {
            GameObject newContent = Instantiate(Content) as GameObject;     //instantiate content
            newContent.transform.parent = LayOutObj.transform;              //set parent to layout
            _countBlock.Add(newContent);                                    //add content in list
            _countBlock[block].GetComponent<Image>().sprite = chargedBlock; //set image of content
        }
    }

    //change dash count block sprite
    public void curDashUpdate(int changedCount) {       
        if(_dashCount > changedCount) {
            _countBlock[changedCount].GetComponent<Image>().sprite = unchargedBlock;
        }
        if(_dashCount <= changedCount) {
            _countBlock[_dashCount].GetComponent<Image>().sprite = chargedBlock;
        }

        _dashCount = changedCount;
    }

    private void UIFade(float alpha) {
        Image image;
        for(int block = 0; block < _maxDash; block++) {
            image = _countBlock[block].GetComponent<Image>();
            Color color = image.color;
            color.a = alpha;
            image.color = color;
        }
    }

    private void ChangeAlpha() {
        alpha -= 0.1f;
    }
}
