using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public enum Attribute { Water, Fire, Grass, Light, Dark };
    public Attribute attribute;
    [SerializeField]private Color bulletColor;
    public Color[] attributeColors;

    void Start()
    {
        bulletColor = attributeColors[(int)attribute];
        GetComponent<Renderer>().material.color = bulletColor;
    }

    void OnCollisionEnter(Collision collision)
    {
        Bullet other = collision.gameObject.GetComponent<Bullet>();
        if (other != null)
        {
            if (other.attribute == Attribute.Water && attribute == Attribute.Fire)
            {
                other.attribute = attribute;
                other.bulletColor = bulletColor;
                Destroy(gameObject);
            }
            else if (other.attribute == Attribute.Fire && attribute == Attribute.Grass)
            {
                other.attribute = attribute;
                other.bulletColor = bulletColor;
                Destroy(gameObject);
            }
            // add more else if statement for other interactions
        }
    }
}
