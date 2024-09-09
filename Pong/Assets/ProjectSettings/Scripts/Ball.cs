using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float initialVelocity = 4f;
    [SerializeField] private float velocityMultiplier = 1.1f;
    [SerializeField] private GameObject goalRight;
    [SerializeField] private Animator goalRight_Anim;
    [SerializeField] private GameObject goalLeft;
    [SerializeField] private Animator goalLeft_Anim;

    private Rigidbody2D ballRB;

    void Start()
    {
        ballRB = GetComponent<Rigidbody2D>();
        Launch();
        goalRight_Anim = goalRight.GetComponent<Animator>();
        goalLeft_Anim = goalLeft.GetComponent<Animator>();
    }

    private void Launch()
    {
        float xVelocity = Random.Range(0, 2) == 0 ? -1 : 1;
        float yVelocity = Random.Range(0, 2) == 0 ? -1 : 1;
        ballRB.velocity = new Vector2(xVelocity, yVelocity) * initialVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Paddle"))
        {
            ballRB.velocity *= velocityMultiplier;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GoalRight"))
        {
            goalRight_Anim.SetBool("Goal", true);
            GameManager.Instance.ScoredLeft();
            GameManager.Instance.Restart();
            Launch();
        }
        else
        {
            goalLeft_Anim.SetBool("Goal", true);
            GameManager.Instance.ScoredRight();
            GameManager.Instance.Restart();
            Launch();
        }
    }
}
