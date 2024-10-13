using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottomWallManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (!collision.CompareTag("Player"))
            {
                collision.gameObject.SetActive(false);
                return;
            }

            SceneManager.LoadScene("EndScreen");
        }
    }
}
