using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemy : MonoBehaviour
{
    public float speed;
    public float checkRadius;
    public float attackRadius;

    public bool shouldRotate;

    private bool isChasing;

    public LayerMask banana;

    private GameObject target;
    private GameObject[] tmpTarget;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 movement;
    public Vector3 dir;

    private bool isInChaseRange;
    private bool isInAttackRange;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = null;
    }
    private void Update()
    {
        anim.SetBool("isMoving", isChasing);

        //isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, banana);
        //isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, banana);
        if (target != null)
        {
            dir = target.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            dir.Normalize();
            movement = dir;
        }

        if (shouldRotate)
        {
            anim.SetFloat("moveX", dir.x);
            anim.SetFloat("moveY", dir.y);
        }
        if (target == null)
        {
            tmpTarget = GameObject.FindGameObjectsWithTag("Banana");

            foreach (GameObject i in tmpTarget)
            {
                float dist = Vector3.Distance(i.transform.position, transform.position);
                if (dist <= 7.5f)
                {
                    target = i;
                    break;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            StartCoroutine("WaitToChase");
        }
    }

    private IEnumerator WaitToChase()
    {
        yield return new WaitForSeconds(0.1f);

        MoveCharacter(movement);
    }

    private void MoveCharacter(Vector2 dir)
    {
        isChasing = true;
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //This code states that when the player collides with a gameobject with the tag "Player" the frog will be destroyed
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Banana")
        {
            Destroy(other.gameObject);
            target = null;
            isChasing = false;
            rb.velocity = Vector2.zero;
        }
    }
}

