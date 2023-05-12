using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 2.0f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private int score;


    private void Start() {
        StartCoroutine("SpawnTarget");
        score = 0;
        UpdateScore(0);
    }


    IEnumerator SpawnTarget() {
        while (true) {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }


    public void UpdateScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }


    public void GameOver() {
        gameOverText.gameObject.SetActive(true);
    }
}
