using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisarmFire : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gloo"))
        {
            this.gameObject.SetActive(false);
            Debug.Log("Hit");
        }
    }
}
