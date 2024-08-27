using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField] float timeUntilNextScene = 1.0f;
    [SerializeField] int numberOfScenes = 3;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
            StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(timeUntilNextScene);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene((currentSceneIndex + 1) % numberOfScenes);
    }
}
