using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Vector3 startPosition;
    public Vector3 endPosition;
    public float speed = 1.0f;

    private void Start()
    {
        startPosition = transform.position;
        endPosition = transform.position + endPosition;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(startPosition, endPosition, Mathf.PingPong(Time.time * speed, 1));
        //transform.position = Vector3.Lerp(startPosition, endPosition, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }
}
