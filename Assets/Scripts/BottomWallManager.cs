using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomWallManager : MonoBehaviour
{

    public GameObject gameManager;
    private EndingsManager endManager;

    public void Start()
    {
        endManager = gameManager.GetComponent<EndingsManager>();
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

            endManager.FellOff();

        }
    }

}
