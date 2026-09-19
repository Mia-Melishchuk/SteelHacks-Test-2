using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    public float baseMovementSpeed;
    public float accelForce;
    public Rigidbody2D rb;
    public float maxSpeed, minSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocityX = baseMovementSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Keyboard.current.upArrowKey.isPressed)
        {
            print("flume");
            rb.AddForce(transform.up * 30f);
        } 

        if (Keyboard.current.rightArrowKey.isPressed && rb.linearVelocityX < maxSpeed)
        {
            rb.linearVelocityX += accelForce;
        }

        if (Keyboard.current.leftArrowKey.isPressed && rb.linearVelocityX > minSpeed)
        {
            rb.linearVelocityX -= accelForce;
        }
    }
}
