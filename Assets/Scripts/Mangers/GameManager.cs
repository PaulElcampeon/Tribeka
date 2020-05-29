using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int difficulty = 1;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDifficulty(int difficulty)
    {
        this.difficulty = difficulty;
    }
}
