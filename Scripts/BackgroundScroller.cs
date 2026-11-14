using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 1.5f;
    public float resetY = -9f;
    public float startY = 9f;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(
            Vector3.down * scrollSpeed * Time.deltaTime
        );

        if (transform.position.y <= resetY)
        {
            transform.position =  new Vector3(
                transform.position.x, 
                startY,
                 transform.position.z
            );
        }
    }
}
