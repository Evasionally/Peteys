using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator ptAnimator;

    // Start is called before the first frame update
    void Start()
    {
        ptAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ptAnimator != null)
        {
            // if running forward, left, or right
            if (Input.GetKeyDown("w") || Input.GetKeyDown("a") || Input.GetKeyDown("d"))
            {
                 ptAnimator.SetBool("IsRunning", true);
            }
            else if (Input.GetKeyUp("w") || Input.GetKeyUp("a") || Input.GetKeyUp("d"))
            {
                ptAnimator.SetBool("IsRunning", false);
            }

            if (Input.GetKeyDown("s"))
            {
                ptAnimator.SetBool("IsBacking", true);

            }
            else if (Input.GetKeyUp("s"))
            {
                ptAnimator.SetBool("IsBacking", false);
            }        

            if (Input.GetKeyDown("q"))
            {
                ptAnimator.SetTrigger("Bash");
            }
        }
    }
}
