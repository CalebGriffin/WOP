using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    // Tracks if the block is moving
    public bool isMoving;

    // The blocks hitbox
    public BoxCollider2D hitbox;

    public SpriteRenderer renderer;

    public Sprite topSprite;

    public Vector3 voidPos;

    public Vector3 buttonPos;

    public GameObject voidOb;

    // Start is called before the first frame update
    void Start()
    {
        // Sets the position of the void and the button
        voidPos = new Vector3(4.5f, 0.5f, 0f);
        buttonPos = new Vector3(4.5f, 2.5f, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.parent != null)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (!isMoving)
        {
            if (transform.position == voidPos && gVar.isFilled == false)
            {
                hitbox.enabled = false;

                renderer.sortingOrder = -1;

                renderer.sprite = topSprite;

                voidOb.SetActive(false);

                gVar.isFilled = true;
            }

            if (transform.position == buttonPos)
            {
                gVar.normalButton = true;
            }
        }

        // When ever the player stops moving check that they are in the middle of a tile and snap their position if they are not
        if ((transform.position.x + 0.5f) % 1f != 0f && isMoving == false)
        {
            transform.position = new Vector2((float)Math.Round(transform.position.x) + 0.5f, transform.position.y);
        }

        if ((transform.position.y + 0.5f) % 1f != 0f && isMoving == false)
        {
            transform.position = new Vector2(transform.position.x, (float)Math.Round(transform.position.y) + 0.5f);
        }
    }

    // Moves the block when called by the player
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
