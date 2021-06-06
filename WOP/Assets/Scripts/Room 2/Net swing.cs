using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Netswing : MonoBehaviour
{
    private Rigidbody2D myRB;
    private Animator myAnim;

    [SerializeField]
    private float speed = 0f;

    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    void Update()
    {
        myRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;

        myAnim.SetFloat("moveX", myRB.velocity.x);
        myAnim.SetFloat("moveY", myRB.velocity.y); 
    }

    if (Input.GetAxisRaw("Horizontal") == 1)
}
