using UnityEngine;

public class AstroidsRotation : MonoBehaviour
{
    private float spinSpeed = 180f;

    
    // Update is called once per frame
    void Update()
    {
         transform.Rotate(0f, 0f, spinSpeed * Time.deltaTime, Space.Self);
        
    }
}
