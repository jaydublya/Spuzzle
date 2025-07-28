using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ParticleSystem dashEffect;
    public ParticleSystem dashEffect2;

    public Rigidbody rb;

    public Transform toung;

    public float speed;
    public float dashSpeed = 30;
    public float rotationSpeed;
    public float wallNormalThreshold = 0.3f;
    public float jumpForce = 1000;
    public float toungSpeed = 0.05f;
    public float dashCoolDown = 1.0f;

    public string toungState;

    public bool isClimbing = false;
    public bool canJump;
    public bool canDash = true;
    public bool canAttack = true;
    public bool isAttacking = false;



    private Collision lastCollision;

    private GameObject body;


    // Start is called before the first frame update
    void Start()
    {
        body = GameObject.Find("Body");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        if(!canDash)
        {
            dashCoolDown -= Time.deltaTime;
            if(dashCoolDown <= 0)
            {
                canDash = true;
                dashCoolDown = 1.0f;
                dashEffect.transform.localPosition = Vector3.zero;
            }
        }
        if (!isClimbing)
        {
            transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.E) && !isClimbing && canDash)
            {
                dashEffect.Play(); dashEffect2.Play();
                transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime * dashSpeed);
                dashEffect.transform.Translate(Vector3.back * speed * verticalInput * Time.deltaTime * dashSpeed);
                canDash = false;
            }
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

        if(Input.GetMouseButton(0) && canAttack && !isClimbing)
        {
            isAttacking = true;
            canAttack = false;
            toungState = "Extending";
        }

        if(isAttacking)
        {
            if(toungState == "Extending")
            {
                toung.Translate(Vector3.up * toungSpeed);
            }
            else if(toungState == "Retracting")
            {
                toung.Translate(Vector3.up * -toungSpeed);
            }

            if (toung.localPosition.z >= 2)
            {
                toungState = "Retracting";
            }
            if(toung.localPosition.z <= 0)
            {
                toung.localPosition = Vector3.zero;
                isAttacking = false;
                canAttack = true;
            }
        }
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