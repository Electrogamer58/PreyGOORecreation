using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject glooBall;
    public float forcePower = 300;
    
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            Debug.Log("Hit Ground");


            Instantiate(glooBall, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject, 0);
        }
    }
}
