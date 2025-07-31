using System.Collections;
using UnityEngine;

public class DashAttack : MonoBehaviour
{
    private GameObject Player;
    public float speed = 140f;
    public float AddForce = 2f;

    [Header("References")]
    private Rigidbody rb;
    private EnemyYeulg pm;
    private EnemyYeulg Speed;
    

    [Header("Dashing")]
    public float dashForce = 10f;

    private void Start()
    {
        Player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<EnemyYeulg>();
        Speed = GetComponent<EnemyYeulg>();
        StartCoroutine(nameof(FightLoop));
    }

    private void Update()
    {

    }

    IEnumerator FightLoop()
    {
        yield return new WaitForSeconds(1.0f);
        while (true)
        {
            Dash();
            ReastDash();
            yield return new WaitForSeconds(1.0f);
            SlowDown();
            yield return new WaitForSeconds(1.0f);
            ReastDash();
            yield return new WaitForSeconds(12f);
        }
    }

    private void Dash()
    {
        Dash(speed * dashForce);
    }

    private void Dash(float speedForce)
    {
        rb.AddForce(pm.lookDirection * speedForce, ForceMode.Impulse);
    }

    private void ReastDash()
    {
        rb.isKinematic = false;
    }

    private void SlowDown()
    {
        rb.isKinematic = true;
    }
}
