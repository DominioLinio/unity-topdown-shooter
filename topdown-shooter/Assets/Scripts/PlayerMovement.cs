using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float baseMoveSpeed = 1f;
    public float moveSpeed = 1f;
    public float speedModifier = 1f;
    float angle;
    bool sprinting = false;


    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)) 
        {
            sprinting = true;
            Debug.Log("sprinting");
        }
        else sprinting = false;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        if (sprinting)
        {
            moveSpeed = baseMoveSpeed + 2f;
        }
        else
        {
            moveSpeed = baseMoveSpeed;
        }
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);

        Vector2 lookDir = mousePos - rb.position;

        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
