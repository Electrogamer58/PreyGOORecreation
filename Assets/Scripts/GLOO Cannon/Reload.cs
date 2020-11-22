using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reload : MonoBehaviour
{
    [SerializeField] Shoot shoot;
    [SerializeField] Text ammoView;
    [SerializeField] AudioClip reload;
    [SerializeField] Animator animator;

    public int numCanisters = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && numCanisters > 0)
        {
            //play reload animation
            //refresh or change text on cannon screen
            AudioSource.PlayClipAtPoint(reload, gameObject.transform.position);
            animator.SetTrigger("Reload");
            shoot.GLOOcounter = shoot.maxAmmo;
            numCanisters -= 1;
            Debug.Log("RELOAD");
            ammoView.text = "Ammo: " + shoot.GLOOcounter;
            
        }
    }
}
