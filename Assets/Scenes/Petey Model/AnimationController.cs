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
            if (Input.GetKeyDown("w"))
            {
                 ptAnimator.SetBool("IsRunning", true);
            }
            else if (Input.GetKeyUp("w"))
            {
                ptAnimator.SetBool("IsRunning", false);
            }
        }
    }
}
