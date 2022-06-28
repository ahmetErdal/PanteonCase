using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotateMovement : MonoBehaviour
{
     public bool isRight;
   


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRight==true)
        {
            transform.Rotate(0, 0, 50 * Time.deltaTime);
        }
        else
        {
            transform.Rotate(0, 0, -50 * Time.deltaTime);
        }
    }
}
