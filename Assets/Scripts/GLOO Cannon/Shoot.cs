using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject blob; //the bullet
    [SerializeField] Transform barrel; //barrelend
    public float forcePower = 400;
    public float maxAmmo = 36;
    
    public float GLOOcounter = 0;

    private void Awake()
    {
        GLOOcounter = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(GLOOcounter);
            if (GLOOcounter < maxAmmo)
            {
                //shoot a gameobject called GlooBlob
                GameObject blobHandler;

                blobHandler = Instantiate(blob, barrel.position, barrel.rotation) as GameObject;

                Rigidbody blobRB = blobHandler.GetComponent<Rigidbody>();

                blobRB.AddForce(transform.forward * forcePower);

                GLOOcounter++;

                Destroy(blobHandler, 4f);
            }
        }
    }
}
