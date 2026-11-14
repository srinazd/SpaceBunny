using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerPowerUps playerPowerUps;
    public GameObject asteroidHitEffect;
    private AudioSource audioSource;
    public CameraPostProcessing cameraEffects;

    [Header("Collision Sounds")]
    public AudioClip carrotSound;
    public AudioClip superMushroomSound;
    public AudioClip ExplosionHitSound;
    

    void Awake()
    {
        playerPowerUps = GetComponent<PlayerPowerUps>();
        audioSource = GetComponent<AudioSource>();
    }

    void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

   

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Carrot"))
        {
            GameManager.Instance.AddScore(1);
            if (cameraEffects != null)
        {
            cameraEffects.PlayScoreEffect();
        }
            FallingObject.IncreaseDifficulty();
            PlaySound(carrotSound);
            Destroy(other.gameObject);
        }

        else if (other.CompareTag("SuperMushroom"))
        {
            PlaySound(superMushroomSound);
            if (playerPowerUps != null)
            {
                playerPowerUps.ActivateSuperMushroom();
            }

            Destroy(other.gameObject);
        }

        else if (other.CompareTag("Asteroid"))
        {
    if (playerPowerUps != null &&
        playerPowerUps.IsShieldActive)
    {
        

        Debug.Log("Shield protected the bunny!");
    }
    else
    {
        PlaySound(ExplosionHitSound);

        if (asteroidHitEffect != null)
        {
            Instantiate(
                asteroidHitEffect,
              other.ClosestPoint(transform.position),
              Quaternion.identity
          );
       }
        if (cameraEffects != null)
        {
            cameraEffects.PlayHitEffect();
        }
        GameManager.Instance.LoseLife();
    }

    Destroy(other.gameObject);
}
       
    }
}
