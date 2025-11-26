using UnityEngine;

public class PowerupPenetration : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] private Sprite closedChest;
    [SerializeField] private Sprite openChest;

    [Header("Som")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip openSound;

    private bool opened = false;
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = closedChest;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (opened) return;

        if (collision.CompareTag("Player"))
        {
            opened = true;

            PlayerShootPowerups.Instance.bulletPenetration = true;
            Debug.Log("Power-up de Penetração Ativado!");

            sr.sprite = openChest;

            if (audioSource != null && openSound != null)
                audioSource.PlayOneShot(openSound);

            Destroy(gameObject, 1.5f);
        }
    }
}