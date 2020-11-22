using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject blob; //the bullet
    [SerializeField] Text ammoView;
    [SerializeField] Transform barrel; //barrelend
    [SerializeField] AudioClip shoot;
    [SerializeField] Transform parentGun;
    //[SerializeField] Animator animator;
    //public AnimationClip shake;

    public float forcePower = 400;
    public int maxAmmo = 36;
    public int GLOOcounter = 0;
    public float shakeAmount = 1f;
    public float shakeSpeed = 1f;
    float fireRate = 0.10f;
    public float nextFire = 0.05f;

    private void Awake()
    {
        GLOOcounter = maxAmmo;
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            
            Debug.Log(GLOOcounter);
            if (GLOOcounter > 0)
            {
                if (Time.time > nextFire)
                {
                    AudioSource.PlayClipAtPoint(shoot, gameObject.transform.position); //play sound
                                                                                       //animation.clip = shake;
                                                                                       //animation.Play();
                                                                                       //animator.Play("Shake");

                    //StartCoroutine(ShakeGun(parentGun, 2, 1f));
                    //shake gun (or cam)
                    //StartCoroutine(Shake());


                    //shoot a gameobject called GlooBlob
                    GameObject blobHandler;

                    blobHandler = Instantiate(blob, barrel.position, barrel.rotation) as GameObject;

                    Rigidbody blobRB = blobHandler.GetComponent<Rigidbody>();

                    blobRB.AddForce(transform.forward * forcePower);

                    GLOOcounter--;
                    ammoView.text = "Ammo: " + GLOOcounter;
                    nextFire = Time.time + fireRate;



                    Destroy(blobHandler, 4f);
                }
            }
        }
    }


    /*IEnumerator Shake()
    {
        float counter = 0;
        float shakeDuration = 2;

        while (counter < shakeDuration)
        {
            counter += Time.deltaTime;

            float x = parentGun.position.x * Mathf.Sin(Time.time * shakeSpeed) * shakeAmount;
            float y = parentGun.position.y;
            float z = parentGun.position.z;
            gameObject.transform.position = new Vector3(x, y, z);
        }
    }
    */

    /*
    IEnumerator ShakeGun(GameObject objectToShake, float shakeDuration, float decreasePoint)
    {

        if (decreasePoint >= shakeDuration)
        {
            Debug.LogError("decreasePoint exeeded totalShakeDuration; Exiting");
            yield break; //Exit!
        }

        Transform defaultTransform = objectToShake.transform;
        Vector3 currentPos = defaultTransform.position;
        Quaternion defaultRot = defaultTransform.rotation;

        float counter = 0;
        float shakeSpeed = 20f;

        while (counter < shakeDuration)
        {
            counter += Time.deltaTime;
            float decrSpeed = shakeSpeed;
            defaultTransform.position = currentPos + Random.insideUnitSphere * decrSpeed;


            if (counter >= decreasePoint)
            {
                counter = 0f;
                while (counter <= decreasePoint)
                {
                    counter += Time.deltaTime;
                    decrSpeed = Mathf.Lerp(shakeSpeed, 0, counter / decreasePoint);
                    defaultTransform.position = currentPos + Random.insideUnitSphere * decrSpeed;
                }
                break;
            }
        }
        defaultTransform.position = currentPos;

    }
    */
}
