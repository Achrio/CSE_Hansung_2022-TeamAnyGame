using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshMainCamer_Action : MonoBehaviour
{
    public GameObject player;

    public float offsetX;
    public float offsetY;
    public float offsetZ;
    Vector3 cameraPosition;

    public float followSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        cameraPosition.x = player.transform.position.x + offsetX;
        cameraPosition.y = player.transform.position.y + offsetY;
        cameraPosition.z = player.transform.position.z + offsetZ;

        transform.position = Vector3.Lerp(transform.position, cameraPosition, followSpeed * Time.deltaTime);
    }
}
