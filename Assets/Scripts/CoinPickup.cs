using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinSFX;
    [SerializeField] float volume = 10f;
    [SerializeField] int points = 1;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<GameSession>().AddScore(points);
            AudioSource.PlayClipAtPoint(coinSFX, Camera.main.transform.position, volume);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        
    }
}
