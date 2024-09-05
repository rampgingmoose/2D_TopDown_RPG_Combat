using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1.0f;             //Serialized so it can be modified in the editor

    private Vector2 movement;
    private Rigidbody2D rigidBody;
    private PlayerActionMap playerActionMap;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        playerActionMap = new PlayerActionMap();
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer= GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        playerActionMap.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        
    }

    private void FixedUpdate()
    {
        MovePlayer();
        FlipSprite();
    }

    private void PlayerInput()
    {
        movement = playerActionMap.Movement.Move.ReadValue<Vector2>();

        //Sets the float parameters in the Animator object to the movement Vec2 object values
        anim.SetFloat("moveX", movement.x);
        anim.SetFloat("moveY", movement.y);
    }

    private void MovePlayer()
    {
        //takes the current Vec2 position of the rigidBody adds the movement Vec2. We multiply by the moveSpeed variable in order to control the player's
        //speed, and multiply that by a fixedDeltaTime to keep it framerate independent. We use fixedDeltaTime as we call this function in a FixedUpdate()
        rigidBody.MovePosition(rigidBody.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void FlipSprite()
    {
        //Get Mouse.x Position
        //if mouse.x pos < playerPos.x
            //playerscale.x *= -1;
        //else
            //player
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Debug.Log("Mouse Pos: " + mousePos);
        //Debug.Log("Player Pos: " + transform.position.x);

        if(mousePos.x < transform.position.x)
            this.spriteRenderer.flipX = true;
        else
            this.spriteRenderer.flipX = false;
    }
}
