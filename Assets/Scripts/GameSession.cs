using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int score = 0;
    const int LAST_SCENE_INDEX = 4;

    void Awake()
    {
        int numberOfGameSession = FindObjectsOfType<GameSession>().Length;
        if (numberOfGameSession > 1) //force singleton
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        scoreText.text = score.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
            TakeLife();
        else
            ResetGameSession();
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }

    void TakeLife()
    {
        playerLives--;
        Heart heartScript = FindObjectOfType<Heart>();
        heartScript.getImages()[playerLives].gameObject.SetActive(false);
        if (playerLives == 1) // one life left so switch to fast beating
            heartScript.ChangeAnimation(0);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void ResetGameSession()
    {
        SceneManager.LoadScene(LAST_SCENE_INDEX);
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        FinalScore.UpdateText(score);
        Destroy(gameObject);
    }
}
