using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    float dirX;
    float movementSpeed = 20f;
    float jumpForce = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        UpdateMoveInput();
        UpdateFMove();
       

    }
    void UpdateMoveInput()
    {
        dirX = Input.acceleration.x * movementSpeed;
        transform.position = new Vector2 (Mathf.Clamp(transform.position.x,-7.5f, 7.5f), transform.position.y);
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }
    void UpdateFMove()
    {
       
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }
}
