using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject menuUI;    
    public GameObject gameplayUI;  
    public GameObject gameOverUI; 
    public GameObject player;     
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        ShowMenu();
    }
    public void ShowMenu()
    {
        Time.timeScale = 0f; 
        menuUI.SetActive(true);    
        gameplayUI.SetActive(false);
        gameOverUI.SetActive(false); 
        player.SetActive(false);    
    }
    public void StartGame()
    {
        Time.timeScale = 1f; 
        menuUI.SetActive(false);     
        gameplayUI.SetActive(true);  
        gameOverUI.SetActive(false); 
        player.SetActive(true);
    }
    public void GameOver()
    {
        Time.timeScale = 0f;         
        gameOverUI.SetActive(true); 
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
    public void QuitGame()
    {
        Application.Quit(); 
        print("Quit Game");
    }
}