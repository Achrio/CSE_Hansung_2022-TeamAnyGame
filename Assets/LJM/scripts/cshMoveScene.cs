using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cshMoveScene : MonoBehaviour
{
    public string SceneName;
    public AudioClip PortalAudio;
    AudioSource audioSource;

    private void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
        audioSource.clip = PortalAudio;
    }

    public GameObject portal;

    //스테이지별 포탈 프리팹마다 인덱스 지정
    //metro 포탈 stageNum = 0
    //running action 포탈 stageNum = 1
    //boss 포탈 stageNum = 2
    public int stageNum = 0;

    //전부다 미리 열어두고 싶은 경우 inspector에서 isOn true로 체크
    public bool isOn = false;

    // Start is called before the first frame update
    void Start()
    {
        if(!isOn) {
            switch(stageNum) {
                case 0 : //metro 포탈 : 기본으로 오픈
                    isOn = true;
                    break;
                case 1 : //running action 포탈 : metro 클리어시간 확인 후 오픈
                    if(GameManager.instance.clearTime[0] != 0.0f) isOn = true;
                    break;
                case 2 : //boss 포탈 : running action 클리어시간 확인 후 오픈
                    if(GameManager.instance.clearTime[1] != 0.0f) isOn = true;
                    break;
            }
        }

        if(!isOn) {
            portal.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Z) && isOn)
        {
            audioSource.Play();
            SceneManager.LoadScene(SceneName);
            SceneLoadingManager.LoadScene(SceneName);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Z) && isOn)
        {
            audioSource.Play();
            SceneLoadingManager.LoadScene(SceneName);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Z) && isOn)
        {
            audioSource.Play();
            SceneLoadingManager.LoadScene(SceneName);
        }
    }
}
