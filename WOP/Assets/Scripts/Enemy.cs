using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Keeps track of banana and exposes it in the inspector panel for the enemy
    [SerializeField]
    Transform banana;

    //This is a piece of code that tracks the range of the enemies agro, which will also show up in the enemies inspector
    [SerializeField]
    float agroRange;

    //This code is used change the enemies movespeed in the inspector
    [SerializeField]
    float moveSpeed;

    //This code is used to add force to the enemy so that I can have it move
    Rigidbody2D rb2d;


    void Start()
    {
        //This code is used to add the component of rigidbody 2D to the enemy
        rb2d = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        //ditance to player
        float distToBanana = Vector2.Distance(transform.position, banana.position);

        if (distToBanana < agroRange)
        {
            //code to chase player
            ChaseBanana();
        }
        else
        {
            //stop chasing player
            StopChasingBanana();
        }

    }

    void ChaseBanana()
    {
        if (transform.position.x < banana.position.x)
        {
            //enemy is to the left side of the player, so move right
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            //enemy is to the right side of the player, so move left
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1);
        }
    }

    void StopChasingBanana()
    {
        //Stops movement of enemy
        rb2d.velocity = new Vector2(0, 0);
    }
}
