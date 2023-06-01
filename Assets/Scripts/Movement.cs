using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Vector3 rawRotateInput;
    private float rotationSpeed = 65f;
    [SerializeField] private float rotationThrustPower = 120f;

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
        rocketRB.velocity = (rocketRB.velocity + new Vector3 (0, 4f, 0) * Time.deltaTime);
        Vector3 thrustDirection = Vector3.up * rotationThrustPower* Time.deltaTime;
        rocketRB.AddRelativeForce(thrustDirection);
    }
}
