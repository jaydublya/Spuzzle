using UnityEngine;

public class EnemyRobot : MonoBehaviour
{
    public float speed = 50.0f;
    private Rigidbody enemyRb;
    private GameObject player;
    public GameObject projectilePrefab;
    private float startDelay = 2;
    private float fireRate = 3;
    public bool startFire;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startFire = false;
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        if(startFire == true)
        {
            InvokeRepeating("private void OnTriggerEnter(Collider Other)", startDelay, fireRate);
        }   
    }

    //Move towards the player
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);
    }
    
    //Trigger fire projectile when enter with box collider
    private void OnTriggerEnter(Collider Other)
    {
        if(Other.CompareTag("Player"))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            startFire = true;
        }
    }
}
