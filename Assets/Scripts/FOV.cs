using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FOV : MonoBehaviour
{
    PolygonCollider2D fov;
    [SerializeField] Animator animator;

    void Start()
    {
        fov = GetComponent<PolygonCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            animator.SetBool("seenPlayer", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            animator.SetBool("seenPlayer", false);
    }
}
