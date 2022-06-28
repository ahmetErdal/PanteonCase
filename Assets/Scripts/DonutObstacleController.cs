using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutObstacleController : MonoBehaviour
{
    [SerializeField] private GameObject donutStick;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        donutStick.transform.Rotate(50 * Time.deltaTime, 0, 0);
    }
}
