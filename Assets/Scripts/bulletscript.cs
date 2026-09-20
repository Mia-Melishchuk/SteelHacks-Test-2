using UnityEngine;

public class bulletscript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public int force = 0;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("player");
       

        Vector3 direction = player.transform.position - transform.position;
        rb.linearVelocity = new Vector3(direction.x, direction.y).normalized*force;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < 475)
        {
            Destroy(gameObject);
        }
        if (transform.position.y > 27.7 || transform.position.y <-9)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("fireball"))
        {
            Destroy(gameObject);
        }
    }
}
