using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private Vector3 resetPosition;
    private Rigidbody playerRB;
    // Start is called before the first frame update
    void Start()
    {
       resetPosition = transform.position;
       playerRB = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyUp(KeyCode.R)){
            transform.position = resetPosition;
            transform.rotation = Quaternion.identity;
            playerRB.velocity = new Vector3(0,0,0);
        }
    }
}
