using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class EndLevel : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int noScene = SceneManager.GetActiveScene().buildIndex;


            if (noScene < SceneManager.sceneCountInBuildSettings - 2)
            {
                SceneManager.LoadScene(noScene + 1);
            }
            else
            {
                collision.gameObject.GetComponent<Player_NewInputSystem>().DisableInputActions();
                GameManager.Instance.EndTime = Time.time - GameManager.Instance.StartTime;
                SceneManager.LoadScene(noScene + 1);
            }
        }
    }
}