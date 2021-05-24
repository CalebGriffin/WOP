using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Controls the player's movement speed
    public float moveSpeed;

    // Tracks if the player is moving or not
    public bool isMoving;

    // Vector2 variable to control input
    private Vector2 input;

    // Allows the script to be able to check which layer an object is on
    public LayerMask solidObjectsLayer;

    // Can see the input that the player is making
    PlayerControls controls;

    // Awake is called even before Start
    void Awake()
    {
        // Creates a new instance of the player controls
        controls = new PlayerControls();

        // Read the input from the player and set the value based on the input and set it to 0 when the buttons are not being pressed
        controls.Gameplay.Move.performed += ctx => input = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => input = Vector2.zero;
    }

    // Enables the input when the object is enabled
    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    // Disables the input when the object is disabled
    void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if the player is not moving then get the input and move the player
        if (!isMoving)
        {

            // Prevents the player from moving diagonally by setting one axis to 0 when the other is not
            if (input.x != 0)
            {
                input.y = 0;
            }

            // When the player is making input to the game
            if (input != Vector2.zero)
            {
                // Sets up the target position variable
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                // Checks if the tile that the player is about to enter is an obstacle
                if (IsWalkable(targetPos))
                {
                    // Starts to move the player towards the new location
                    StartCoroutine(Move(targetPos));
                }
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

    // Coroutine that moves the player so that they will snap to each tile
    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        // Check if the player is basically at the target position
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        // Snap the player to the tile location
        transform.position = targetPos;

        isMoving = false;
    }

    // Function called to check if the player can walk on that tile
    private bool IsWalkable(Vector3 targetPos)
    {
        // Uses a physics object to check the mask of the collision and then returns a bool to say if it can be walked on or not
        if (Physics2D.OverlapCircle(targetPos, 0.3f, solidObjectsLayer) != null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
