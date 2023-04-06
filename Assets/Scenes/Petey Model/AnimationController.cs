using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator ptAnimator;
    bool IsGrounded;
    bool Grappling; 

    // Start is called before the first frame update
    void Start()
    {
        ptAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded = GameObject.Find("Petey").GetComponent<PlayerMovement>().grounded;
        Grappling = GameObject.Find("Petey").GetComponent<Grapple>().going;
        ptAnimator.SetBool("Grounded", IsGrounded);
        ptAnimator.SetBool("IsSwinging", Grappling);

        if (ptAnimator != null)
        {

            // if running forward, left, or right play forward run
            if ((Input.GetKeyDown("w") || Input.GetKeyDown("a") || Input.GetKeyDown("d")))
            {
                 ptAnimator.SetBool("IsRunning", true);
            }
            else if ((Input.GetKeyUp("w") || Input.GetKeyUp("a") || Input.GetKeyUp("d")))
            {
                ptAnimator.SetBool("IsRunning", false);
            }

            // if running back, play back run
            if (Input.GetKeyDown("s"))
            {
                ptAnimator.SetBool("IsBacking", true);

            }
            else if (Input.GetKeyUp("s"))
            {
                ptAnimator.SetBool("IsBacking", false);
            }        

            // If bashing play bash animation
            if (Input.GetKeyDown("q"))
            {
                ptAnimator.SetTrigger("Bash");
            }

            // If jumping play jump
            if (Input.GetKeyDown("space"))
            {
                ptAnimator.SetTrigger("Jump");
            } 

            // if (IsSwinging == true)
            // {
            //     ptAnimator.SetTrigger("StartSwing");
            //     ptAnimator.SetBool("IsSwinging", true);
            // }
            // else if (IsSwinging == false)
            // {
            //     ptAnimator.SetBool("IsSwinging", false);
            // }            
        }
    }
}
