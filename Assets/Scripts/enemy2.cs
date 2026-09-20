using System;
using UnityEngine;

public class enemy2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Animator m_animator;
    private Rigidbody2D body2d;
    private int health = 100;
    public int attackdis = 2;
    public Transform playerTransform;
    private Boolean dead = false;
    //private Collider2D collider1;
    public GameObject fireball;
    public GameObject player = null;
    public GameObject coinPrefab;
    void Start()
    {
        m_animator = GetComponent<Animator>();
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
        if (health < 0)
        {
            m_animator.SetTrigger("Death");
        }
        //attack animation once the player gets close 
        //float distance = player.get;
        //float distance = Vector2.Distance(transform.position, playerTransform.position);
        float distance = Mathf.Abs(player.transform.position.x - transform.position.x);
        float turning = (player.transform.position.x - transform.position.x);
        if (turning > 0 && dead==false)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        Debug.Log(distance);
        if ((distance < 20 || turning >10) && player.activeSelf)
        {
            GetComponent<Animator>().SetBool("Attack", true);

        }
        else
        {
            m_animator.SetBool("Attack", false);
            
        }
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        //Dies to fireball
        if (collision.gameObject.CompareTag("fireball"))
        {
            health = 0;
            Debug.Log(health+ "This is the health");
            if (health <= 0)
            {
                dead = true;
                Debug.Log("dead");
                m_animator.SetBool("Dead", true);
                gameObject.tag = "dead";
                gameObject.GetComponent<Collider2D>().enabled = false;
                Instantiate(coinPrefab, new Vector3(0, 5f, 0) + transform.position, transform.rotation, transform);
                body2d.gravityScale = 0;
            }

        }

    }

}
