using System;
using UnityEngine;

public class EnemyYeulg : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameObject Player;
    public float Speed = 140f;
    public Vector3 lookDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        Player = GameObject.Find("Player");

    }


    //Move towards the player
    void Update()
    {
        lookDirection = (Player.transform.position - transform.position).normalized;
        enemyRb.AddForce(Speed * Time.deltaTime * lookDirection);
    }

}