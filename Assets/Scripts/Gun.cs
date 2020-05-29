using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private LineRenderer lazer;

    private void Awake()
    {
        lazer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        float distance = 30f;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, distance);

        if (hit.point != Vector2.zero)
        {
            //Debug.DrawLine(transform.position, hit.point, Color.red);
            lazer.SetPosition(0, transform.position);
            lazer.SetPosition(1, hit.point);
        } else
        {
            //Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.red);
            lazer.SetPosition(0, transform.position);
            lazer.SetPosition(1, transform.position + transform.right * distance);
        }
    }
}
