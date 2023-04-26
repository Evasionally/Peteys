using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    private Animator animator;
    
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.enabled = true;
        StartCoroutine(TurnOffAnimation());
    }

    IEnumerator TurnOffAnimation()
    {
        yield return new WaitForSeconds(2);
        animator.enabled = false;
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
