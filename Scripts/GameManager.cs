using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TMP_Text scoreText;
    public TMP_Text livesText;
    public int score = 0;
    public int lives = 3;
     public TMP_Text finalScoreText;
     public GameObject gameOverPanel;
    private bool isGameOver = false;
    public bool IsGameOver => isGameOver;
    public CameraPostProcessing cameraEffects;
    public static GameManager Instance;
 
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Time.timeScale = 1f;
        score = 0;
        lives = 3;
        isGameOver = false;
        FallingObject.ResetDifficulty();

        gameOverPanel.SetActive(false);
        UpdateUI();
    }
    public void AddScore(int points)
    {
        if (isGameOver)
            return;
    score += points;
    UpdateUI();

        
    }


    public void LoseLife()
    {
         if (isGameOver)
            return;

        lives--;

        if(lives < 0){
            lives = 0;
        }

        UpdateUI();

        if (lives <= 0)
        {
            GameOver();
        }
    }

     void GameOver()
    {
        isGameOver = true;
        int savedHighScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > savedHighScore)
        {
            PlayerPrefs.SetInt("HighScore", score );
            PlayerPrefs.Save();
        }

        finalScoreText.text = "Final Score: " + score;

        gameOverPanel.SetActive(true);
        if (cameraEffects != null)
        {
            cameraEffects.PlayGameOverEffect();
        }
        Time.timeScale = 0f;
    }

      void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
    }
    

     public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}
