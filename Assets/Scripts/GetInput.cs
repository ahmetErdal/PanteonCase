using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInput : MonoBehaviour
{
    [Header("Specs: ")]
    public float forwardSpeed;
    public float horizontalSpeed;
    [Space]
    public float wallDist;
    [Space]
    private Vector2 oldPos;
    public float HInput;
    public float horizontalMovement;
    public float horizontalMovementSmoothness;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetTheInput();
        MovePLayer();
        LimitPos();
    }
    void GetTheInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            oldPos = Input.mousePosition;

        }
        if (Input.GetMouseButton(0))
        {
            HInput = Input.mousePosition.x - oldPos.x;
            oldPos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            HInput = 0;
        }
    }
    void MovePLayer()
    {
        horizontalMovement = Mathf.Lerp(horizontalMovement, HInput * horizontalSpeed, horizontalMovementSmoothness * Time.deltaTime);
        Vector3 moveVector = new Vector3(horizontalMovement, 0, forwardSpeed);
        transform.Translate(moveVector * Time.deltaTime);
    }
    void LimitPos()
    {
        Vector3 clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, -wallDist, wallDist);
        transform.position = clampedPos;

    }
}
