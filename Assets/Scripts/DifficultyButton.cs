
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DifficultyButton : MonoBehaviour
{
    public Button button;
    public GameManager gameManager;
    public int difficulty;
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        button.onClick.AddListener(setDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void setDifficulty()
    {
        gameManager.startGame(difficulty);
    }
}
