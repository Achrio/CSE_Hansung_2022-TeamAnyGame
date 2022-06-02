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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            audioSource.Play();
            SceneManager.LoadScene(SceneName);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            audioSource.Play();
            SceneLoadingManager.LoadScene(SceneName);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            audioSource.Play();
            SceneLoadingManager.LoadScene(SceneName);
        }
    }
}
