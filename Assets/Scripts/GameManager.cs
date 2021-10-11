using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score;
    private int highScore;
    private int level;
    [SerializeField]
    private float timeLimit;

    private AudioManager audioManager;

    public static GameManager gameManager;

    private void Awake()
    {
        MakeSingleton();
        Mole.OnHit += addScore;
        level = SceneManager.GetActiveScene().buildIndex;
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;

    }

    void MakeSingleton()
    {
        if (gameManager != null)
        {
            Destroy(gameObject);
        }
        else
        {
            gameManager = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public event Action onNextSceneEnter;
    public void NextSceneEnter()
    {
        onNextSceneEnter?.Invoke();
    }

    public event Action onRestartGame;
    public void RestartGame()
    {
        onRestartGame?.Invoke();
    }

    public event Action onExitEnter;
    public void ExitEnter()
    {
        onExitEnter?.Invoke();
    }


    public event Action onScoreGoal;
    public void ScoreGoal(int teamNumber)
    {
        onScoreGoal?.Invoke();
    }

    public event Action onFinishLevel;
    public void FinishLevel()
    {
        onFinishLevel?.Invoke();
    }

    public delegate void TimeLimitReached(float time, int score, int highScore);
    public static event TimeLimitReached OnTimedOut;

    private void TimeoutGame()
    {
        if (level != 0)
        {
            if (timeLimit > 0)
            {
                timeLimit -= Time.deltaTime;
                BeatHighScore();
                OnTimedOut(timeLimit, score, highScore);
                
            }
            else
            {
                BeatHighScore();
                startSelectedScene(0);

            }
        }
        else
        {
            return;
        }
        
    }

    void BeatHighScore()
    {
        if (score> highScore)
        {
            highScore = score;
        }
    }

    private void Update()
    {
        TimeoutGame();

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            NextSceneEnter();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitEnter();
        }
        else
        {
            FinishLevel();
        }
    }

    void addScore(int points)
    {
        score += points;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        level = scene.buildIndex;
        timeLimit = 30;
        score = 0;
        if (level != 0)
        {
            audioManager.PlayBGSound(true);
        }
        else
        {
            audioManager.PlayBGSound(false);

        }
    }

    public void startSelectedScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
