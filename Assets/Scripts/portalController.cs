using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portalController : MonoBehaviour
{
    public String levelName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {

    // }

    // // Update is called once per frame
    // void Update()
    // {

    // }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            SceneManager.LoadScene(levelName);
        }
    }
}
