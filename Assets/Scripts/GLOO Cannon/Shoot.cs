using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject blob; //the bullet
    [SerializeField] Transform barrel; //barrelend
    public float forcePower = 200;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //shoot a gameobject called GlooBlob
            GameObject blobHandler;

            blobHandler = Instantiate(blob, barrel.position, barrel.rotation) as GameObject;

            Rigidbody blobRB = blobHandler.GetComponent<Rigidbody>();

            blobRB.AddForce(transform.forward * forcePower);

            Destroy(blobHandler, 4f);
        }
    }
}
