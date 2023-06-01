using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Vector3 rawRotateInput;
    private float rotationSpeed = 45f;
    private float thrustPower = 100f;
    private bool isThrusting = false;

    private Rigidbody rocketRB;
    
    private void Awake() {
        rocketRB = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        ProcessRotate();
        if(isThrusting){
            ProcessThrust();
        }
    }

    private void OnRotate(InputValue value){
        rawRotateInput = value.Get<Vector2>() * -1;
    }

    private void OnThrust(InputValue value){
        isThrusting = value.isPressed;
    }

    private void ProcessRotate(){
        Vector3 rotationVector = new Vector3(0, 0, rawRotateInput.x) * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotationVector);
    }

    private void ProcessThrust(){
        Vector3 thrustDirection = transform.up * thrustPower * Time.deltaTime;
        rocketRB.AddRelativeForce(thrustDirection);
        Debug.Log(thrustDirection);
    }
}
