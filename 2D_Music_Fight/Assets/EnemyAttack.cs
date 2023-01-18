using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 1.0f;
    public float bulletSpeed = 10.0f;
    public int bulletCount = 3;
    public float spread = 10.0f;
    public float randomAngle = 10.0f;
    public float bulletRange = 10f;

    private float fireTimer = 0.0f;
    public float shootingDirection = 1f;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector2 direction = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));
        for (float angle = -randomAngle; angle <= randomAngle; angle += 0.1f)
        {
            direction.x = shootingDirection*Mathf.Cos(angle * Mathf.Deg2Rad);
            direction.y = shootingDirection*Mathf.Sin(angle * Mathf.Deg2Rad);
            Vector2 position = (Vector2)transform.position + direction * 2;
            Gizmos.DrawSphere(position, 0.1f);
        }
    }
    private void Update()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer >= fireRate)
        {
            // Choose a random shooting pattern
            int pattern = Random.Range(0, 3);
            Debug.Log("pattern=" + pattern);
            switch (pattern)
            {
                case 0:
                    // Single bullet
                    Fire();
                    break;
                case 1:
                    // Spread shot
                    SpreadFire();
                    break;
                case 2:
                    // Rapid fire
                    RapidFire();
                    break;
            }

            fireTimer = 0.0f;
        }
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        float angle = Random.Range(-randomAngle, randomAngle) * Mathf.Deg2Rad;
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        bullet.GetComponent<Rigidbody2D>().velocity = shootingDirection * direction * bulletSpeed;
        Destroy(bullet, bulletRange / bulletSpeed);
    }

    private void SpreadFire()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            float angle = Random.Range(-randomAngle, randomAngle) * Mathf.Deg2Rad;
            float angle2 = Random.Range(-randomAngle, randomAngle) * Mathf.Deg2Rad;
            Vector2 randomDirection = new Vector2(Mathf.Cos(angle2), Mathf.Sin(angle2));
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            bullet.GetComponent<Rigidbody2D>().velocity = shootingDirection * (direction + randomDirection) * bulletSpeed *0.5f;
            Destroy(bullet, bulletRange / bulletSpeed);
        }
    }

    private void RapidFire()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            float angle = Random.Range(-randomAngle, randomAngle) * Mathf.Deg2Rad;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            bullet.GetComponent<Rigidbody2D>().velocity = shootingDirection * direction * bulletSpeed;
            Destroy(bullet, bulletRange / bulletSpeed);
        }
    }
}

