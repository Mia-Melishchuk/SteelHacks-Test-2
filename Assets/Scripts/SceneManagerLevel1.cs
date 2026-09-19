using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerLevel1 : MonoBehaviour
{
    public GameObject grid;
    public GameObject grid2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UnityEngine.Vector3 gridPos = grid.transform.position;
        gridPos.x -= 0.05f;
        if (gridPos.x < 1210) gridPos.x = 1230;
        grid.transform.position = gridPos;

        UnityEngine.Vector3 gridPos2 = grid2.transform.position;
        gridPos2.x += 0.05f;
        if (gridPos2.x > 1225) gridPos2.x = 1215;
        grid2.transform.position = gridPos2;

        
    }

    public void buttonClicked()
    {
        print("button clicked!");
    }
}
