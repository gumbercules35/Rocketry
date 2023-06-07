using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    Movement playerMovement;
    private bool hasCollided;

    private void Awake() {
        playerMovement = GetComponent<Movement>();
    }
    private void OnCollisionEnter(Collision other) {
        string collidedTag = other.gameObject.tag;
        
        switch (collidedTag)
        {
            case "FinishPad":
                if (!hasCollided){
                    StartCoroutine(LoadNextScene());                    
                    hasCollided = true;
                }
                break;
            case "Obstacle":
                if (!hasCollided){
                    StartCoroutine(ReloadScene());
                    hasCollided = true;
                }
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
