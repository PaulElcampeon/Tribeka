using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;

    private Rigidbody2D rgb;

    private float horizontal;
    private float vertical;

    private void Awake()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveCamera();

        ComputePlayerInpute();
    }

    private void FixedUpdate()
    {
        rgb.velocity = new Vector2(horizontal, vertical) * speed;
    }

    private void ComputePlayerInpute()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void MoveCamera()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
    }
}
