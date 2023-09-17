using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public GameObject player;
    public float speed;

    PlayerController playerController;

    Vector2 target;
    Vector2 position;
    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }
    void Update()
    {
        target = playerController.getMovement();

        if (target != Vector2.zero)
        {
            float angle = Vector3.SignedAngle(new Vector3(1, 0, 0), target, Vector3.forward);
            transform.eulerAngles = new Vector3(0, 0, angle);
        }
    }
}
