using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingObstacle : MonoBehaviour
{
    private Vector3 startingPosition;
    [SerializeField]private Vector3 movementVector;
    private float movementFactor = 0.5f;
    //How long one complete wave takes
    [SerializeField] private float oscillatePeriod = 4f;

    void Start()
    {
        //Log starting transform to oscillate around
        startingPosition = transform.position;
    }


    void Update()
    {
        //NaN protection, uses Mathf.Epsilon to avoid weird == 0f comparisons
        if (oscillatePeriod <= Mathf.Epsilon) { return; }
        //Divide current time passed by defined time to complete one wave to give how many "cycles" of the wave have passed
        float cycles = Time.time / oscillatePeriod;
        //Declare tau as a constant, tau is one full period in radians = 6.283
        const float tau = Mathf.PI * 2; 
        //Return value of current position in sine wave 
        float rawSineWave = Mathf.Sin(cycles * tau);
        //Normalise this value from -1 - +1 to 0 - +1
        movementFactor = (rawSineWave + 1f) / 2f;
        //Create the new Vector position by multiplying the given movementVector (in inspector, details total deviation from startingPos)
        //by the current position on the sine wave (movementFactor)
        Vector3 offset = movementVector * movementFactor;
        //Set the position of the gameObject to this new position
        transform.position = startingPosition + offset;
    }
}
