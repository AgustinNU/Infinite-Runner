using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float initialScrollSpeed;
    private int score;
    private float scoreTimer;
    private float scrollSpeed;
    public static GameManagerScript Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Update()
    {
        Score();
        UpdateSpeed();
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    private void Score()
    {
        int scorePerSeconds = 5;

        scoreTimer += Time.deltaTime;
        score = (int)(scoreTimer * scorePerSeconds);
        scoreText.text = string.Format("{0:00000}", score);    
    }

    public float GetScrollSpeed()
    {
        return scrollSpeed;
    }

    private void UpdateSpeed()
    {
        float speedDivider = 10f;
        scrollSpeed = initialScrollSpeed + (scoreTimer / speedDivider);
    }
}
