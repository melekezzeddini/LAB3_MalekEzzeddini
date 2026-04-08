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

    private void Awake()
    {
        UIGame uiGame = FindAnyObjectByType<UIGame>();
        if (uiGame != null)
        {
            Destroy(uiGame.gameObject);
        }
    }
    public void Start()
    {
        EventSystem.current.SetSelectedGameObject(_buttonRestart.gameObject);
        _txtTotalTime.text = $"Time : {GameManager.Instance.EndTime:F2} sec.";
        _txtCollisions.text = $"Collisions : {GameManager.Instance.NbCollisions}";
        float total = GameManager.Instance.NbCollisions + GameManager.Instance.EndTime;
        _txtFinal.text = $"Final score : {total:F2}";


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
