using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;
    private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (gameManager.isGameActive)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);

        }
    }
}
