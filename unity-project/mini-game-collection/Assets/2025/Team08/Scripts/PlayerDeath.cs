using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitReaction2D_NoTags : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] private Sprite playerSprite;
    [SerializeField] private Sprite explosionSprite;

    [Header("Timings")]
    [SerializeField] private float explosionSeconds = 0.5f;
    [SerializeField] private float invisibleSeconds = 1.5f;

    [Header("Movement Lock")]
    [Tooltip("Any movement/input scripts to disable during the respawn window.")]
    [SerializeField] private Behaviour[] controllersToDisable;

    [Tooltip("Also freeze the Rigidbody2D so physics can't move the player.")]
    [SerializeField] private bool freezeRigidbody2D = true;

    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private bool isProcessingHit;

    // Cache original rigidbody constraints so we can restore them.
    private RigidbodyConstraints2D originalConstraints;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        if (!sr) { Debug.LogError($"{nameof(HitReaction2D_NoTags)} needs a SpriteRenderer."); enabled = false; return; }
        if (playerSprite == null) playerSprite = sr.sprite;

        rb = GetComponent<Rigidbody2D>();
        if (rb) originalConstraints = rb.constraints;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isProcessingHit) return;
        if (!other.TryGetComponent<Bullets>(out _)) return;

        Destroy(other.gameObject);
        StartCoroutine(HandleHit());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isProcessingHit) return;
        if (!collision.collider.TryGetComponent<Bullets>(out _)) return;

        Destroy(collision.collider.gameObject);
        StartCoroutine(HandleHit());
    }

    private System.Collections.IEnumerator HandleHit()
    {
        isProcessingHit = true;

        // Lock player movement
        SetControllersEnabled(false);
        FreezeRB2D(true);

        // Stop any existing velocity
        if (rb) rb.velocity = Vector2.zero;

        // 1) Explosion sprite
        if (explosionSprite) { sr.enabled = true; sr.sprite = explosionSprite; }
        yield return new WaitForSeconds(explosionSeconds);

        // 2) Invisible window
        sr.enabled = false;
        yield return new WaitForSeconds(invisibleSeconds);

        // 3) Restore player sprite
        sr.enabled = true;
        sr.sprite = playerSprite;

        //Unlock the player controller
        FreezeRB2D(false);
        SetControllersEnabled(true);

        isProcessingHit = false;
    }

    private void SetControllersEnabled(bool enabled)
    {
        if (controllersToDisable == null) return;
        for (int i = 0; i < controllersToDisable.Length; i++)
        {
            if (controllersToDisable[i]) controllersToDisable[i].enabled = enabled;
        }
    }

    private void FreezeRB2D(bool freeze)
    {
        if (!freezeRigidbody2D || !rb) return;

        if (freeze)
        {
            // Save in case some other system modified constraints at runtime
            originalConstraints = rb.constraints;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            rb.constraints = originalConstraints;
        }
    }
}

