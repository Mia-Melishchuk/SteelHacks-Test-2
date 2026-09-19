using UnityEngine;

public class fireballSpawnerController : MonoBehaviour
{
    public GameObject fireballPrefab;
    public float moveSpeed;
    private Animator animator;
    private CircleCollider2D collider; 
    public float damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
