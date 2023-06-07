using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlink : MonoBehaviour
{
    private Light lightSource;
    // Start is called before the first frame update
    void Start()
    {
        lightSource = GetComponent<Light>();
        StartCoroutine(Blink());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Blink (){
        while (true)
        {
            lightSource.enabled = true;
            Debug.Log("Blink");
            yield return new WaitForSeconds(0.05f);
            lightSource.enabled = false;
            Debug.Log("Waiting");
            yield return new WaitForSeconds(1.5f);
        }
    }
}
