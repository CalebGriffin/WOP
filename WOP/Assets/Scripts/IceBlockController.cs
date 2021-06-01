using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlockController : MonoBehaviour
{
    public bool hitSomething;

    public Vector2 targetPos2;

    public Vector3 targetToMoveTo;

    public Collider2D tileToCheck;

    public LayerMask ignoreRaycastLayer;

    // Start is called before the first frame update
    void Start()
    {
        hitSomething = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Slide(Vector2 playerInput)
    {
        while (hitSomething == false)
        {
            if (playerInput.x > 0)
            {
                targetPos2 = new Vector2((transform.position.x + 1), transform.position.y);
            }
            else if (playerInput.x < 0)
            {
                targetPos2 = new Vector2((transform.position.x - 1), transform.position.y);
            }
            else if (playerInput.y > 0)
            {
                targetPos2 = new Vector2(transform.position.x, (transform.position.y + 1));
            }
            else if (playerInput.y < 0)
            {
                targetPos2 = new Vector2(transform.position.x, (transform.position.y - 1));
            }

            tileToCheck = Physics2D.OverlapCircle(targetPos2, 0.3f, ~ignoreRaycastLayer);

            if (tileToCheck == null)
            {
                hitSomething = false;
                targetToMoveTo = new Vector3(targetPos2.x, targetPos2.y, 0);
                Move(targetToMoveTo);
            }
            else
            {
                hitSomething = true;
            }
        }
    }

    public void Move(Vector3 targetPos)
    {
        // Check if the block is basically at the target position
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 1 * Time.deltaTime);
        }

        // Snap the block to the tile location
        transform.position = targetPos;
    }
}
