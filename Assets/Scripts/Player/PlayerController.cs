using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public GameObject[] startLocation;

    public float moveSpeed;
    public Rigidbody2D rb;

    public float upLength;
    public float downLength;
    public float rightLength;
    public float leftLength;

    public LayerMask obstacle;
    
    Vector2 movement;
    GameObject gameManager;
    SceneController sceneController;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        sceneController = gameManager.GetComponent<SceneController>();
        this.transform.position = startLocation[SceneController.levels[sceneController.getScene()]].
            transform.position;
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        bool closeUp = Physics2D.Raycast(transform.position, Vector2.up, upLength, obstacle);
        bool closeDown = Physics2D.Raycast(transform.position, Vector2.down, downLength, obstacle);
        bool closeRight = Physics2D.Raycast(transform.position, Vector2.right, rightLength, obstacle);
        bool closeLeft = Physics2D.Raycast(transform.position, Vector2.left, leftLength, obstacle);

        if (closeUp) { movement.y = Math.Min(0, movement.y); }
        if (closeDown) { movement.y = Math.Max(0, movement.y); }
        if (closeRight) { movement.x = Math.Min(0, movement.x); }
        if (closeLeft) { movement.x = Math.Max(0, movement.x); }

        movement = movement.normalized;
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    public Vector2 getMovement()
    {
        return movement;
    }
}
