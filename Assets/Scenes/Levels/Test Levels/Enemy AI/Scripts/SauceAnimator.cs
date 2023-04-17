using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SauceAnimator : MonoBehaviour
{
    public GameObject thisEnemy;
    private Animator sauceAnimator;
    private bool moving;
    private bool attack;
    private float health;

    // Start is called before the first frame update
    void Start()
    {
        sauceAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(thisEnemy != null)
        {
            health = thisEnemy.GetComponent<HealthController>().currentHealth;
            attack = thisEnemy.GetComponent<RangedAttackController>().attacking;
            sauceAnimator.SetBool("Attacking", attack);

            if (health <= 4)
            {
                sauceAnimator.SetTrigger("Dizzy");
            }

            if (health <= 0)
            {
                sauceAnimator.SetTrigger("Die");
            }
        }
    }
}
