using UnityEngine;

public class WindTuebineSpin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, 10f * Time.deltaTime, Space.Self);
    }
}
