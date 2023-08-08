using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    Rigidbody2D rBody;
    PlayerInput playerInput;
    Vector2 moveVector;
    bool airborne;

    [SerializeField] float jumpFactor = 1;
    [SerializeField] float moveFactor = 1;
    [SerializeField] float speedLimit = 10;

    

    void Start()
    {
        airborne = true;
        rBody = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        float xVelo = rBody.velocity.x;
        float yVelo = rBody.velocity.y;

        rBody.AddForce(moveVector * Vector2.right);
        if (Mathf.Abs(xVelo) > speedLimit)
        {
            rBody.velocity = new Vector2(xVelo / Mathf.Abs(xVelo) * speedLimit, yVelo);
        }
    }

    public void OnMove(InputAction.CallbackContext context){ //i dont actually know what this means

        moveVector = context.ReadValue<Vector2>() * moveFactor;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.action.WasPerformedThisFrame())
        {
            if (!airborne)
            {
                rBody.AddForce(jumpFactor * Vector2.up, ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        airborne = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        airborne = true;
    }
}