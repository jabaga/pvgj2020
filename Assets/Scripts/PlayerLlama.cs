using UnityEngine;

public class PlayerLlama : MonoBehaviour
{

    public float moveSpeed = 12f;
    public Rigidbody2D rb;
    public Animation animator;
    public Transform firepoint;

    public Transform aim;
    public GameObject bulletPrefab;
    public string playerNumber;

    public float bulletforce = 20f;

    public float bulletFireDegree = 0;
    Vector2 movement;

    void Update()
    {

        movement.x = Input.GetAxisRaw(playerNumber + "Horizontal");

        var degreeChange = Input.GetAxisRaw(playerNumber + "Vertical");
        if (degreeChange != 0)
        {
            bulletFireDegree += degreeChange;
            if (bulletFireDegree > 90)
            {
                bulletFireDegree = 90;
            }
            else if (bulletFireDegree < 0)
            {
                bulletFireDegree = 0;
            }
            ChangeAimLine(bulletFireDegree);
        }

        if (Input.GetButtonDown(playerNumber + "Fire"))
        {
            Shoot();
        }



        void Shoot()
        {
            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firepoint.right * bulletforce, ForceMode2D.Impulse);

        }

        void ChangeAimLine(float degree)
        {
            var rotation = Quaternion.Euler(0, 0, degree);
            firepoint.rotation = rotation;
            aim.rotation = rotation;
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
