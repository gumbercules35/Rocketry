using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        Player player = other.gameObject.GetComponent<Player>();

        if (player != null){
            Debug.Log("Boink!");
        }
    }
}
