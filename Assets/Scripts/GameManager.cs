using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}
    public static event Action OnScoreChanged;

    [SerializeField] private LevelPreviewData[] _levels;
    private int _currentLevelIndex;
    private float _defaultTimeScale = 1.0f;


    public int Score { 
        get { return _score; }
    }
    
    private int _score;




    public void OnEnable()
    {
        SceneManager.activeSceneChanged += OnSetDefaultTimeScale;
    }

    public void OnDisable()
    {
        SceneManager.activeSceneChanged -= OnSetDefaultTimeScale;
    }


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    public void AddScore(int amount)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException(
                $"Amount should be positive: {gameObject.name}" 
            );
        
        _score += amount;
        OnScoreChanged?.Invoke();
        Debug.Log($"Score: {_score}");
    }






    private void OnSetDefaultTimeScale(UnityEngine.SceneManagement.Scene current, UnityEngine.SceneManagement.Scene next)
    {
        Time.timeScale = _defaultTimeScale;
    }


    public void FinishCurrentLevel()
    {
        SceneManager.LoadScene(0);
        OpenAccessToNextLevel();
    }

    private void EndGame()
    {
        SceneManager.LoadScene(0);  //пока что
    }


    private void OpenAccessToNextLevel()
    {
        if (_currentLevelIndex + 1 != _levels.Length)
            _levels[_currentLevelIndex + 1].isAccesible = true;
    }

    public void SetLevelIndex(int newIndex)
    {
        _currentLevelIndex = newIndex;
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadNextLevel()
    {
        OpenAccessToNextLevel();

        if (_currentLevelIndex + 1 != _levels.Length)
        {
            SetLevelIndex(_currentLevelIndex + 1);
            SceneManager.LoadScene(_levels[_currentLevelIndex].SceneIndex);
        }
        else
        {
            EndGame();
        }
        
    }

    public void PauseGame()
    {
        Time.timeScale = (Time.timeScale == 1.0f) ? 0f : 1.0f; 
    }
}
