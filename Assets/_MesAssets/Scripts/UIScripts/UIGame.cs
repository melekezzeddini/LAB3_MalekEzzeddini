using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGame : MonoBehaviour
{
    public static UIGame Instance;
    [SerializeField] private TextMeshProUGUI    _txtTime;
    [SerializeField] private TextMeshProUGUI    _txtCollisions;


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
        CollisionManager.OnCollisionOccured += CollisionManager_OnCollisionOccured;
        CollisionDisplayUI();
    }

    private void OnDestroy()
    {
        CollisionManager.OnCollisionOccured -= CollisionManager_OnCollisionOccured;
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
}
