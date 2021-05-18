using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Controls the player's movement speed
    public float moveSpeed;

    // Tracks if the player is moving or not
    public bool isMoving;

    // Vector2 variable to control input
    private Vector2 input;

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
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

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

                // Starts to move the player towards the new location
                StartCoroutine(Move(targetPos));
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
}
