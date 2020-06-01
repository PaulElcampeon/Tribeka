using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] blockTypes;

    [SerializeField]
    private GameObject startRef;

    [SerializeField]
    private GameObject endRef;

    [SerializeField]
    private GameObject playerRef;

    [SerializeField]
    private GameObject floorRef;

    [SerializeField]
    private GameObject helicopterRef;

    private int difficulty;
    private int noOfBlocks;
    public float width;
    public float height;
    private float xMax, yMax;
    private float xMin = 0;
    private float yMin = 0;
    private float bufferSpaceSize = 3f;

    public static LevelGenerator instance;

    private void Awake()
    {
        instance = this;    
    }

    private void Start()
    {
        difficulty = GameManager.instance.difficulty;
        AssignPropertiesBasedOnDifficulty();
        ResizeFloor();
        AssignStartAndEnd();
        SpawnPlayer();
        Generate();
        if (difficulty >= 5) SpawnHelicopter();
    }

    private void Generate()
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

    //For Testing purposes
    public void Regenerate()
    {
        Generate();
        SpawnHelicopter();
    }

    private void SpawnHelicopter()
    {
        Instantiate(helicopterRef, new Vector3(0f, 0f), Quaternion.identity);
    }

    private void ResizeFloor()
    {
        GameObject floor = Instantiate(floorRef, new Vector3(width / 2f, height / 2f, 1f), Quaternion.identity);
        floor.transform.localScale = new Vector3(width, height);
    }

    private void SpawnPlayer()
    {
        Instantiate(playerRef, startRef.transform.position, Quaternion.identity);
    }

    private void AssignStartAndEnd()
    {
        Instantiate(startRef, new Vector3(0.5f, 0.5f), Quaternion.identity);
        Instantiate(endRef, new Vector3(width - 0.5f, height - 0.5f), Quaternion.identity);
    }

    private void AssignPropertiesBasedOnDifficulty()
    {
        if (difficulty >= 1 && difficulty <= 5)
        {
            width = 20f;
            height = 10f;
        } else if (difficulty >= 6 && difficulty <= 10)
        {
            width = 30f;
            height = 10f;
        } else if (difficulty >= 11 && difficulty <= 15)
        {
            width = 30f;
            height = 15f;
        } else if (difficulty >= 16 && difficulty <= 20)
        {
            width = 40f;
            height = 15f;
        }

        if (difficulty == 1) noOfBlocks = 5;
        if (difficulty == 2) noOfBlocks = 6;
        if (difficulty == 3) noOfBlocks = 7;
        if (difficulty == 4) noOfBlocks = 8;
        if (difficulty == 5) noOfBlocks = 9;
        if (difficulty == 6) noOfBlocks = 10;
        if (difficulty == 8) noOfBlocks = 11;
        if (difficulty == 9) noOfBlocks = 12;
        if (difficulty == 10) noOfBlocks = 13;
        if (difficulty == 11) noOfBlocks = 14;
        if (difficulty == 12) noOfBlocks = 15;
        if (difficulty == 13) noOfBlocks = 16;
        if (difficulty == 14) noOfBlocks = 17;
        if (difficulty == 15) noOfBlocks = 18;
        if (difficulty == 16) noOfBlocks = 19;
        if (difficulty == 17) noOfBlocks = 20;
        if (difficulty == 18) noOfBlocks = 21;
        if (difficulty == 19) noOfBlocks = 22;
        if (difficulty == 20) noOfBlocks = 23;

        xMax = width;
        yMax = height;
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
