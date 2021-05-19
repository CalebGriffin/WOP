﻿using System.Collections;
using System.Collections.Generic;
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
        controls = new PlayerControls();

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
    void Update()
    {
        // if the player is not moving then get the input and move the player
        if (!isMoving)
        {
            //input.x = Input.GetAxisRaw("Horizontal");
            //input.y = Input.GetAxisRaw("Vertical");

            // Prevents the player from moving diagonally by setting one axis to 0 when the other is not
            if (input.x != 0)
            {
                input.y = 0;
            }

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
        if (Physics2D.OverlapCircle(targetPos, 0.1f, solidObjectsLayer) != null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
