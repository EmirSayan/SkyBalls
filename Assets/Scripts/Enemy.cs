using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;
    private GameObject player;
    private Rigidbody enemyRb;
    private bool scoreGiven;
    
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }

        if(transform.position.y < -9 && !scoreGiven)
        {
            scoreGiven = true;
            SpawnMenager.sm.score++;
            SpawnMenager.sm.scoreText.text = System.Convert.ToString(SpawnMenager.sm.score);
            SpawnMenager.sm.lastScore.text = System.Convert.ToString(SpawnMenager.sm.score);
            SpawnMenager.sm.lastScore2.text = System.Convert.ToString(SpawnMenager.sm.score);
        }

        
    }
}
