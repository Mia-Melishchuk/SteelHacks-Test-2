using UnityEngine;

public class pink : MonoBehaviour
{
    public float moveSpeed;
    private float direction = 0;
    // private CircleCollider2D collider; 
    public GameObject firebolt;
    private Rigidbody2D rb;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocityX = moveSpeed;
        Debug.Log("YOOO");
        //animator = GetComponent<Animator>();
        // collider = GetComponent<CircleCollider2D>();
        for (int i = 0; i < 10; i++)
        {
            firebolt= Instantiate(firebolt, transform.position, new Quaternion(0f, 0f, 0f, 0f), transform);
            //GameObject proj = Instantiate(firebolt, transform.position, transform.rotation);
            float angle = Random.Range(-10f, 10f);
            Debug.Log("Here");
            Vector3 dir = Quaternion.AngleAxis(angle, Vector3.up) * Vector3.forward;
            firebolt.GetComponent<Rigidbody>().linearVelocity = dir * moveSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
