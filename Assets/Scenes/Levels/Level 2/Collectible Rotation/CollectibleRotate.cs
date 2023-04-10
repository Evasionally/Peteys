using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleRotate : MonoBehaviour
{

    public float degrees = 50;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, degrees * Time.deltaTime, 0, Space.World);
    }
}
