using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour
{
    private PalyerInput playerInput; //Reference to PlayerInput class
    private PalyerInput.OnFootActions onFoot;

    private PlayerMotor motor;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PalyerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //tell the player motor to move using the values in input action

        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}

