using System;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            GameManager.instance.GameOver();
        }
    }
    
}
