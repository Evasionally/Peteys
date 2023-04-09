using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomAnimator : MonoBehaviour
{
    public GameObject thisEnemy;
    private Animator mushroomAnimator;
    private bool moving;
    private bool attack;
    private float health;

    // Start is called before the first frame update
    void Start()
    {
        mushroomAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(thisEnemy != null)
        {
            health = thisEnemy.GetComponent<HealthController>().currentHealth;
            attack = thisEnemy.GetComponent<MeleeAttackController>().attacking;
            mushroomAnimator.SetBool("Attacking", attack);

            if (health <= 0)
            {
                mushroomAnimator.SetTrigger("Die");
            }
        }
    }
}
