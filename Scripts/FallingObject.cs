using UnityEngine;

public class FallingObject : MonoBehaviour
{
   public float minFallSpeed = 3f;
   public float maxFallSpeed = 10f;
   private float FallSpeed = 180f;
  
   private static float difficultyMultiplier = 1f;

    void Start()
    {
        FallSpeed = Random.Range(minFallSpeed, maxFallSpeed);
    }

        void Update()
    {
        
        transform.Translate(
            Vector3.down * FallSpeed * difficultyMultiplier* Time.deltaTime, Space.World
           
        );
        if (transform.position.y < -6.5f)
        //7-0.5 which is the area around our object set for collision
        {
            Destroy(gameObject);
        }
    }

    public static void IncreaseDifficulty()
    {
        difficultyMultiplier += 0.03f;

        difficultyMultiplier = Mathf.Min(difficultyMultiplier, 10f);

        Debug.Log("Difficulty multiplier: " + difficultyMultiplier);
    }

    public static void ResetDifficulty()
    {
        difficultyMultiplier = 1f;

        //1f is normal speed
    }
}
