using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayersHealth : MonoBehaviour
{
    public int maxHealth = 3; 
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            currentHealth--;

            if (currentHealth <= 0)
            {
                GameOver();
            }
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene("HomeScreen");
    }
}
