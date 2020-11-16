using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject glooBall;
    
    Rigidbody rb;
    Player target = null;
    Vector3 nudgeDirection; //direction in which to nudge the gloo

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Physics.IgnoreLayerCollision(11, 9);
        target = FindObjectOfType<Player>();
        nudgeDirection = (target.transform.position - transform.position).normalized;
    }
    

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.layer == 8)
        {
            Debug.Log("Hit Ground");


            Instantiate(glooBall, gameObject.transform.position + new Vector3(0, -0.4f, 0), Quaternion.identity);
            Destroy(gameObject, 0);
        }
        if (other.collider.gameObject.layer == 10)
        {
            Debug.Log("Hit Wall");

            

            Instantiate(glooBall, gameObject.transform.position + new Vector3(nudgeDirection.x * -0.9f, 0, nudgeDirection.z * -0.9f), Quaternion.identity);
            Destroy(gameObject, 0);
        }
    }
}
