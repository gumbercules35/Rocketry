using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{

   public AudioSource source;


    private void Start() {
        source = GetComponent<AudioSource>();
    }
   public void PlayClip(AudioClip clip){
    
    source.PlayOneShot(clip);
   }

}
