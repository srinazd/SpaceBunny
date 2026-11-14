
using UnityEngine;

public class ExplosionAutoDestroy : MonoBehaviour
{
    public float destroyAfter = 0.8f;

    void Start()
    {
        Destroy(gameObject, destroyAfter);
    }
}

