using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//카메라 위치 설정 클래스
public class CameraPos {
    private Vector3 _playerPos;
    public void updatePlayerPos(Vector3 pos) {
        _playerPos = pos;
    }
    
    private int _view = 0;
    public void setView(int index) {
        _view = index;
    }

    private Vector3 _extra = new Vector3(0f, 0f, 0f);
    public void setExtra(Vector3 extra) {
        _extra = extra;
    }
    public void initExtra() {
        _extra = Vector3.zero;
    }

    private Vector3 _cameraPos;
    private void _switchSideView() {
        _cameraPos.x = _playerPos.x + 8f;
        _cameraPos.y = _playerPos.y + 1f;
        _cameraPos.z = _playerPos.z - 13f;
    }
    private void _switchShoulderView() {
        _cameraPos.x = _playerPos.x - 3f;
        _cameraPos.y = _playerPos.y + 1f;
        _cameraPos.z = _playerPos.z - 5f;
    }
    private void _switchTopView() {
        _cameraPos.x = _playerPos.x + 3f;
        _cameraPos.y = _playerPos.y + 8f;
        _cameraPos.z = _playerPos.z;
    }
    private void _switchQuarterView() {
        _cameraPos.x = _playerPos.x - 8f;
        _cameraPos.y = _playerPos.y + 8f;
        _cameraPos.z = _playerPos.z - 13f;
    }

    private void _setCameraPos() {
        //뷰 모드별로 위치값 설정
        switch(_view) {
            case 0 :
                _switchSideView();
                break;
            case 1 :
                _switchShoulderView();
                break;
            case 2 :
                _switchTopView();
                break;
            case 3 :
                _switchQuarterView();
                break;
            default :
                break;
        }
        _cameraPos += _extra;
    }

    public Vector3 getCameraPos() {
        _setCameraPos();
        return _cameraPos; //카메라 이동시킬 위치값 return
    }
    public float getCameraPosX() {
        _setCameraPos();
        return _cameraPos.x;
    }
}

//카메라 각도 설정 클래스
public class CameraRot {
    private int _view = 0;
    public void setView(int index) {
        _view = index;
    }

    private Vector3 _extra = new Vector3(0f, 0f, 0f);
    public void setExtra(Vector3 extra) {
        _extra = extra;
    }
    public void initExtra() {
        _extra = Vector3.zero;
    }

    private Vector3 _cameraRot;
    private void _switchSideView() {
        _cameraRot.x = 0f;
        _cameraRot.y = 0f;
        _cameraRot.z = 0f;
    }
    private void _switchShoulderView() {
        _cameraRot.x = 0f;
        _cameraRot.y = 60f;
        _cameraRot.z = 0f;
    }
    private void _switchTopView() {
        _cameraRot.x = 90f;
        _cameraRot.y = 90f;
        _cameraRot.z = 0f;
    }
    private void _switchQuarterView() {
        _cameraRot.x = 10f;
        _cameraRot.y = 60f;
        _cameraRot.z = 0f;
    }

    private void _setCameraRot() {
        //뷰 모드별로 위치값 설정
        switch(_view) {
            case 0 :
                _switchSideView();
                break;
            case 1 :
                _switchShoulderView();
                break;
            case 2 :
                _switchTopView();
                break;
            case 3 :
                _switchQuarterView();
                break;
            default :
                break;
        }
        _cameraRot += _extra;
    }

    public Vector3 getCameraRot() {
        _setCameraRot();
        return _cameraRot; //카메라 이동시킬 위치값 return
    }
}

//카메라 컨트롤
public class CameraControl : MonoBehaviour {
    private CameraPos _pos = new CameraPos();
    private CameraRot _rot = new CameraRot();
    private Transform _cameraTransform;
    private BoxCollider _cameraCollider;
    private Camera _camera;
    [SerializeField] private float _timer;

    public GameObject player;
    public float camPosSpeed = 2f;
    public float camRotSpeed = 2f;

    void Awake() {
        Application.targetFrameRate = 60;

        _camera = this.gameObject.GetComponent<Camera>();
        _cameraTransform = this.gameObject.transform;
        _cameraCollider = this.gameObject.GetComponent<BoxCollider>();

        _camera.fieldOfView = 60.0f;
    }

    void Update() {
        _pos.updatePlayerPos(player.transform.position); 
        _cameraCollider.center = transform.InverseTransformPoint(player.transform.position);

        _cameraTransform.position = new Vector3(_pos.getCameraPosX(), _cameraTransform.position.y, _cameraTransform.position.z);

        _cameraTransform.position = Vector3.Lerp(_cameraTransform.position,
            //new Vector3(_pos.getCameraPosX(), _cameraTransform.position.y, _cameraTransform.position.z), 
            _pos.getCameraPos(), camPosSpeed * Time.deltaTime);

        /*
        _cameraTransform.position = Vector3.MoveTowards(_cameraTransform.position, 
            _pos.getCameraPos(), Time.deltaTime * camPosSpeed);
        */

        _cameraTransform.rotation = Quaternion.Lerp(_cameraTransform.rotation, Quaternion.Euler(_rot.getCameraRot()), camRotSpeed * Time.deltaTime);
    }
    
    //Trigger 충돌시 처리 함수들

    private void _swtichView(int view) {
        _pos.setView(view);
        _rot.setView(view);
    }

    void OnTriggerEnter(Collider switchPoint) {
        if(switchPoint.gameObject.tag == "SideView") {
            Debug.Log("Camera : Enter SideView");
            _swtichView(0);
        }
        if(switchPoint.gameObject.tag == "ShoulderView") {
            Debug.Log("Camera : Enter ShoulderView");
            _swtichView(1);
        }
        if(switchPoint.gameObject.tag == "TopView") {
            Debug.Log("Camera : Enter TopView");
            _swtichView(2);
        }
        if(switchPoint.gameObject.tag == "QuarterView") {
            Debug.Log("Camera : Enter QuarterView");
            _swtichView(3);
        }
    }

    public void setExtraPos(Vector3 extra) {
        _pos.setExtra(extra);
    }
    public void setExtraRot(Vector3 extra) {
        _rot.setExtra(extra);
    }

    public void initExtra() {
        _pos.initExtra();
        _rot.initExtra();
    }
}
