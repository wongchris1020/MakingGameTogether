using UnityEngine;

public class PlayerExplosion : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int bulletCount = 20;
    public float bulletSpeed = 10.0f;
    public float angleRange = 45.0f;
    public float explosionRadius = 5.0f;
    public float senserIndex = 0.1f;
    public Transform GroundPoint;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("KeyGround"))
        {
            float fallingSpeed = rb.velocity.y;
            int bulletCountModifier = (int)(-fallingSpeed * senserIndex);
            Debug.Log("bulletCountModifier=" + bulletCountModifier);
            int finalBulletCount = bulletCountModifier;
            float finalBulletSpeed = bulletSpeed - fallingSpeed;

            for (int i = 0; i < finalBulletCount; i++)
            {
                float angle = Random.Range(-angleRange, angleRange);
                Vector2 direction = Quaternion.Euler(0, 0, 90+angle) * Vector2.right;
                Vector2 position = (Vector2)GroundPoint.transform.position;
                GameObject bullet = Instantiate(bulletPrefab, position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = direction * finalBulletSpeed;
            }
        }
    }
}
