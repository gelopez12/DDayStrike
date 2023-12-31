using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayersHealth : MonoBehaviour
{
    public int maxHealth = 3; 
    public int currentHealth;
    public AudioSource HitSource;
    public int SceneIndex;

    void Start()
    {
        currentHealth = maxHealth;
        SceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Bullet3"))
        {
            currentHealth--;
            HitSource.Play();
        }
        if (collision.gameObject.CompareTag("Landmine"))
        {
            currentHealth -= currentHealth;
        }
        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over");

        // Store the current scene index in PlayerPrefs
        PlayerPrefs.SetInt("PrevSceneIndex", SceneManager.GetActiveScene().buildIndex);

        SceneManager.LoadScene("DeadScene");
    }
}
