using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UpdateLevel : MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().text = "Lv: " + GameManager.instance.difficulty;
    }
}
