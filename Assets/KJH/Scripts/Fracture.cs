using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fracture : MonoBehaviour
{
    [SerializeField] GameObject mgoPrefab = null;
    [SerializeField] float mforce = 0f;
    [SerializeField] Vector3 moffset = Vector3.zero;
    // Start is called before the first frame update
    void Awake()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Explosion();
        }
    }
        public void Explosion()
    {
        GameObject tclone = Instantiate(mgoPrefab, transform.position, Quaternion.identity);
        Rigidbody[] trigid = tclone.GetComponentsInChildren<Rigidbody>();
        for(int i = 0; i < trigid.Length; i++)
        {
            trigid[i].AddExplosionForce(mforce, transform.position + moffset, 10f);
        }
        Destroy(tclone, 3f);
        gameObject.SetActive(false);
    }
}
