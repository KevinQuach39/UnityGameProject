using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject startScreenPanel;
    public GameObject gameUIPanel;
    public GameObject gameOverPanel;
    [Header("Gameplay Objects")]
    public GameObject player;
    public GameObject enemySpawner;
    void Start()
    {
        startScreenPanel.SetActive(true);
        gameUIPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        player.SetActive(false);
        enemySpawner.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void StartGame()
    {
        startScreenPanel.SetActive(false);
        gameUIPanel.SetActive(true);
        player.SetActive(true);
        enemySpawner.SetActive(true);
        gameOverPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void RestartGame()
    {
        if (Score.Instance != null)
        {
            Score.Instance.ResetKills();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}