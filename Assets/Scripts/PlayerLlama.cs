using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLlama : MonoBehaviour
{
    public int numberOfHitsTaken = 0;
    public Text opponentScore;
    public float moveSpeed = 12f;
    public Rigidbody2D rb;
    public Animator animator;
    public Transform firepoint;
    public Transform aim;
    public GameObject bulletPrefab;
    public string playerNumber;

    public float bulletforce = 20f;

    public float bulletFireDegree = 0;
    Vector2 movement;

    void Start()
    {
        numberOfHitsTaken = 0;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw(playerNumber + "Horizontal");

        animator.SetBool("IsMovingForward",movement.x > 0);
        animator.SetBool("IsMovingBackward",movement.x < 0);
        
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
            if(animator.GetCurrentAnimatorStateInfo(0).IsName("Plunka") == false)
                StartCoroutine(ShootCoroutine());
            

        }

        void ChangeAimLine(float degree)
        {
            if (this.transform.localScale.x != 1)
            {
                degree *= -1;
            }
            var rotation = Quaternion.Euler(0, 0, degree);
            firepoint.rotation = rotation;
            aim.rotation = rotation;
        }
        // check for move input
        // - move player

        // check for bullet input
        // - spawn bullet prefab
        // - pass bullet variables
        opponentScore.text = numberOfHitsTaken.ToString();
    }

    IEnumerator ShootCoroutine()
    {
        animator.SetTrigger("Shoot");
        
        yield return new WaitForSeconds(0.2f);
            
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (this.transform.localScale.x == 1)
        {
            rb.AddForce(firepoint.right * bulletforce, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(-1 * firepoint.right * bulletforce, ForceMode2D.Impulse);
        }

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // check if collided with window
        // - play impact particles
        // - play SFX
        // - load RepairScene via ManagerFarm

        // check if collided with Llama
        // - play impact particles
        // - play SFX
        // - update UI via UI Score
        Debug.Log(collision.gameObject.name.Contains("Bullet"));
        if (collision.gameObject.name.Contains("Bullet"))
        {
            numberOfHitsTaken++;
        }

    }
}
