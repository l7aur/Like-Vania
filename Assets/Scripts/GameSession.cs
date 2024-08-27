using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    
    void Awake()
    {
        int numberOfGameSession = FindObjectsOfType<GameSession>().Length;
        if (numberOfGameSession > 1) //force singleton
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
            TakeLife();
        else
            ResetGameSession();
    }

    void TakeLife()
    {
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

    }

    void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
