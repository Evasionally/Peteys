using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject Flamethrower;
    [SerializeField]
    private GameObject Level2Block;
    private Animator anim;
    private Collider coll;

    void Awake()
    {
        anim = Flamethrower.GetComponent<Animator>();
        coll = Flamethrower.GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        anim.enabled = true;
        StartCoroutine(TurnOffFlamethrowers());
    }

    IEnumerator TurnOffFlamethrowers()
    {
        yield return new WaitForSeconds(7);
        
        GameObject FlameThrower1 = Flamethrower.transform.GetChild(0).transform.GetChild(2).gameObject;
        GameObject FlameThrower2 = Flamethrower.transform.GetChild(1).transform.GetChild(2).gameObject;
        GameObject FlameThrower3 = Flamethrower.transform.GetChild(2).transform.GetChild(2).gameObject;
        
        coll.enabled = false;
        FlameThrower1.SetActive(false);
        FlameThrower2.SetActive(false);
        FlameThrower3.SetActive(false);
        Level2Block.SetActive(false);

    }

    
}
