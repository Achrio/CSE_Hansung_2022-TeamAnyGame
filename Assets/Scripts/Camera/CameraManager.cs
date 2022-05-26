using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    [HideInInspector] public static CameraManager instance;

    private GameObject _player;
    private Vector3 _curPlayerPos; //player's current position
    public Vector3 defaultPos = new Vector3(8, 3, -13);     //camera Default Pos

    //Camera Move Parameters
    private Vector3 _movePos;     //wanted camera position
    private Vector3 _actualPos;   //actual camera Position (player position + extra value)

    private Vector3 _moveRot;     //wanted camera position

    [Header ("Camera Move Speed")]
    public float camPosSpeed = 2f;
    public float camRotSpeed = 2f;

    //Camera Shake Parameters
    [HideInInspector] public bool isShake = false;
    private float _shakeTimer;
    private float _shakeTime;
    private float _shakeIntensity;


    void Awake() {
        instance = this;
        _player = GameObject.Find("Player");
        _movePos = defaultPos;
    }

    void Update() {
        _curPlayerPos = _player.transform.position; //update value to player position
        
        //move camera pos
        //1. move to player x pos -> 2. move smoothly to wanted y and z pos
        _actualPos = _curPlayerPos + _movePos;
        transform.position = new Vector3(_actualPos.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, _actualPos, camPosSpeed * Time.deltaTime);

        //move camera rot
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_moveRot), camRotSpeed * Time.deltaTime);

        //shake camera for (time)seconds by (intensity)
        if(isShake) {
            _shakeTimer += Time.deltaTime;
            transform.position = transform.position + (Random.insideUnitSphere * _shakeIntensity);

            if(_shakeTimer >= _shakeTime) {
                isShake = false;
                _shakeTimer = 0f;
            }
        }
    }

    public void setPos(Vector3 movePos) {
        _movePos = movePos;
    }
    public void setRot(Vector3 moveRot) {
        _moveRot = moveRot;
    }
    public void setShake(float time, float intensity) {
        _shakeTime = time;
        _shakeIntensity = intensity;
    }
}
