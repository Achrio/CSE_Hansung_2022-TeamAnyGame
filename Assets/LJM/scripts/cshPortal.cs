using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cshPortal : MonoBehaviour
{
    public GameObject UI;

    bool isShowing;

    // Start is called before the first frame update
    void Start()
    {
        isShowing = false;
    }

    // Update is called once per frame
    void Update()
    {
        UI.SetActive(isShowing);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F))
            showUI();
    }

    public void showUI() 
    {
        isShowing = true;
    }

    public void yes() 
    {
        SceneManager.LoadScene("LobbyScene");
    }

    public void no()
    {
        isShowing = false;
    }
}
