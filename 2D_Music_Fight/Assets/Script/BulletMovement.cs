using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float bulletSpeed=5f;

    void Start()
    {
        float random = Random.Range(0f, 360f);
        transform.Rotate(0, 0, random);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * Random.Range(0f,bulletSpeed);
    }
}
