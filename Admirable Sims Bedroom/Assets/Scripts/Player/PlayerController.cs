using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float p_moveSpeed;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 movementVector;

    void Update()
    {
        StoredPlayerInput();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void StoredPlayerInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        movementVector = new Vector2(x, y).normalized;
    }

    private void MovePlayer()
    {
        rb.velocity = new Vector2(movementVector.x * p_moveSpeed, movementVector.y * p_moveSpeed);
    }
}
