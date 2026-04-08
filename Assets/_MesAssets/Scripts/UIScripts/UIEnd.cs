using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIEnd : MonoBehaviour
{

    [SerializeField] private Button _buttonRestart;

    [SerializeField] private TextMeshProUGUI _txtTotalTime;
    [SerializeField] private TextMeshProUGUI _txtCollisions;
    [SerializeField] private TextMeshProUGUI _txtFinal;

    public void Start()
    {
        EventSystem.current.SetSelectedGameObject(_buttonRestart.gameObject);

    }

    public void OnRestartClick()
    {
        SceneManager.LoadScene(0);

    }

    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif 

    }
}
