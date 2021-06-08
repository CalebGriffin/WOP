using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlockController : MonoBehaviour
{
    // Tracks if the block has hit something
    public bool hitSomething;

    // Tile to check before moving
    public Vector2 targetPos2;

    public Vector3 targetToMoveTo;

    // Position of the ice button
    public Vector3 iceButtonPos;

    public Collider2D tileToCheck;

    // Layer with objects that should be ignored by the physics
    public LayerMask ignoreRaycastLayer;

    // Start is called before the first frame update
    void Start()
    {
        hitSomething = false;

        // Set the position of the button
        iceButtonPos = new Vector3(-5.5f, 1.5f, 0);
    }

    // FixedUpdate is called 50 times per second
    void FixedUpdate()
    {
        // If a block is on the button then change the gVar variable
        if (hitSomething == true && transform.position == iceButtonPos)
        {
            gVar.iceButton = true;
        }
    }

    public void Slide(Vector2 playerInput)
    {
        // Until the block hit's an obstacle, keep moving forwards
        while (hitSomething == false)
        {
            // Set the tile to check based on the player's movement
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

            // Send out a physics object to check if there is an obstacle in front of the block
            tileToCheck = Physics2D.OverlapCircle(targetPos2, 0.3f, ~ignoreRaycastLayer);

            // If there is no obstacle then move to the next tile, else you have hit an obstacle
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

    // Moves the block to the next tile
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
