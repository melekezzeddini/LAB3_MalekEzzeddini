using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif 

    }

    public void OnRestartClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
