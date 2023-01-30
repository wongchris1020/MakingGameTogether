using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float[] fireRates = new float[] { 0.5f, 0.3f, 0.8f, 1.0f };
    public float bulletSpeed = 10.0f;
    public string[] keys = new string[] { "j", "k", "l", ";" };
    public Bullet.Attribute[] bulletAttributes = new Bullet.Attribute[] { Bullet.Attribute.Water, Bullet.Attribute.Fire, Bullet.Attribute.Grass, Bullet.Attribute.Light };
    public float fireCoolDown = 0.1f;

    private float[] fireTimers;
    private float cooldownTimers;
    private bool[] keysPressed;

    private void Start()
    {
        fireTimers = new float[keys.Length];
        keysPressed = new bool[keys.Length];
    }

    private void Update()
    {
        cooldownTimers += Time.deltaTime;
        for (int i = 0; i < keys.Length; i++)
        {
            fireTimers[i] += Time.deltaTime;
            if (Input.GetKeyDown(keys[i]))
            {
                keysPressed[i] = true;
            }

            if (keysPressed[i])
            {
                if (fireTimers[i] >= fireRates[i] && cooldownTimers >= fireCoolDown)
                {
                    GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                    bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
                    bullet.GetComponent<Bullet>().attribute = bulletAttributes[i];
                    fireTimers[i] = 0.0f;
                    cooldownTimers = 0.0f;
                    keysPressed[i] = false;
                }
                keysPressed[i] = false;
            }
        }
    }

    public virtual void OnDrawGizmos()
    {
        //Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.maxAgroDistance), 0.2f);
    }

    
}
