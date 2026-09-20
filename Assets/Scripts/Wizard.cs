using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Wizard : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D body2d;
    private int health = 100;
    public int attackdis = 2;
    public Transform playerTransform;
    private Boolean dead = false;
    //private Collider2D collider1;
    public GameObject fireball;
    public GameObject player = null;
    public GameObject fireballPink;
    void Start()
    {
        animator = GetComponent<Animator>();
        body2d = GetComponent<Rigidbody2D>();
        // collider1 = GetComponent<BoxCollider2D>(); if time can mess with
        //If you want to find it by TAG. For this you have to make sure you give your player object the tag "Player".
        if (player == null)
            player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //To be done later once have fireballs
        //attack animation once the player gets close 
        //float distance = player.get;
        //float distance = Vector2.Distance(transform.position, playerTransform.position);
        float distance = Mathf.Abs(player.transform.position.x - transform.position.x);
        float turning = (player.transform.position.x - transform.position.x);
        if (turning > 0 && dead == false)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        Debug.Log(distance);
        if ((distance < 50 || turning > 10) && player.activeSelf)
        {
            GetComponent<Animator>().SetBool("close", true);

        }
        else
        {
            animator.SetBool("close", false);

        }


    }

    void Update()
    {

        // Instantiate(asteroidPrefab, transform.position, transform.rotation, transform);
        for (int i=0; i<10; i++)
        {
            Instantiate(fireballPink, gameObject.transform.position, transform.rotation, transform);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        //Dies to fireball
        if (collision.gameObject.CompareTag("fireball"))
        {
            health = 0;
            Debug.Log(health + "This is the health");
            if (health <= 0)
            {
                dead = true;
                Debug.Log("dead");
                animator.SetBool("dead", true);
                gameObject.tag = "dead";
                gameObject.GetComponent<Collider2D>().enabled = false;
                body2d.gravityScale = 0;
            }

        }
    }
}
