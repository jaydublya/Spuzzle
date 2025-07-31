using System.Collections;
using UnityEngine;

public class BeemAttack : MonoBehaviour
{
    //Fun fact this makes the boss jump
    private GameObject Player;
    private float verticalForce = 20f;
    private float jumpForce = 50f;
    private float downForce = 3500f;
    private float baseGravityScale;
    private bool hasJumpTriggered;
    private bool isForceDown;

    [Header("Rrference")]
    private Rigidbody rb;
    private EnemyYeulg pm;
    private CapsuleCollider cc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<EnemyYeulg>();
        cc = GetComponent<CapsuleCollider>();
        StartCoroutine(nameof(FightLoop));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator FightLoop()
    {
        yield return new WaitForSeconds(1.0f);
        while (true)
        {
            Jump();
            yield return new WaitUntil(() => transform.position.y >= 22f);
            GroundPound();
            yield return new WaitForSeconds(0.5f);
            ReastJump();
            yield return new WaitForSeconds(8f);
        }
    }

    private void Jump()
    {
        Jump(jumpForce * verticalForce);
    }

    private void Jump(float JumpPower)
    {
        rb.AddForce(Vector3.up * JumpPower , ForceMode.Impulse);
    }

    private void ReastJump()
    {

    }

    private void GroundPound()
    {
        if (transform.position.y >= 22)
        {
            rb.AddForce(Vector3.down * downForce, ForceMode.Impulse);
        }

        if (Vector3.Distance(Player.transform.position, transform.position) < 3.75f)
        {
            
        }
    }

}
