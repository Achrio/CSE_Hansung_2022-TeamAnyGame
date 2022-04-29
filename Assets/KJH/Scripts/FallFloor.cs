using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallFloor : MonoBehaviour
{
    [SerializeField] float fallTime = 1.0f;
    [SerializeField] float destroyTime = 2f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            PlateManger.instance.StartCoroutine("spawnPlatform",
                new Vector3(transform.position.x, transform.position.y, transform.position.z));
            Invoke("FallPlatform", fallTime);
            Destroy(gameObject, destroyTime);
        }
    }
    
    void FallPlatform()
    {
        rb.isKinematic = false;
    }
}
