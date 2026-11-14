using UnityEngine;
using System.Collections;

public class PlayerPowerUps : MonoBehaviour
{
    public GameObject shieldVisual;
    public float powerUpDuration = 5f;
    public float speedMultiplier = 1.5f;

    private PlayerController playerController;
    private Coroutine activePowerUp;
    //Coroutine: A Unity type that represents a running coroutine and allows us to pause a method temporarily and continue it later.

    public bool IsShieldActive { get; private set; }  


     void Awake()
    {
        playerController = GetComponent<PlayerController>();

        IsShieldActive = false;

        if (shieldVisual != null)
        {
            shieldVisual.SetActive(false);
        }
    }
    
      

    public void ActivateSuperMushroom()
    {
        // Restart the duration if another super mushroom is collected.
        if (activePowerUp != null)
        {
            StopCoroutine(activePowerUp);
        }

        activePowerUp = StartCoroutine(MagicPowerUpRoutine());
    }

    IEnumerator MagicPowerUpRoutine()
    //This tells Unity that this method is a coroutine
    {
        IsShieldActive = true;
        //changes a boolean variable to true. false is off, true shield is on.
        if (shieldVisual != null)
        {
            shieldVisual.SetActive(true);
        }

        if (playerController != null)
        {
            playerController.SetSpeedMultiplier(speedMultiplier);
        }

        Debug.Log("Super Mushroom activated! Shield and speed boost ON.");

        yield return new WaitForSeconds(powerUpDuration);

        IsShieldActive = false;

        if (shieldVisual != null)
        {
            shieldVisual.SetActive(false);
        }

        if (playerController != null)
        {
            playerController.SetSpeedMultiplier(1f);
        }

        Debug.Log("Super Mushroom expired! Shield and speed boost OFF.");

        activePowerUp = null;
    }
}

//When the player collects a Super Mushroom.:
//Shield activates.
// Shield visual becomes visible.
// Movement speed increases by 50%.
// A five-second timer starts.
// When the timer expires, both abilities turn off

