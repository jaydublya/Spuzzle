using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 100.0f;
    private GameObject player;
    public Rigidbody projectileRb;
    private EnemyRobot EnemyRobotScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnemyRobotScript = GameObject.Find("EnemyRobot").GetComponent<EnemyRobot>();
        projectileRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    { if(EnemyRobotScript.startFire == true)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            projectileRb.AddForce(lookDirection * speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}