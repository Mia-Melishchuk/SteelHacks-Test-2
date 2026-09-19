using UnityEngine;

public class cameraScript : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothness = 0.25f;
    [SerializeField] private Vector3 offset = new Vector3(0f, 0f, -10f);

    private Vector3 currentVelocity = Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target == null) return;

        Vector3 targetPos = target.position + offset;

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref currentVelocity, smoothness);
    }
}
