using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector2.left * GameManagerScript.Instance.GetScrollSpeed() * Time.deltaTime);
    }
}
