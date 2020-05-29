using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    private Vector3 currentPatrolPoint;

    public Vector3[] patrolPoints;
    private bool isFacingCorrectDirection;
    public bool isActive;
    private bool isFirstTurn = true;
    private bool isAssigningFirstPatrolPoint = true;

    private void Awake()
    {
        currentPatrolPoint = transform.position;
    }

    void Update()
    {
        if (!isFacingCorrectDirection) FaceDirectionWeAreMoving();

        if (isActive && isFacingCorrectDirection) MoveToPatrolPoint();
    }

    private void MoveToPatrolPoint()
    {
        Vector3 newPosition = Vector3.MoveTowards(transform.position, currentPatrolPoint, 2f * Time.deltaTime);
        transform.position = new Vector3(newPosition.x, newPosition.y, -1f);

        if (Vector2.Distance(transform.position, currentPatrolPoint) < 0.1)
        {
            
            isFacingCorrectDirection = false;

            AssignNewPatrolPoint();

            isAssigningFirstPatrolPoint = false;
        }
    }

    private void FaceDirectionWeAreMoving()
    {
        Vector3 moveDirection = currentPatrolPoint - transform.position;

        float targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;

        if (isFirstTurn)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, targetAngle);
            isFirstTurn = false;
        } else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, Mathf.MoveTowards(transform.rotation.eulerAngles.z, targetAngle, 10f * Time.deltaTime));
        }

        targetAngle = targetAngle < 0 ? 360 + targetAngle : targetAngle;

        if (Mathf.Abs(targetAngle - transform.rotation.eulerAngles.z) > 0.2)
        {
            return;
        }
        else
        {
            isFacingCorrectDirection = true;
        }
    }

    private void AssignNewPatrolPoint()
    {
        int currentIndex = 0;

        for (int i = 0; i < 4; i++)
        {
            if (patrolPoints[i] == currentPatrolPoint)
            {
                currentIndex = i;
            }
        }

        if (currentIndex == 3)
        {
            currentPatrolPoint = patrolPoints[0];
        } else
        {
            currentPatrolPoint = patrolPoints[currentIndex + 1];
        }
    }

    public void AssignFirstPatrolPoint(Vector3 point)
    {
        currentPatrolPoint = point;
    }
}
