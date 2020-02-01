using UnityEngine;

public class PlayerLlama : MonoBehaviour
{

    public float moveSpeed = 12f;
    public Rigidbody2D rb;
    public Animation animator;
    public Transform firepoint;
    public GameObject bulletPrefab;

    public float bulletforce = 20f;

    Vector2 movement;

    void Update()
    {

        movement.x = Input.GetAxisRaw("P1Horizontal");
      

        if (Input.GetButtonDown("P1Fire"))
        {
            Shoot();
        }

        void Shoot()
        {
           GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
           Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firepoint.right * bulletforce, ForceMode2D.Impulse);

        }
        // check for move input
        // - move player

        // check for bullet input
        // - spawn bullet prefab
        // - pass bullet variables
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
