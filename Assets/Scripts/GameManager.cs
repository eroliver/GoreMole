using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    private int score;

    
    public static GameManager gameManager;

    private void Awake()
    {
        MakeSingleton();
        Mole.OnHit += addScore;
        score = 0;
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            NextSceneEnter();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitEnter();
        }
    }

    void addScore(int points)
    {
        score += points;
        Debug.Log(score);
    }

}
