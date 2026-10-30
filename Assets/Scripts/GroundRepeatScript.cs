using UnityEngine;

public class GroundRepeatScript : MonoBehaviour
{
    private float groundLength;
    void Start()
    {
        BoxCollider2D groundCollider = GetComponent<BoxCollider2D>();
        groundLength = groundCollider.size.x;
    }

    void Update()
    {
        if(transform.position.x < -groundLength)
        {
            transform.Translate(Vector2.right * 2f * groundLength);
        }
    }
}
