using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.isGameWon = true;

            SoundManager.instance.PlaySFX(3);

            StartCoroutine(OpenVictoryPanel());
        }
    }

    private IEnumerator OpenVictoryPanel()
    {
        yield return new WaitForSeconds(1.5f);

        InGameMenu.instance.OpenVictoryPanel();
    }
}
