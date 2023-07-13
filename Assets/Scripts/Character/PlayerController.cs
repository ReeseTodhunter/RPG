using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    private Rigidbody2D rb;
    private Vector2 movementDirection;

    protected override void Awake()
    {
        base.Awake(); //Run the character's base start

        // Getting the player's rigidbody component
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("You FOOOOL where's the rigid body?!");
        }
    }

    protected override void Update()
    {
        base.Update(); //Run the character's base update

        InputMovement();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate(); //Run the character's base fixed update
        Movement();
    }

    void InputMovement()
    {
        movementDirection.x = Input.GetAxisRaw("MoveH");
        movementDirection.y = Input.GetAxisRaw("MoveV");
        movementDirection.Normalize();
    }

    void Movement()
    {
        if (movementDirection.sqrMagnitude > 0)
        {
            rb.MovePosition(rb.position + (movementDirection * movementSpeed * Time.fixedDeltaTime));
        }
    }
}