using UnityEngine;

public class cloudManager : MonoBehaviour
{
    public GameObject cloudPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            Instantiate(cloudPrefab, transform.position + new Vector3(26*i, 0, 0), transform.rotation, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
