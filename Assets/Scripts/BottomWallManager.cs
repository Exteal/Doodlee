using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomWallManager : MonoBehaviour
{
    
    public Camera mainCamera;
    public Canvas endUI;

    private void Start()
    {
        endUI.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (!collision.CompareTag("Player"))
            {
                collision.gameObject.SetActive(false);
                return;
            }

            //SceneManager.LoadScene("EndScreen");
            HandleEnd();

        }
    }


    private void HandleEnd()
    {
        //Vector3 currentPos = mainCamera.transform.position;
        mainCamera.transform.Translate(new Vector2(0, -10));// Vector3.MoveTowards(currentPos, new Vector2(currentPos.x, currentPos.y  - 10), 25);
        endUI.enabled = !(endUI.enabled);
    }
}
