using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject[] bulletPrefabs;
    public Transform bulletSpawn;
    public float fireRate = 0.5f;
    public int bulletCount = 10;
    public float spreadAngle = 10f;
    public float bulletSpeed = 10f;
    public float bulletRange = 10f;
    private float nextFire = 0.0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
        }
    }

    void Fire()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject bulletPrefab = bulletPrefabs[Random.Range(0, bulletPrefabs.Length)];
            Quaternion bulletRotation = Quaternion.Euler(0, 0, Random.Range(-spreadAngle, spreadAngle));
            var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletRotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * bulletSpeed;
            Destroy(bullet, bulletRange / bulletSpeed);
        }
    }
}
