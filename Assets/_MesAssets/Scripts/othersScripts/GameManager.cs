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
    }

    // Attributs
    private float _offsetTime;
    private bool _isStarted;
    private int _nbCollisions;

    private float _timeZone1;
    private float _timeZone2;
    private float _timeZone3;

    public float offsetTime => _offsetTime;
    public bool IsStarted => _isStarted;
    public int NbCollisions => _nbCollisions;

    // Initialisation
    void Start()
    {
        
        _offsetTime = 0;
        _isStarted = false;
        _nbCollisions = 0;

    }

    // Méthodes
    public void AddCollision(int p_value)
    {
        _nbCollisions += p_value;
    }

    public void SetTimer()
    {
        _offsetTime = Time.time;
        _isStarted = true;
    }

    public void StopTimer(int level)
    {
        switch (level)
        {
            case (0):
                _timeZone1 = Time.time - _offsetTime;
                break;
            case (1):
                _timeZone2 = Time.time - _offsetTime;
                break;
            case (2):
                _timeZone3= Time.time - _offsetTime;
                break;
        }
        _isStarted = false;
    }

    public float GetTimeZone(int level)
    {
        switch (level)
        {
            case 0: return _timeZone1;
            case 1: return _timeZone2;
            case 2: return _timeZone3;
        }

        return 0;
    }

    public float GetTotalTime()
    {
        return _timeZone1 + _timeZone2 + _timeZone3;
    }
}
