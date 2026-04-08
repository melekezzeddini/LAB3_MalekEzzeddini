using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager Instance;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        CollisionManager.OnCollisionOccured += CollisionManager_OnCollisionOccured;
    }

    private void OnDestroy()
    {
        CollisionManager.OnCollisionOccured -= CollisionManager_OnCollisionOccured;
    }

    private void CollisionManager_OnCollisionOccured(object sender, CollisionManager.OnCollisionOccuredEventArgs e)
    {

        _nbCollisions += e.collisionValue;
    }

    // Attributs
    private float _startTime;
    public float StartTime => _startTime;

    private float _endTime;
    public float EndTime { get => _endTime; set => _endTime = value; }

    private int _nbCollisions;
    public int NbCollisions => _nbCollisions;


    private float _offsetTime;
    private bool _isStarted;
  

    private float _timeZone1;
    private float _timeZone2;
    private float _timeZone3;

    public float offsetTime => _offsetTime;
    public bool IsStarted => _isStarted;

    // Initialisation

    private bool _isPaused = false;

    void Start()
    {
        
        _offsetTime = 0;
        _isStarted = false;
        _nbCollisions = 0;
        _startTime= Time.time;
        _isPaused = false;
        Player_NewInputSystem.OnPlayerPaused += Player_NewInputSystem_OnPlayerPaused;

    }

    private void Player_NewInputSystem_OnPlayerPaused(object sender, EventArgs e)
    {
        if (_isPaused)
        {
            Time.timeScale = 1.0f;
            _isPaused= false;
        }
        else
        {
            Time.timeScale = 0f;
            _isPaused = true;
        }
    }

    // Méthodes


    public void SetTimer()
    {
        _offsetTime = Time.time;
        _isStarted = true;
    }

   
    public void AddCollision(int p_value)
    {
        _nbCollisions += p_value;
    }
}
