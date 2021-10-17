using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // library of textmeshproGUI
using UnityEngine.SceneManagement;// library of scene component (text, button)
using UnityEngine.UI; // library of button
public class GameManager : MonoBehaviour
{
    public Button restartButton; 
    public List<GameObject> targets;
    public GameObject titleScreen;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private float spawnRate = 1.0f;
    private int score;
    void Start()
    {
       

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
      
    }
    public void  UpdateScore(int scoreToUpdate)
    {
        score += scoreToUpdate;
        scoreText.text = "Score: " + score;
    }


    public void gameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
    public void startGame(int difficulty)
    {
        score = 0;
        spawnRate = spawnRate / difficulty;
        scoreText.text = "Score: " + score;
        StartCoroutine(SpawnTarget());
        titleScreen.gameObject.SetActive(false);
    }
}

