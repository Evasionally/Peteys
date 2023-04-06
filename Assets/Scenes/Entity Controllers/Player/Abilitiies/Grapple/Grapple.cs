using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, camera, player;
    public float spring, damper, massScale;
    private float maxDistance = 100f;
    private SpringJoint joint;
    public bool going;



    //Edit by Andy - initialize the moveDrawer script and find it during Start
    MoveDrawer moveDrawerScript;
    void Start() 
    {   
        moveDrawerScript = FindObjectOfType<MoveDrawer>();
    }

    void Awake() 
    {
        lr = GetComponent<LineRenderer>();

    }

    void Update()
    {
        DrawRope();

        if (Input.GetKeyDown(KeyCode.E))
        {
            StartGrapple();
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            StopGrapple();
        }
    }

    void LateUpdate()
    {
        DrawRope();
    }

    void StartGrapple()
    {
        RaycastHit hit;
        going = true;

        if(Physics.Raycast(origin: camera.position, direction: camera.forward, out hit, maxDistance, whatIsGrappleable))
        {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(a: player.position, b: grapplePoint);

            //Distance cheese will try to stay between
            joint.maxDistance = distanceFromPoint * 0.5f;
            joint.minDistance = distanceFromPoint * 0.2f;
            
            //Spring sensitvity settings (can be modified)
            joint.spring = spring;
            joint.damper = damper;
            joint.massScale = massScale;

            lr.positionCount = 2;

            //Edit by Andy - if the grapple is hitting a drawer/stair, call the MoveDrawer script
            if(hit.collider.gameObject.tag == "DrawerStairHandle")
            {
                Debug.Log(hit.collider.gameObject.name);

                hit.collider.gameObject.GetComponent<MoveDrawer>().startMovementFunction();

                Debug.Log("function called");


            }

        }
    }

    void StopGrapple()
    {
        going = false;
        lr.positionCount = 0;
        Destroy(joint);
    }

    void DrawRope()
    {
        //Line will go away when not grappling
        if (!joint) return;

        lr.SetPosition(index: 0, gunTip.position);
        lr.SetPosition(index: 1, grapplePoint);
    }
}
