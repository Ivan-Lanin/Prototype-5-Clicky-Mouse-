using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField] private RawImage pauseImage;

    public List<GameObject> targets;
    private float spawnRate = 2.0f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public bool isGameActive;
    public bool isPaused = false;
    public GameObject titleScreen;
    private int score;
    private int lives = 3;


    private void Start() {
        
    }


    IEnumerator SpawnTarget() {
        while (isGameActive) {
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            yield return new WaitForSeconds(spawnRate);
        }
    }


    public void UpdateScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }


    public void UpdateLives(int livesToExtract) {
        lives -= livesToExtract;
        livesText.text = "Lives: " + lives;
        if (lives <= 0) {
            GameOver();
        }
    }


    public void GameOver() {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }


    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void StartGame(int difficulty) {
        isGameActive = true;
        StartCoroutine("SpawnTarget");
        spawnRate /= difficulty;
        score = 0;
        UpdateScore(0);
        UpdateLives(0);
        titleScreen.gameObject.SetActive(false);
    }


    public void SetPause() {
        if (!isPaused) {
            PauseGame();
            isPaused = true;
            pauseImage.gameObject.SetActive(true);
        }
        else {
            ResumeGame();
            isPaused = false;
            pauseImage.gameObject.SetActive(false);
        }
    }


    public void PauseGame() {
        Time.timeScale = 0;
    }


    public void ResumeGame() {
        Time.timeScale = 1;
    }
}
