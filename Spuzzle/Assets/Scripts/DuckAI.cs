 using UnityEngine;

public class DuckAI : MonoBehaviour
{
    public float rotateAngle;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        transform.Rotate(Vector3.forward, rotateAngle * Time.deltaTime);
    }
}
