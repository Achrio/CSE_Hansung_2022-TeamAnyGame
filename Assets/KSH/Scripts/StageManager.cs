using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {
    [HideInInspector] public static StageManager instance;

    [Header ("Previous Tile & Destroy Effect")]
    public GameObject prevTile;
    public GameObject pixelize;

    [Header ("Tiles")]
    public List<GameObject> tileA;

    [Header("Audio Clips")]
    public AudioSource _audioSource;
    public List<AudioClip> stageBGMs;

    private float _tilePos = 0f;    //new Tile Instantiate pos
    private bool _tileType = false; //new Tile type (normal/enemy+obstacle)

    void Awake() {
        instance = this;
        _audioSource = this.gameObject.GetComponent<AudioSource>();
        int play = Random.Range(0, stageBGMs.Count);
        _audioSource.clip = stageBGMs[play];
        _audioSource.Play();
    }

    //Update Tile
    public void TileUpdate(GameObject thisTile) {
        int range, index;
        GameObject newTile;

        //Destroy Previous Tile
        if(prevTile) {
            Destroy(prevTile, 3f);
            if(pixelize) {
                GameObject effect = Instantiate(pixelize, new Vector3(_tilePos, 0, 0), new Quaternion(0, 0, 0, 0));
                Destroy(effect, 10f);
            }
        }

        //Set next tile position
        _tilePos += 50f;

        //instantiate tile and destroy tile
        range = tileA.Count; 
        index = Random.Range(0, range);
        newTile = Instantiate(tileA[index], new Vector3(_tilePos + 50f, 0, 0), new Quaternion(0, 0, 0, 0));
        newTile.transform.SetParent(GameObject.Find("Map").transform);

        prevTile = thisTile;
    }

    //Reset Player Position when fall
    public void Revive(GameObject target) {
        if(GameManager.instance) GameManager.instance.curHPUpdate(-1);
        target.transform.position = new Vector3(_tilePos + 5f, 0, target.transform.position.z);
    }
}
