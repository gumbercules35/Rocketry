using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityScale : MonoBehaviour
{
    private Rigidbody playerRB;
    private float gravityScale = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
       playerRB.AddForce(Physics.gravity * gravityScale, ForceMode.Acceleration); 
    }
}
