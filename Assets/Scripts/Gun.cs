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
    // Start is called before the first frame update
    void Start()
    {
        //lazer.SetPosition(0, Vector3.up * 3);
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 10f);

        if (hit.point != Vector2.zero)
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
            lazer.SetPosition(0, transform.position);
            lazer.SetPosition(1, hit.point);
        } else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * 10f, Color.red);
            lazer.SetPosition(0, transform.position);
            lazer.SetPosition(1, transform.position + transform.right * 10f);
        }
    }
}
