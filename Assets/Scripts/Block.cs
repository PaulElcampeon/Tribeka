using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public GameObject patrolRef;

    public int noOfPatrols;

    private float waitTime;

    private Vector3[] patrolPoints = new Vector3[4];

    private bool isLeftPosAssigned, isRightPosAssigned, isUpPosAssigned, isDownPosAssigned;

    private Vector3 leftStartPos, rightStartPos, upStartPos, downStartPos;

    private SpriteRenderer spriteRender;

    public int currentScale;
    private int minScale = 2;
    private int maxScale = 8;

    /*scales and number of patrols
     scale 2: 2 patrol
     scale 3: up to 2
     scale 4 up to 4*/

    //max Scale is 4 x 4;
    private void Awake()
    {
        spriteRender = GetComponentInChildren<SpriteRenderer>();
    }

    void Start()
    {
            
    }

    void Update()
    {
        
    }

    private void AssignPatrolPoints()
    {

    }

    private void AssignStartPositions()
    {

    }

    private void AssignScale()
    {
        currentScale = Random.Range(minScale, maxScale);
        transform.localScale = new Vector3(currentScale, currentScale, 0f);
    }

    private void AssignNoOfPatrols()
    {

    }
}
