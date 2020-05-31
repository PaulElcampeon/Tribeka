using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;

    private Rigidbody2D rgb;

    [SerializeField]
    private GameObject shield;

    [SerializeField]
    private GameObject particleExplosionRef;


    private float horizontal;
    private float vertical;
    private float currentAngle = 0f;

    private bool isTurning;
    private bool freezeCamera;

    private void Awake()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveCamera();

        ComputePlayerInpute();

        if (isTurning) RotateShield();
    }

    private void FixedUpdate()
    {
        rgb.velocity = new Vector2(horizontal, vertical) * speed;
    }

    private void ComputePlayerInpute()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (isTurning) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            SoundManager.instance.PlaySFX(2);

            if (currentAngle == -360)
            {
                currentAngle = 0f;
                shield.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }

            currentAngle -= 90;

            isTurning = true;
        }

        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    if (currentAngle == 360)
        //    {
        //        currentAngle = 0f;
        //        shield.transform.rotation = Quaternion.Euler(0f, 0f, 0f); or Quaternion.Euler(0f, 0f, 270f); cant 
        //    }

        //    currentAngle += 90;

        //    isTurning = true;
        //}
    }

    private void MoveCamera()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
    }

    private void RotateShield()
    {
        shield.transform.rotation = Quaternion.Euler(0f, 0f, Mathf.MoveTowardsAngle(shield.transform.rotation.eulerAngles.z, currentAngle, 100f * Time.deltaTime));

        if (Mathf.Abs(currentAngle + (360 - shield.transform.rotation.eulerAngles.z)) <= 1)
        {
            isTurning = false;
        }
    }

    public void Explode()
    {
        Instantiate(particleExplosionRef, transform.position, Quaternion.identity);
        SoundManager.instance.PlaySFX(0);
        Destroy(gameObject);
    }

    //private void RotateShield()
    //{
    //    shield.transform.rotation = Quaternion.Euler(0f, 0f, Mathf.MoveTowardsAngle(shield.transform.rotation.eulerAngles.z, currentAngle, 100f * Time.deltaTime));

    //    if (Mathf.Abs(currentAngle - shield.transform.rotation.eulerAngles.z) <= 1)
    //    {
    //        isTurning = false;
    //    }
    //}
}
