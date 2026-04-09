using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private float _levelStartTime;
    private int _levelStartCollisions;
    public float LevelStartTime => _levelStartTime;
    public int LevelStartCollisions => _levelStartCollisions;


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

    public void Start()
    {
        _offsetTime = 0;
        _isStarted = false;
        _nbCollisions = 0;
        _startTime = 0f;
        _isPaused = false;

        _levelStartTime = 0f;
        _levelStartCollisions = 0;

        Player_NewInputSystem.OnPlayerPaused += Player_NewInputSystem_OnPlayerPaused;
    }

    public void SaveLevelState()
    {
        _levelStartTime = Time.time;
        _levelStartCollisions = _nbCollisions;
    }

    public void RestoreLevelState()
    {
        _startTime = _levelStartTime;
        _nbCollisions = _levelStartCollisions;
        _isStarted = true;
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
        _startTime = Time.time;
        _isStarted = true;
    }


    public void AddCollision(int p_value)
    {
        _nbCollisions += p_value;
    }
}
