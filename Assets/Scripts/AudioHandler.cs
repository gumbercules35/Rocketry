using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{

   private AudioSource source;

    private void Start() {
        source = GetComponent<AudioSource>();
    }
   public void PlayClip(AudioClip clip, float volume){
    Vector3 currentCamPos = Camera.main.transform.position;
    AudioSource.PlayClipAtPoint(clip, currentCamPos, volume);
   }

   public void LoopClip(AudioClip clip, float volume){
    source.clip = clip;
    
    if (!source.isPlaying){
        source.Play();
    }
   }
}
