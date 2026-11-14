using UnityEngine;


//spawner creates carrots and asteroids automatically at random horizontal positions in the camera view. It uses InvokeRepeating to create new objects at regular time intervals.
public class Spawner : MonoBehaviour
{
   public GameObject carrot;
   public GameObject asteroid;

   public GameObject SuperMushroom;

   public float minSpawnTime = 0.05f;
   public float maxSpawnTime = 0.3f;
public float spawnTime;
   void Start()
    {
    

        InvokeRepeating(nameof(SpawnObject), 1f, spawnTime) ;
       }

    // Update is called once per frame
    void SpawnObject()
{
    int numberOfObjects = Random.Range(1, 5);

    for (int i = 0; i < numberOfObjects; i++)
    {
        float randomX = Random.Range(-8f, 8f);

        Vector3 position = new Vector3(
            randomX,
            6f,
            0f
        );

        float randomValue = Random.value;

        if (randomValue < 0.08f)
        {
            Instantiate(SuperMushroom, position, Quaternion.identity);
        }
        else if (randomValue < 0.5f)
        {
            Instantiate(carrot, position, Quaternion.identity);
        }
        else
        {
            Instantiate(asteroid, position, Quaternion.identity);
        }
    }
}
}

