using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    private int rotateDir;
    // Start is called before the first frame update
    void Start()
    {
        rotateDir = Mathf.RoundToInt(Random.Range(0, 2));
        if (rotateDir == 0){
            rotateDir = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,rotateDir);
    }
}
