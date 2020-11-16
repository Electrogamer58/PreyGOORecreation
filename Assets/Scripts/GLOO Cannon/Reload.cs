using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
    [SerializeField] Shoot shoot;
    public int numCanisters = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && numCanisters > 0)
        {
            //play reload animation
            //refresh or change text on cannon screen
            shoot.GLOOcounter = 0;
            numCanisters -= 1;
            Debug.Log("RELOAD");
        }
    }
}
