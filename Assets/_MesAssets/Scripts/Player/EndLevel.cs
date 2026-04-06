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

            GameManager.Instance.StopTimer(noScene);

            if (noScene >= SceneManager.sceneCountInBuildSettings - 1)
            {
                collision.gameObject.GetComponent<Player_NewInputSystem>().DisableInputActions();

                Debug.Log(
                   "========= Fin de la partie =========\n" +
                    $"Niveau 1 : {Math.Round(GameManager.Instance.GetTimeZone(0), 2)}s\n" +
                    $"Niveau 2 : {Math.Round(GameManager.Instance.GetTimeZone(1), 2)}s\n" +
                    $"Niveau 3 : {Math.Round(GameManager.Instance.GetTimeZone(2), 2)}s\n" +
                    $"Temps total : {Math.Round(GameManager.Instance.GetTotalTime(), 2)}s\n" +
                    $"Collisions : {GameManager.Instance.NbCollisions}\n" +
                    $"Score final : {Math.Round(GameManager.Instance.GetTotalTime() + GameManager.Instance.NbCollisions, 2)}"
                );

                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(noScene + 1);
            }
        }
    }
}
