using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjects : MonoBehaviour {
    public int money = 100;
    public AudioSource audioSource;
    public Collider trigger;
    public MeshRenderer mesh;
    public List<AudioClip> coinSounds;

    void Awake() {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }
    void Update() {
        this.gameObject.transform.Rotate(new Vector3(0f, 60f, 0f) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider player) {
        if(player.tag == "Player") {
            if(GameManager.instance) {
                GameManager.instance.MoneyUpdate(money);

                int play = Random.Range(0, coinSounds.Count);
                audioSource.clip = coinSounds[play];
                audioSource.Play();

                mesh.enabled = false;
                trigger.enabled = false;

                Destroy(this.gameObject, 3f);
            }
        }
    }
}
