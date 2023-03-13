using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    Rigidbody2D rBody;
    PlayerInput playerInput;
    Vector2 moveVector;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rBody.AddForce(4f * moveVector * Vector2.right);
    }

    public void OnJump(InputAction.CallbackContext context){
        if(context.action.WasPerformedThisFrame()){
            rBody.AddForce(10f * Vector2.up, ForceMode2D.Impulse);
        }
    }

    public void OnMove(InputAction.CallbackContext context){
        moveVector = context.ReadValue<Vector2>();
    }
}