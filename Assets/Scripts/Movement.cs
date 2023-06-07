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
    private AudioSource playerAudioSource;
    private float initialVolume;
    private float fadeTime = 20000000f;

    private bool isEnabled = true;
    
    private void Awake() {
        rocketRB = gameObject.GetComponent<Rigidbody>();
        
    }

    private void Start() {
        playerAudioSource = gameObject.GetComponentInChildren<AudioSource>();
        initialVolume = playerAudioSource.volume;
    }
    void Update()
    {
       
       if (isEnabled){
        ProcessRotate();
        if(isThrusting){
            ProcessThrust();
        }else if (playerAudioSource.isPlaying) {
            
            playerAudioSource.Stop();
        }}
        
    }

    private void OnRotate(InputValue value){
        rawRotateInput = value.Get<Vector2>() * -1;
    }

    private void OnThrust(InputValue value){
        isThrusting = value.isPressed;
    }

    public void SetEnabled(bool toggle){
        isEnabled = false;
    }

    private void ProcessRotate(){
        Vector3 rotationVector = new Vector3(0, 0, rawRotateInput.x) * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotationVector); 
              
    }

    private void ProcessThrust(){
        if(!playerAudioSource.isPlaying){
            
            playerAudioSource.Play();
            
        }
        rocketRB.velocity = (rocketRB.velocity + new Vector3 (0, 4f, 0) * Time.deltaTime);
        Vector3 thrustDirection = Vector3.up * rotationThrustPower* Time.deltaTime;
        rocketRB.AddRelativeForce(thrustDirection);
    }
}
