using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text timer;
    [SerializeField]
    private TMP_Text currentScore;
    [SerializeField]
    private TMP_Text displayedHighScore;


    
    // Start is called before the first frame update
    void Start()
    {
        GameManager.OnTimedOut += UpdateUI;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateUI(float timeLimit, int score, int highScore)
    {
        timer.text = Mathf.Floor(timeLimit).ToString();
        currentScore.text = "Score: " + score.ToString();
        displayedHighScore.text = "High Score: " + highScore.ToString();
    }
}
