using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroccAnimator : MonoBehaviour
{
    public GameObject thisEnemy;
    private Animator broccAnimator;
    private float health;

    // Start is called before the first frame update
    void Start()
    {
        broccAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(thisEnemy != null)
        {
            health = thisEnemy.GetComponent<HealthController>().currentHealth;
            if (health <= 0)
            {
                broccAnimator.SetTrigger("Die");
            }
        }  
    }
}
