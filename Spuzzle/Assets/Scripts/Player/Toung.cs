using UnityEngine;

public class Toung : MonoBehaviour
{
    public GameObject[] items;
    public AudioSource lickSFX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Lickable")) return;
        Destroy(other.gameObject);
        lickSFX.Play();
    }
}
