using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float p_moveSpeed;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 movementVector;

    public bool isFacingRight;

    public GameObject[] directions; // 0 sides, 1 top, 2 bottom

    void Start()
    {
        EnableSides();
    }

    void Update()
    {
        StoredPlayerInput();
        HandleAnimation();
    }

    void FixedUpdate()
    {
        if(!GetComponent<PlayerManager>().isWindowOpen)
        {
            MovePlayer();
        }
    }

    private void StoredPlayerInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        
        
        float y = Input.GetAxisRaw("Vertical");

        movementVector = new Vector2(x, y).normalized;

        if(x > 0.9)
        {
            isFacingRight = true;
            EnableSides();
        }
        else if(x < -0.9)
        {
            isFacingRight = false;
            EnableSides();
        }
        
        if(x == 0)
        {
            if(y > 0.9)
            {
                EnableTop();
            }
            else if(y < -0.9)
            {
                EnableBottom();
            }
        }
    }

    private void MovePlayer()
    {
        rb.velocity = new Vector2(movementVector.x * p_moveSpeed, movementVector.y * p_moveSpeed);
    }

    public void HandleAnimation()
    {
        // which side is player looking
        if(isFacingRight)
        {
            this.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }
        else
        {
            
            this.transform.localScale = new Vector3(-0.8f, 0.8f, 0.8f);
        }   
    }

    public void EnableSides()
    {
        directions[0].SetActive(true);
        directions[1].SetActive(false);
        directions[2].SetActive(false);
    }
    public void EnableTop()
    {
        directions[0].SetActive(false);
        directions[1].SetActive(true);
        directions[2].SetActive(false);
    }
    public void EnableBottom()
    {
        directions[0].SetActive(false);
        directions[1].SetActive(false);
        directions[2].SetActive(true);
    }
}
