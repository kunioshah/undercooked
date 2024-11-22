using UnityEngine;

public class CircleShoot : MonoBehaviour
{
    [Header("Shooting Settings")]
    public GameObject bulletPrefab;   // The bullet prefab to instantiate
    public Transform firePoint;       // The point where the bullet is fired from
    public float bulletSpeed = 5f;    // Speed of the bullet
    public float bulletLifetime = 3f; // How long the bullet lasts before disappearing
    public Transform targetPoint;     // A point where the bullet curves to (e.g., a target in front of the player)

    [Header("Curving Settings")]
    public float curveAmount = 2f;    // How strongly the bullet arcs (the higher, the more pronounced the arc)

    private Transform player;         // Reference to the player (self)

    void Start()
    {
        // Reference the player's own transform
        player = transform;
    }

    void Update()
    {
        // Detect the "Q" key press to shoot
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        CurvingBullet curvingBullet = bullet.AddComponent<CurvingBullet>();

        curvingBullet.Initialize(targetPoint.position, bulletSpeed, curveAmount, bulletLifetime);
    }

    public class CurvingBullet : MonoBehaviour
    {
        private Vector3 targetPosition; // Target position where the bullet will curve towards
        private float speed;            // Speed of the bullet
        private float curveAmount;      // How much the bullet should arc
        private float lifetime;         // How long the bullet lasts before disappearing
        private float timeElapsed = 0f; // Timer to track bullet's lifetime

        private Vector3 startPosition;  // Bullet's starting position

        // Initialization method to set parameters for curving behavior
        public void Initialize(Vector3 targetPosition, float speed, float curveAmount, float lifetime)
        {
            this.targetPosition = targetPosition;
            this.speed = speed;
            this.curveAmount = curveAmount;
            this.lifetime = lifetime;

            startPosition = transform.position;
        }

        void Update()
        {
            timeElapsed += Time.deltaTime;

            float t = timeElapsed / lifetime;

            Vector3 straightLinePosition = Vector3.Lerp(startPosition, targetPosition, t);

            float arcHeight = Mathf.Sin(t * Mathf.PI) * curveAmount; 
            Vector3 arcPosition = new Vector3(straightLinePosition.x, straightLinePosition.y + arcHeight, straightLinePosition.z);

            transform.position = arcPosition;

            // Rotate the bullet to face the direction it's moving
            Vector3 direction = (arcPosition - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);

            // Destroy the bullet once it reaches the target or the lifetime ends
            if (t >= 1f)
            {
                Destroy(gameObject);
            }
        }
    }
}
