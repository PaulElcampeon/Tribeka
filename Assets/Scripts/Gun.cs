using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private LineRenderer lazer;

    private void Awake()
    {
        lazer = GetComponent<LineRenderer>();
        transform.position += transform.right/3;
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);

        if (hit.point != Vector2.zero)
        {
            //Debug.DrawLine(transform.position, hit.point, Color.red);
            lazer.SetPosition(0, transform.position);
            lazer.SetPosition(1, hit.point);

            if (hit.collider.tag == "Player")
            {
                if (GameManager.instance.isGameWon) return;

                if (GameManager.instance.isGameOver == false)
                {
                    SoundManager.instance.PlaySFX(Random.Range(4, 6));
                    GameManager.instance.isGameOver = true;                    
                    hit.collider.gameObject.GetComponent<CharacterController>().Explode();
                    StartCoroutine(Camera.main.gameObject.GetComponent<CameraShake>().Shake(1f, 0.5f));
                    StartCoroutine(OpenRetryPanel());
                }
            }
        }
    }

    private IEnumerator OpenRetryPanel()
    {
        yield return new WaitForSeconds(2f);

        InGameMenu.instance.OpenRetryPanel();
    }
}
