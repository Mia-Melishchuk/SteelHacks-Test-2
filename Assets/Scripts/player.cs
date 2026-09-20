using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    public float baseMovementSpeedX, baseMovementSpeedY;
    public float accelForce;
    public Rigidbody2D rb;
    public float maxSpeed, minSpeed, upperBound;

    public float maxYSpeed;
    public GameObject fireballPrefab;
    private Animator animator;
    bool isFlying;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject gameOverText;
    int coinCounter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocityX = baseMovementSpeedX;
        animator = GetComponent<Animator>();
        fireballPrefab.gameObject.transform.localScale = transform.localScale/8.67f;
        coinCounter = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // lower bound
        if (transform.position.y <= -upperBound)
        {
            transform.position = new Vector3(transform.position.x, -upperBound, transform.position.z);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        }

        // upper bound
        if (transform.position.y >= upperBound)
        {
            transform.position = new Vector3(transform.position.x, upperBound, transform.position.z);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        }

        if (Keyboard.current.upArrowKey.isPressed)
        {
            rb.AddForce(transform.up * baseMovementSpeedY);
            // clamps the dragons max up speed
            if (rb.linearVelocityY > maxYSpeed) rb.linearVelocity = new Vector2(rb.linearVelocityX, maxYSpeed);
            isFlying = true;
        } else
        {
            isFlying = false;
        }
        animator.SetBool("isFlying", isFlying);

        if (Keyboard.current.downArrowKey.isPressed)
        {
            rb.AddForce(transform.up * -baseMovementSpeedY/2);
        } 

        if (Keyboard.current.rightArrowKey.isPressed && rb.linearVelocityX < maxSpeed)
        {
            rb.linearVelocityX += accelForce;
        }

        if (Keyboard.current.leftArrowKey.isPressed && rb.linearVelocityX > minSpeed)
        {
            rb.linearVelocityX -= accelForce;
        }

        // fire fireball :)
    }

    /*void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Instantiate(fireballPrefab, transform.position + new Vector3(3f, -0.263f, 0), new Quaternion(0f, 0f, 0f, 0f), transform);
        }
    }
    */

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            gameOverText.gameObject.SetActive(true);
            gameObject.SetActive(false);
            enemy1.GetComponent<Animator>().SetBool("Attack", false);
            enemy2.GetComponent<Animator>().SetBool("Attack", false);
        }
        //dies on spikes
        if (collision.gameObject.CompareTag("spikes"))
        {
            gameOverText.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            coinCounter++;
        }
    }

    public int getCoins()
    {
        return coinCounter;
    }
}
