﻿using System.Collections;
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

    private void Start()
    {
        AssignNoOfPatrols();
        AssignPatrolPoints();
        CreatePatrols();
    }

    private void CreatePatrols()
    {
        for (int i = 0; i < noOfPatrols; i++)
        {
            Vector3 firstPosition = GetAvailableStartPos();
            GameObject patrol = Instantiate(patrolRef, firstPosition, Quaternion.identity);
            patrol.GetComponent<Patrol>().patrolPoints = patrolPoints;
            patrol.GetComponent<Patrol>().isActive = true;
        }
    }

    private Vector3 GetAvailableStartPos()
    {
        bool assigned = false;

        Vector3 availablePos = Vector3.zero;

        while (!assigned)
        {
            int randomNumber = Random.Range(0, 4);

            switch(randomNumber) {
                case 0:
                    if (!isLeftPosAssigned)
                    {
                        isLeftPosAssigned = true;
                        assigned = true;
                        availablePos = patrolPoints[0];
                    }
                    break;
                case 1:
                    if (!isRightPosAssigned)
                    {
                        isRightPosAssigned = true;
                        assigned = true;
                        availablePos = patrolPoints[1];
                    }
                    break;
                case 2:
                    if (!isUpPosAssigned)
                    {
                        isUpPosAssigned = true;
                        assigned = true;
                        availablePos = patrolPoints[2];
                    }
                    break;
                case 3:
                    if (!isDownPosAssigned)
                    {
                        isDownPosAssigned = true;
                        assigned = true;
                        availablePos = patrolPoints[3];
                    }
                    break;
            }
        }

        return availablePos; 
    }

    private void AssignPatrolPoints()
    {
        Vector3 position = transform.position;
        Vector3 scale = transform.localScale;

        Vector3 patrolPoint1 = new Vector3(position.x + scale.x / 2f + 0.35f, position.y - scale.y / 2f - 0.35f, -1f); //bottom right

        Vector3 patrolPoint2 = new Vector3(position.x - scale.x / 2f - 0.35f, position.y - scale.y / 2f - 0.35f, -1f); //bottom left

        Vector3 patrolPoint3 = new Vector3(position.x - scale.x / 2f - 0.35f, position.y + scale.y / 2f + 0.35f, -1f); //top left

        Vector3 patrolPoint4 = new Vector3(position.x + scale.x / 2f + 0.35f, position.y + scale.y / 2f + 0.35f, -1f); //top right

        patrolPoints[0] = patrolPoint1;
        patrolPoints[1] = patrolPoint2;
        patrolPoints[2] = patrolPoint3;
        patrolPoints[3] = patrolPoint4;
    }

    private void AssignNoOfPatrols()
    {
        if (GameManager.instance.difficulty == 1) noOfPatrols = Random.Range(1, 3);
        if (GameManager.instance.difficulty == 2) noOfPatrols = Random.Range(1, 4);
        if (GameManager.instance.difficulty == 3) noOfPatrols = Random.Range(1, 5);
    }
}
