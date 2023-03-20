using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    Rigidbody2D rBody;
    PlayerInput playerInput;
    Vector2 moveVector;

    [SerializeField] float jumpFactor = 1;
    [SerializeField] float moveFactor = 1;
    [SerializeField] float speedLimit = 10;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xVelo = rBody.velocity.x;
        float yVelo = rBody.velocity.y;

        if (Mathf.Abs(xVelo) < speedLimit)
        {
            rBody.AddForce(moveVector * Vector2.right);
        } else
        {
            //rBody.velocity = new Vector2 (xVelo / Mathf.Abs(xVelo) * speedLimit, yVelo);
        }

    }
    public void OnMove(InputAction.CallbackContext context){// i dont actually know what this means

        moveVector = context.ReadValue<Vector2>() * moveFactor;
    }
    public void OnJump(InputAction.CallbackContext context){ 
        if(context.action.WasPerformedThisFrame()){
            rBody.AddForce(jumpFactor * Vector2.up, ForceMode2D.Impulse);
        }
    }


}