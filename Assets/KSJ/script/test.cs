using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    AudioSource audioSource;

    public Transform target;
    public Transform target2;
    private bool up, down;
    private bool sounds;

    public void Play()
    {
        up = true;
        down = false;
        sounds = true;
    }
    public void Play2()
    {
        down = true;
        up = false;
        sounds = true;
    }
    void Start()
    {
        if(this.gameObject.name != "elebator")
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    // Update is called once per frames
    void Update()
    {
        if (up)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, 1.0f * Time.deltaTime);
            if (sounds&&this.gameObject.name!="elebator")
            {
                Debug.Log("dd");
                this.audioSource.Play();
                sounds = false;
            }

        }
        if (down)
        {
            transform.position = Vector3.MoveTowards(transform.position, target2.position, 1.0f * Time.deltaTime);
            
            if (sounds && this.gameObject.name != "elebator")
            {
                Debug.Log("dd");
                this.audioSource.Play();
                sounds = false;
            }
        }

    }
}
