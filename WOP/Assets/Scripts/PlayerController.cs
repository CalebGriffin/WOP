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

    public bool isPushing;

    // Vector2 variable to control input
    private Vector2 input;

    // Vector2 to check if the block can be moved
    private Vector2 targetPos2;

    public Vector3 blockTarget;

    // Allows the script to be able to check which layer an object is on
    public LayerMask solidObjectsLayer;

    // Allows the script to be able to check if the player is touching a block
    public LayerMask blockLayer;

    public LayerMask ignoreRaycastLayer;

    public GameObject Player;

    public GameObject lastIceBlockPushed;

    public GameObject restartCanvas;

    public GameObject quitCanvas;

    public GameObject uiController;

    public Collider2D tileToCheck;

    public Collider2D tileToCheck2;

    // Can see the input that the player is making
    PlayerControls controls;

    public Animator playerAnimator;

    // Awake is called even before Start
    void Awake()
    {
        // Creates a new instance of the player controls
        controls = new PlayerControls();

        // Read the input from the player and set the value based on the input and set it to 0 when the buttons are not being pressed
        controls.Gameplay.Move.performed += ctx => input = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => input = Vector2.zero;

        controls.Gameplay.Reset.performed += ctx => Restart();

        playerAnimator = GetComponent<Animator>();
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
                Debug.Log(input.x.ToString() + ", " + input.y.ToString());

                // Sets the animations based on the direction the player is moving
                playerAnimator.SetFloat("MoveX", input.x);
                playerAnimator.SetFloat("MoveY", input.y);

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

        playerAnimator.SetBool("isWalking", isMoving);
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
        tileToCheck = Physics2D.OverlapCircle(targetPos, 0.3f, ~ignoreRaycastLayer);

        if (tileToCheck == null)
        {
            Debug.Log("Hit nothing");
            return true;
        }
        else
        {
            Debug.Log(tileToCheck.gameObject.name.ToString());

            if (tileToCheck.gameObject.layer == 8)
            {
                return false;
            }
            else if (tileToCheck.gameObject.layer == 10)
            {
                Debug.Log("GOT HERE");

                if (input.x > 0)
                {
                    targetPos2 = new Vector2((targetPos.x + 1), targetPos.y);
                }
                else if (input.x < 0)
                {
                    targetPos2 = new Vector2((targetPos.x - 1), targetPos.y);
                }
                else if (input.y > 0)
                {
                    targetPos2 = new Vector2(targetPos.x, (targetPos.y + 1));
                }
                else if (input.y < 0)
                {
                    targetPos2 = new Vector2(targetPos.x, (targetPos.y - 1));
                }

                Debug.Log(targetPos2.x.ToString() + ", " + targetPos2.y.ToString());

                tileToCheck2 = Physics2D.OverlapCircle(targetPos2, 0.3f, ~ignoreRaycastLayer);

                if (tileToCheck2 == null)
                {
                    Debug.Log("There is nothing on the other side of this block");
                    //tileToCheck.transform.SetParent(transform);
                    //StartCoroutine("WaitToUnparent");

                    blockTarget = new Vector3(targetPos2.x, targetPos2.y, 0f);
                    tileToCheck.gameObject.GetComponent<BlockController>().Move(targetPos2);
                    return true;
                }
                else if (tileToCheck2 != null)
                {
                    if (tileToCheck2.gameObject.layer == 8)
                    {
                        return false;
                    }
                    else if (tileToCheck2.gameObject.layer == 10)
                    {
                        return false;
                    }
                    else if (tileToCheck2.gameObject.layer == 12)
                    {
                        return false;
                    }
                    else
                    {
                        Debug.Log("There is nothing on the other side of this block #2");
                        //tileToCheck.transform.SetParent(transform);
                        //StartCoroutine("WaitToUnparent");

                        blockTarget = new Vector3(targetPos2.x, targetPos2.y, 0f);
                        tileToCheck.gameObject.GetComponent<BlockController>().Move(targetPos2);
                        return true;
                    }
                }
                else
                {
                    //tileToCheck.transform.SetParent(transform);
                    //StartCoroutine("WaitToUnparent");

                    blockTarget = new Vector3(targetPos2.x, targetPos2.y, 0f);
                    tileToCheck.gameObject.GetComponent<BlockController>().Move(targetPos2);
                    return true;
                }
            }
            else if (tileToCheck.gameObject.layer == 12)
            {
                tileToCheck.gameObject.GetComponent<IceBlockController>().Slide(input);
                lastIceBlockPushed = tileToCheck.gameObject;
                StartCoroutine("WaitToStop");
                return false;
            }
            else if (tileToCheck.gameObject.layer == 14)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public void Restart()
    {
        gVar.isPaused = true;
        controls.Gameplay.Disable();
        uiController.SetActive(true);

        restartCanvas.SetActive(true);
    }

    public void QuitMenu() 
    {
        gVar.isPaused = true;
        controls.Gameplay.Disable();
        uiController.SetActive(true);

        quitCanvas.SetActive(true);
    }

    public IEnumerator WaitToUnparent()
    {
        //yield return new WaitForSeconds(0.35f);

        /*while(isMoving == true)
        {
            yield return null;
        }*/

        yield return new WaitUntil(() => isMoving == false);

        Player.transform.DetachChildren();
    }

    public IEnumerator WaitToStop()
    {
        yield return new WaitForSeconds(0.3f);

        lastIceBlockPushed.GetComponent<IceBlockController>().hitSomething = false;
    }

    #region Not Working (Needs to be deleted)
    /*private bool IsWalkable2(Vector3 targetPos)
    {
        hit = Physics2D.Raycast(transform.position, input, 1f, ~ignoreRaycastLayer);
        Debug.DrawRay(transform.position, input, Color.white, 1f);

        if (hit.transform == null)
        {
            return true;
        }
        else
        {
            // Uses a physics object to check the mask of the collision and then returns a bool to say if it can be walked on or not
            if (hit.transform.gameObject.layer == solidObjectsLayer)
            {
                return false;
            }
            else if (hit.transform.gameObject.layer == blockLayer)
            {
                hit.transform.SetParent(transform);
                return true;
            }
            else
            {
                return true;
            }
        }
    }*/
    #endregion
}
