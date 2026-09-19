using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocityX = 10f;

        if (Keyboard.current.upArrowKey.isPressed)
        {
            print("flume");
            rb.AddForce(transform.up * 30f);
        } 
    }
}
