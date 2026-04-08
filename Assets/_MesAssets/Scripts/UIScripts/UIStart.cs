using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIStart : MonoBehaviour
{

    [SerializeField] private GameObject _InstructionsPanel;
    [SerializeField] private GameObject _gameButtons;
    [SerializeField] private Button _ButtonStart;
    [SerializeField] private Button _ButtonClose;

    private void Awake()
    {
        GameManager gameManager =FindAnyObjectByType<GameManager>();
        if (gameManager != null)
        {
            Destroy(gameManager.gameObject );
        }

        UIGame uigame = FindAnyObjectByType<UIGame>();
        if (uigame != null)
        {
            Destroy(uigame.gameObject);
        }
    }

    public void Start()
    {
        EventSystem.current.SetSelectedGameObject(_ButtonStart.gameObject);
    }
    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying= false;
#else
        Application.Quit();
#endif 

    }
    public void OnInstructionsClick()
    {
        _InstructionsPanel.SetActive(true);
        _gameButtons.SetActive(false);
        EventSystem.current.SetSelectedGameObject(_ButtonClose.gameObject);

    }
    public void OnStartClick()
    {
        SceneManager.LoadScene(1);
    }

    public void OnCloseClick()
    {
        _InstructionsPanel.SetActive(false);
        _gameButtons.SetActive(true);
        EventSystem.current.SetSelectedGameObject(_ButtonStart.gameObject);

    }


}
