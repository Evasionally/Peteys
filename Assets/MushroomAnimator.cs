using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomAnimator : MonoBehaviour
{
    private Animator mushroomAnimator;
    private bool moving;
    private bool attack;

    // Start is called before the first frame update
    void Start()
    {
        mushroomAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        attack = GameObject.Find("Enemy").GetComponent<MeleeAttackController>().attacking;
        mushroomAnimator.SetBool("Attacking", attack);
    }
}
