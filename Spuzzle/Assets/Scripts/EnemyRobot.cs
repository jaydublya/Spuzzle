using UnityEngine;

public class EnemyRobot : MonoBehaviour
{
    public float speed = 10.0f;
    public int itemType;

    public GameObject wiresPrefab;
    public GameObject sheetMetalPrefab;

    public int health;

    public PlayerController playerControllerScript;
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()s
    {
        GameObject.Find("Player");
        itemType = Random.Range(1, 2);
    }

    //Move towards the player
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        transform.Translate(lookDirection * speed * Time.deltaTime);

        if (health <= 0)
        {
            if (itemType == 1)
            {
                Instantiate(wiresPrefab);
                Destroy(gameObject);
            }
            else if (itemType == 2)
            {
                Instantiate(sheetMetalPrefab);
                Destroy(gameObject);
            }

        }
        transform.position = new Vector3(transform.position.x, -1, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerControllerScript.health -= 1;
        }
    }
}
