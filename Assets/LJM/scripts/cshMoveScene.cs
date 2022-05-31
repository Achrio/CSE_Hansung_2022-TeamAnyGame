using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cshMoveScene : MonoBehaviour
{
    public string SceneName;
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(SceneName);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneLoadingManager.LoadScene(SceneName);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneLoadingManager.LoadScene(SceneName);
        }
    }
}
