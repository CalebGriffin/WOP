using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public bool isMoving;

    public BoxCollider2D hitbox;
    
    public SpriteRenderer renderer;

    public Vector3 voidPos;

    public Vector3 buttonPos;

    // Start is called before the first frame update
    void Start()
    {
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
}
