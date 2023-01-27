using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    public float disappearDelay = 1f;

    private BoxCollider2D collider;
    private SpriteRenderer renderer;
    private bool isDisappearing = false;

    private void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isDisappearing)
            {
                StartCoroutine(Disappear());
            }
        }
    }

    private IEnumerator Disappear()
    {
        isDisappearing = true;
        yield return new WaitForSeconds(disappearDelay);
        collider.enabled = false;
        renderer.enabled = false;
    }
}
