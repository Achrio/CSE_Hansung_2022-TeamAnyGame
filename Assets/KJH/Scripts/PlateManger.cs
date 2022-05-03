using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateManger : MonoBehaviour
{   
    public static PlateManger instance = null;
    [SerializeField] GameObject platform;
    [SerializeField] float posX1, posX2, posX3, posY;
    [SerializeField] float spawnTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        Instantiate(platform, new Vector3(posX1, posY, 0), platform.transform.rotation);
    }

    // Update is called once per frame
    IEnumerator spawnPlatform(Vector3 spawnPos)
    {
        yield return new WaitForSeconds(spawnTime);
        Instantiate(platform, spawnPos, platform.transform.rotation);
    }
}
