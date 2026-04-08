using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class UIGame : MonoBehaviour
{
    public static UIGame Instance;
    [SerializeField] private TextMeshProUGUI    _txtTime;
    [SerializeField] private TextMeshProUGUI    _txtCollisions;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private Button _continueButton ;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogError("un game object essai de cree un deuxieme UIGame");
            Destroy(gameObject);
        }
        
    }
    private void Start()
    {
        Time.timeScale = 1.0f; 
        _pausePanel.SetActive(false);
        CollisionManager.OnCollisionOccured += CollisionManager_OnCollisionOccured;
        Player_NewInputSystem.OnPlayerPaused += Player_NewInputSystem_OnPlayerPaused;
        CollisionDisplayUI();

    }


    private void OnDestroy()
    {
        CollisionManager.OnCollisionOccured -= CollisionManager_OnCollisionOccured;
        Player_NewInputSystem.OnPlayerPaused -= Player_NewInputSystem_OnPlayerPaused;

    }
    private void Player_NewInputSystem_OnPlayerPaused(object sender, System.EventArgs e)
    {
        _pausePanel.SetActive(!_pausePanel.activeSelf);
        EventSystem.current.SetSelectedGameObject(_continueButton.gameObject);
    }
    private void Update()
    {
        TimeDisplayUI();
    }

    private void TimeDisplayUI()
    {
        float elapsedTime = Time.time - GameManager.Instance.StartTime;
       // _txtTime.text = " Temps: " + elapsedTime.ToString("f2");
        _txtTime.text = $" Temps: {elapsedTime:0.00}";

        /*
          private void TimeDisplayUI()
        {
            float elapsedTime = Time.time - GameManager.Instance.StartTime;

            int minutes = Mathf.FloorToInt(elapsedTime / 60f);
            int seconds = Mathf.FloorToInt(elapsedTime % 60f);
            int centiseconds = Mathf.FloorToInt((elapsedTime * 100) % 100);

            _txtTime.text = $"Temps: {minutes:00}:{seconds:00}.{centiseconds:00}";
        }
         * */
    }
    private void CollisionDisplayUI()
    {
        _txtCollisions.text = $" Collisions: {GameManager.Instance.NbCollisions}";
    }
    private void CollisionManager_OnCollisionOccured(object sender, CollisionManager.OnCollisionOccuredEventArgs e)
    {
        CollisionDisplayUI();
    }
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
        SceneManager.LoadScene(0);

    }

    public void OnContinueClick()
    {


    }




}
