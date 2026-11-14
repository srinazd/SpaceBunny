using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    public TMP_Text highScoreText;

    void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        highScoreText.text = "HIGH SCORE: " + highScore;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

     public void ExitGame()
    {
        Application.Quit();

        Debug.Log("exiting the game...");
}
}
