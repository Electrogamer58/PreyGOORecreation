using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlooBall : MonoBehaviour
{
    Rigidbody thisRB;
    private void Awake()
    {
       thisRB  = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (thisRB.velocity.x > 0.1f)
        {
            thisRB.velocity = new Vector3(0, 0);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Debug.Log("Gloo on ground!");
            
            thisRB.constraints = RigidbodyConstraints.FreezePositionY;
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            Debug.Log("Gloo on Wall!");

            thisRB.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        }

        if (other.tag.Equals("Player"))
        {
            thisRB.constraints = RigidbodyConstraints.FreezePosition;
        }

        else
        {
            thisRB.constraints &= ~RigidbodyConstraints.FreezePosition;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("GLOO"))
        {
            Debug.Log("GLOO touching GLOO!");
            StartCoroutine(MoveGloo(collision.gameObject));
        }
    }

    IEnumerator MoveGloo(GameObject other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        //thisRB.constraints &= ~RigidbodyConstraints.FreezePositionY;

        yield return new WaitForSeconds(0.01f);

        rb.isKinematic = false;
        rb.Sleep();
        
        thisRB.constraints = RigidbodyConstraints.FreezePositionY;
    }

}
