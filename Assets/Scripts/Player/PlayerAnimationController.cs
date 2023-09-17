using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public GameObject player;

    PlayerController playerController;
    Animator animate;
    string[] movements = { "SideRunning", "FrontRunning", "BackRunning"};
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        animate = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 movement = playerController.getMovement();

        animate.SetFloat("Horizontal", movement.x);
        animate.SetFloat("Vertical", movement.y);
        animate.SetFloat("Speed", movement.sqrMagnitude);

        Vector3 scale = gameObject.transform.localScale;
        scale.x = Mathf.Abs(scale.x);
        if (movement.x < 0)
        {
            scale.x *= -1;
        }
        gameObject.transform.localScale = scale;
    }
}
