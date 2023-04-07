using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{

    public float speed;
    public Rigidbody rigidPlayer;
    private Rigidbody rigid;


    //Audio source for the bounce sound effect
    public AudioSource bounceSource;
    public AudioClip bounceClip;
    

    // Start is called before the first frame update
    void Start()
    {
        rigid = transform.GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collidedWithThis)
    {
         if (collidedWithThis.transform.tag == "Damageable")
         {
             rigidPlayer.velocity = transform.up * speed;
             bounceSource.PlayOneShot(bounceClip);
         }
    }
}
