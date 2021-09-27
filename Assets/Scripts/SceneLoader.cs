using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    private void Start()
    {
        GameManager.gameManager.onNextSceneEnter += LoadNextScene;
        GameManager.gameManager.onRestartGame += LoadStartScene;
        GameManager.gameManager.onExitEnter += QuitGame;
        //menu = this.transform.GetChild(0).gameObject;
    }

    #region NewSceneFunctions
    private void OnEnable()
    {


    }

    private void OnDisable()
    {
        GameManager.gameManager.onNextSceneEnter -= LoadNextScene;
        GameManager.gameManager.onExitEnter -= QuitGame;
    }

    

    #endregion


    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        if (currentSceneIndex == sceneCount - 1)
        {
            LoadStartScene();
        }
        else
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }

    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
