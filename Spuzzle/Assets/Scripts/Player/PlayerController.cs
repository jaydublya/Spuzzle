using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ParticleSystem dashEffect;
    public ParticleSystem dashEffect2;

    public Rigidbody rb;

    public Transform toung;

    private GameManager gameManager;

    public float speed;
    public float dashSpeed = 30;
    public float rotationSpeed;
    public float wallNormalThreshold = 0.3f;
    public float jumpForce = 1000;
    public float toungSpeed = 0.05f;
    public float dashCoolDown = 1.5f;
    public float toungCoolDown = 0.75f;

    public int health = 4;

    public string toungState = "Idle";

    public bool isClimbing = false;
    public bool canJump;
    public bool canDash = true;
    public bool canAttack = true;



    private Collision lastCollision;

    private GameObject body;
    public AudioSource speaker;


    // Start is called before the first frame update
    void Start()
    {
        body = GameObject.Find("Body");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Escape) && gameManager.isGameActive)
        {
            gameManager.PauseGame();
        }

        if(gameManager.isGameActive)
        {
            if (!canDash)
            {
                dashCoolDown -= Time.deltaTime;
                if (dashCoolDown <= 0)
                {
                    canDash = true;
                    dashCoolDown = 1.0f;
                    dashEffect.transform.localPosition = Vector3.zero;
                }
            }
            if (!canAttack)
            {
                toungCoolDown -= Time.deltaTime;
                if (toungCoolDown <= 0)
                {
                    canAttack = true;
                    toungCoolDown = 0.75f;
                }
            }

            if (!isClimbing)
            {
                transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
                if (Input.GetKeyDown(KeyCode.E) && canDash && verticalInput != 0)
                {
                    dashEffect.Play();
                    dashEffect2.Play();
                    if (verticalInput > 0)
                    {
                        transform.Translate(Vector3.forward * Time.deltaTime * speed * dashSpeed);
                        dashEffect.transform.Translate(Vector3.back * Time.deltaTime * speed * dashSpeed);
                    }
                    else
                    {
                        transform.Translate(Vector3.back * Time.deltaTime * speed * dashSpeed);
                        dashEffect.transform.Translate(Vector3.forward * Time.deltaTime * speed * dashSpeed);
                    }

                    canDash = false;
                }
                if (Input.GetKeyDown(KeyCode.Space) && canJump)
                {
                    rb.AddForce(Vector3.up * Time.deltaTime * jumpForce, ForceMode.Impulse);
                    canJump = false;
                }
            }
            else
            {
                transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);
            }
            body.transform.Rotate(Vector3.right, verticalInput * rotationSpeed * speed * Time.deltaTime);

            if (Input.GetMouseButton(0) && canAttack && !isClimbing)
            {
                toung.localPosition = Vector3.zero;
                canAttack = false;
                toungState = "Extending";
            }

            if (toungState != "Idle")
            {
                if (toungState == "Extending")
                {
                    toung.Translate(Vector3.up * toungSpeed * Time.deltaTime);
                }
                else if (toungState == "Retracting")
                {
                    toung.Translate(Vector3.up * -toungSpeed * Time.deltaTime);
                }

                if (toung.localPosition.z >= 2)
                {
                    toungState = "Retracting";
                }
                if (toung.localPosition.z <= 0)
                {
                    toung.localPosition = new Vector3(0, -1000, 0);
                    toungState = "Idle";
                }
            }

            if (isClimbing)
            {
                rb.useGravity = false;
                canJump = false;
                canDash = false;
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
            else
            {
                rb.useGravity = true;
                canDash = true;
            }
        }

        if(health <= 0)
        {
            //Code for dying goes here
        }
    }

    // Checks if the player is climbing

    private void OnCollisionEnter(Collision collision)
    {
        canJump = true;
        if (collision.gameObject.CompareTag("climbable"))
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                if (Mathf.Abs(contact.normal.y) < wallNormalThreshold)
                {
                    isClimbing = true;
                }
                else
                {
                    isClimbing = false;
                }
            }
        }
        else
        {
            isClimbing = false;
        }
        lastCollision = collision;
    }
    private void OnCollisionExit(Collision collision)
    {
        if(lastCollision.gameObject.CompareTag("climbable"))
        {
            isClimbing = false;
        }
    }
}