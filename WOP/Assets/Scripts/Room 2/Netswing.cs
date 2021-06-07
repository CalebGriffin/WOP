using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Netswing : MonoBehaviour
{
    private Rigidbody2D myRB;
    private Animator Net;
    private Vector2 movement;

    public Rigidbody2D rb;
    public float moveSpeed = 0f;

    [SerializeField]
    private float speed = 0f;

    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        Net = GetComponent<Animator>();
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Net.SetFloat("Horizontal", movement.x);
        Net.SetFloat("Vertical", movement.y);
        Net.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetAxisRaw("Horizontal") == 1 ||
           Input.GetAxisRaw("Horizontal") == -1 ||
           Input.GetAxisRaw("Vertical") == 1 ||
           Input.GetAxisRaw("Vertical") == -1)
        {
            Net.SetFloat("Last_Horizontal",
                              Input.GetAxisRaw("Horizontal"));
            Net.SetFloat("Last_Vertical",
                              Input.GetAxisRaw("Vertical"));
        }

        if (Input.GetKeyDown(KeyCode.Space))
            Net.SetBool("isAttacking", true);

    }

    void FixedUpdate()
    {
        if (Net.GetBool("isAttacking") == true)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.MovePosition(rb.position + movement * moveSpeed *
                            Time.fixedDeltaTime);
        }
    }

    void StopAttack()
    {
        if (Net.GetBool("isAttacking"))
            Net.SetBool("isAttacking", false);
    }
}
