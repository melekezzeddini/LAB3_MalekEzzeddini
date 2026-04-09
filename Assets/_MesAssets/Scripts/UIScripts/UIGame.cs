using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class UIGame : UI
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
            //Debug.LogError("un game object essai de cree un deuxieme UIGame");
            Destroy(gameObject);
        }
        
    }
    private void Start()
    {
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
        float elapsedTime = GameManager.Instance.GetElapsedTime();
        _txtTime.text = $" Time : {elapsedTime:0.00}";
    }


    private void CollisionDisplayUI()
    {
        _txtCollisions.text = $" Collisions: {GameManager.Instance.NbCollisions}";
    }
    private void CollisionManager_OnCollisionOccured(object sender, CollisionManager.OnCollisionOccuredEventArgs e)
    {
        CollisionDisplayUI();
    }




    public void OnContinueClick()
    {
        Player_NewInputSystem.TriggerOnPlayerPaused(this);

    }

    public void OnRestartLevelClick()
    {
        GameManager.Instance.RestoreLevelState();
        CollisionDisplayUI();
        TimeDisplayUI();

        EventSystem.current.SetSelectedGameObject(null);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (_pausePanel.activeSelf)
        {
            Time.timeScale = 0f;
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(_continueButton.gameObject);
        }
    }

}
