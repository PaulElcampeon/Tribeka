using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] blockTypes;

    private int difficulty;

    private int noOfBlocks;
    private float width;
    private float height;
    private float xMax, yMax;
    private float xMin = 0;
    private float yMin = 0;
    private float bufferSpaceSize = 3f;

    private void Awake()
    {
        difficulty = 1;//GameManager.instance.difficulty;
        AssignPropertiesBasedOnDifficulty();
        //Camera.main.transform.position = new Vector3(width/2, height/2, Camera.main.transform.position.z);
        //Generate();
    }

    public void Generate()
    {
        DestroyAnyCreatedBlocks();
        DestroyAnyCreatedPatrols();

        int blocks = noOfBlocks;
        int counter = 0;

        while (blocks > 0)
        {
            GameObject block = blockTypes[Random.Range(0, blockTypes.Length)];

            float sizeOfBlockWidth = block.transform.localScale.x + bufferSpaceSize;
            float sizeOfBlockHeight = block.transform.localScale.y + bufferSpaceSize;

            Vector2 sizeOfBlock = new Vector2(sizeOfBlockWidth, sizeOfBlockHeight);

            float blockMinX = xMin + sizeOfBlockWidth / 2f;
            float blockMaxX = xMax - sizeOfBlockWidth / 2f;

            float xPos = Random.Range(blockMinX, blockMaxX);

            float blockMinY = yMin + sizeOfBlockHeight / 2f;
            float blockMaxY = yMax - sizeOfBlockHeight / 2f;

            float yPos = Random.Range(blockMinY, blockMaxY);

            Collider2D collider = Physics2D.OverlapBox(new Vector2(xPos, yPos), sizeOfBlock, 0f);
            counter++;
            if (collider == null)
            {
                Instantiate(block, new Vector2(xPos, yPos), Quaternion.identity);
                blocks--;

            }

            if (counter >= 1000)
            {
                counter = 0;
                DestroyAnyCreatedBlocks();
                DestroyAnyCreatedPatrols();
                blocks = noOfBlocks;
            }
        }
    }

    private void AssignPropertiesBasedOnDifficulty()
    {
        if (difficulty == 1)
        {
            noOfBlocks = 4;
            width = 20f;
            height = 10f;
            xMax = width;
            yMax = height;

        }

        if (difficulty == 2)
        {
            noOfBlocks = 10;
            width = 30f;
            height = 15f;
            xMax = width;
            yMax = height;
        }

        if (difficulty == 3)
        {
            noOfBlocks = 15;
            width = 40f;
            height = 20f;
            xMax = width;
            yMax = height;
        }
    }

    private void DestroyAnyCreatedBlocks()
    {
        foreach (GameObject block in GameObject.FindGameObjectsWithTag("Block")) Destroy(block);
    }

    private void DestroyAnyCreatedPatrols()
    {
        foreach (GameObject patrol in GameObject.FindGameObjectsWithTag("Patrol")) Destroy(patrol);
    }
}
