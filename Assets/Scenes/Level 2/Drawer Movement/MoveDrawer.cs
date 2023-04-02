using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDrawer : MonoBehaviour
{

    //Speed of the drawer movement - set in Unity editor
    [SerializeField]
    private float objectSpeed;

    //Which drawer to move - set in Unity editor
    [SerializeField]
    private GameObject drawerToMove;
    
    //Store the target position
    private Vector3 targetPos;

    //Int to store the index of positions arr
    private bool reachedTarget = false;

    //Bool to determine if the drawer has been pulled/if its time to start movement
    private bool startMovement = false;

    


    // Start is called before the first frame update
    void Start()
    {
        switch(drawerToMove.name)
        {
            case "MovingPart_Bottom":
            {
                targetPos = new Vector3(-5f, 0f, 0f);
                break;
            }
            case "MovingPart_Middle":
            {
                targetPos = new Vector3(-3f, 0f, 0f);
                break;
            }
            case "MovingPart_Top":
            {
                targetPos = new Vector3(-1f, 0f, 0f);
                break;
            }
        }
    }

    // Update is called once per frame
    public void Update()
    {
        if(startMovement == true && reachedTarget == false)
        {
            MoveGameObject();
        }
    }

    void MoveGameObject()
    {
        if(drawerToMove.transform.localPosition == targetPos)
        {
            reachedTarget = true;
        }
        else
        {

            drawerToMove.transform.localPosition = Vector3.MoveTowards(drawerToMove.transform.localPosition, targetPos, objectSpeed * Time.deltaTime);
        }
    }

    public void startMovementFunction()
    {
        Debug.Log("inside function");

        startMovement = true;
    }
}
