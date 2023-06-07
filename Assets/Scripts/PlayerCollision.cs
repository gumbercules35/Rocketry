using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    Movement playerMovement;
    private bool hasCollided;
    private AudioHandler audioHandler;
    [SerializeField] private AudioClip explodeSFX;
    [SerializeField] private ParticleSystem explodeParticles;
    [SerializeField] private AudioClip landedSFX;
 
    private void Awake() {
        playerMovement = GetComponent<Movement>();

    }
    private void Start() {
        audioHandler = GetComponentInChildren<AudioHandler>();
    }
    private void OnCollisionEnter(Collision other) {
        if (hasCollided){
            return;
        }

        string collidedTag = other.gameObject.tag;

        switch (collidedTag)
        {
            case "FinishPad":
                    other.gameObject.GetComponentInChildren<ParticleSystem>().Play();
                    audioHandler.source.Stop();
                    audioHandler.PlayClip(landedSFX);
                    StartCoroutine(LoadNextScene());                    
                    hasCollided = true;
                break;
            case "Obstacle":
                    explodeParticles.Play();
                    audioHandler.source.Stop();
                    audioHandler.PlayClip(explodeSFX);
                    StartCoroutine(ReloadScene());
                    hasCollided = true;
                break;
            default:
                break;
        }
    }

    private IEnumerator ReloadScene(){
        playerMovement.SetEnabled(false);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator LoadNextScene(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings){
            nextSceneIndex = 0;
        }

        playerMovement.SetEnabled(false);

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(nextSceneIndex);
    }
}
