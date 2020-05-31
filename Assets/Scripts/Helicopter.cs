using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{

    [SerializeField]
    private float speed;

    private int randomNumber;
    private Vector3[] patrolPoints = new Vector3[3];
    private Vector3 currentTargetPoint;
    private int currentIndex;
    private bool isReady = true;
    private bool isMovingForward = true;
 
    void Start()
    {
        randomNumber = Random.Range(0, 4);
        ComputePatrolPoints();
        AssignFirstPoint();
    }

    void Update()
    {
        MoveToPatrolPoint();
    }

    private void MoveToPatrolPoint()
    {
        Vector3 newPoint = Vector3.MoveTowards(transform.position, currentTargetPoint, speed * Time.deltaTime);

        transform.position = new Vector3(newPoint.x, newPoint.y, -1f);

        if (Vector3.Distance(currentTargetPoint, transform.position) <= 1f)
        {
            if (isReady) StartCoroutine(AssignNewPatrolPoint());
        }
    }

    private IEnumerator AssignNewPatrolPoint()
    {
        isReady = false;

        yield return new WaitForSeconds(2f);

        if (isMovingForward)
        {
            if (currentIndex == 2)
            {
                isMovingForward = false;
                currentIndex = 1;
                currentTargetPoint = patrolPoints[1];
            }
            else
            {
                currentIndex++;
                currentTargetPoint = patrolPoints[currentIndex];
            }
        } else
        {
            if (currentIndex == 0)
            {
                isMovingForward = true;
                currentIndex = 1;
                currentTargetPoint = patrolPoints[1];
            }
            else
            {
                currentIndex--;
                currentTargetPoint = patrolPoints[currentIndex];
            }
        }

        isReady = true;
    }

    private void AssignFirstPoint()
    {
        currentTargetPoint = patrolPoints[0];
        currentIndex = 0;
        transform.position = new Vector3(currentTargetPoint.x, currentTargetPoint.y, -1f);
    }

    private void ComputePatrolPoints()
    {
        if (randomNumber == 0)//Vertical
        {
            float floorWidth = LevelGenerator.instance.width;
            float floorHeight = LevelGenerator.instance.height;

            patrolPoints[0] = new Vector3(floorWidth / 2f, floorHeight - 1f);
            patrolPoints[1] = new Vector3(floorWidth / 2f, floorHeight / 2f);
            patrolPoints[2] = new Vector3(floorWidth / 2f, 1f);
        }

        if (randomNumber == 1)//Horizontal
        {
            float floorWidth = LevelGenerator.instance.width;
            float floorHeight = LevelGenerator.instance.height;

            patrolPoints[0] = new Vector3(1f, floorHeight / 2f);
            patrolPoints[1] = new Vector3(floorWidth / 2f, floorHeight / 2f);
            patrolPoints[2] = new Vector3(floorWidth - 1f, floorHeight / 2f);
        }

        if (randomNumber == 2)//Right Diagonal
        {
            float floorWidth = LevelGenerator.instance.width;
            float floorHeight = LevelGenerator.instance.height;

            patrolPoints[0] = new Vector3(floorWidth - 1f, floorHeight - 1f);
            patrolPoints[1] = new Vector3(floorWidth / 2f, floorHeight / 2f);
            patrolPoints[2] = new Vector3(1f, 1f);
        }

        if (randomNumber == 3)//Left Diagonal
        {
            float floorWidth = LevelGenerator.instance.width;
            float floorHeight = LevelGenerator.instance.height;

            patrolPoints[0] = new Vector3(1f, floorHeight - 1f);
            patrolPoints[1] = new Vector3(floorWidth / 2f, floorHeight / 2f);
            patrolPoints[2] = new Vector3(floorWidth - 1f, 1f);
        }
    }
}
