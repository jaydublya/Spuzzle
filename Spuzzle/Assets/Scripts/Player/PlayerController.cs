using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    private GameObject body;
    public bool isClimbing = false;
    public bool canJump;
    public Rigidbody rb;
    public float wallNormalThreshold = 0.3f;
    public float jumpForce = 1000;


    private Collision lastCollision;


    // Start is called before the first frame update
    void Start()
    {
        body = GameObject.Find("Body");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        if (!isClimbing)
        {
            transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Space) && canJump)
            {
                rb.AddForce(Vector3.up * Time.deltaTime * jumpForce, ForceMode.Impulse);
                canJump = false;
            }
        } else
        {
            transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);
        }
        body.transform.Rotate(Vector3.right, verticalInput * rotationSpeed * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("climbable"))
        {
            foreach(ContactPoint contact in collision.contacts)
            {
                if(Mathf.Abs(contact.normal.y) < wallNormalThreshold)
                {
                    isClimbing = true;
                    rb.useGravity = false;
                    rb.linearVelocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                }
                else
                {
                    canJump = true;
                }
            }
        }
        else
        {
            isClimbing = false;
            rb.useGravity = true;
            canJump = true;
        }
        lastCollision = collision;
    }
    private void OnCollisionExit(Collision collision)
    {
        if(lastCollision.gameObject.CompareTag("climbable"))
        {
            isClimbing = false;
            rb.useGravity = true;
            canJump = false;
        }
    }

}