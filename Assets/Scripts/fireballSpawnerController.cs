using System.Threading.Tasks;
using UnityEngine;

public class fireballSpawnerController : MonoBehaviour
{
    public float moveSpeed;
    private Animator animator;
    // private CircleCollider2D collider; 
    public float damage;
    bool hitSomething;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocityX = moveSpeed;
        animator = GetComponent<Animator>();
        // collider = GetComponent<CircleCollider2D>();
        hitSomething = false;
        animator.SetBool("hitSomething", hitSomething);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       
            hitSomething = true;
            animator.SetBool("hitSomething", hitSomething);
            Task.Delay(100);
            Destroy(gameObject);
    }
   
   
}
