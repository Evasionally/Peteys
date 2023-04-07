using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ConveyorBelt : MonoBehaviour
{

    [SerializeField]
    private float speed, conveyorSpeed;

    [SerializeField]
    private Vector3 direction;

    [SerializeField]
    private List<GameObject> onBelt;

    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<MeshRenderer>().material.mainTextureOffset += new Vector2(0, 1) * conveyorSpeed * Time.deltaTime;
    }

    private void FixedUpdate() 
    {
        for(int i = 0; i <= onBelt.Count - 1; i++)
        {
            onBelt[i].GetComponent<Rigidbody>().AddForce(speed * direction);
        }    
    }

    //When something collides with the belt
    private void OnCollisionEnter(Collision other) 
    {
        onBelt.Add(other.gameObject);
    }

    //When something leaves the belt
    private void OnCollisionExit(Collision collision)
    {
        onBelt.Remove(collision.gameObject);
        collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero; 
        
    }


}
