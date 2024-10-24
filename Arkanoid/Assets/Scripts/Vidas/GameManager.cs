using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // Usamos TextMeshPro
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI livesText;    // Referencia al texto de vidas
    public TextMeshProUGUI scoreText;    // Referencia al texto de puntos
    public TextMeshProUGUI highScoreText; // Referencia al texto de high score

    public int lives = 3;
    public int points = 0;
    public int highScore = 0;
    public GameObject ballPrefab;           // Prefab de la pelota
    public Transform platform;               // La plataforma para resetear su posición
    private GameObject currentBall;          // Referencia a la pelota actual
    private ScreenOrientation currentOrientation;
    private int currentLevel = 0;
    public int currentblocks;
    private int totalblocks;
    void Start()
    {
        currentOrientation = Screen.orientation;
        UpdateLives();
        UpdateScore();
        UpdateHighScore();
        currentBall = GameObject.FindGameObjectWithTag("Ball");
        GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");
        totalblocks = bricks.Length;
        currentblocks = bricks.Length;
    }

    void Update()
    {
        UpdateScore();
        // Comprobar si la pelota ha salido por la parte inferior de la pantalla
        if (currentBall != null && currentBall.transform.position.y < -5.0f)
        {
            LoseLife();
        }

        if(currentblocks == 0)
        {
            if (currentLevel == 0)
            {
                currentLevel++;
                SceneManager.LoadScene("Level2");
            }
            else if(currentLevel == 1)
            {
                currentLevel--;
                SceneManager.LoadScene("Level1");
            }
        }
    }

    // Método para restar una vida y reiniciar la pelota
    void LoseLife()
    {
        lives--;
        UpdateLives();
        if (lives > 0)
        {
            // Si quedan vidas, volver a generar la pelota
            ResetBall();
        }
        else
        {
            // Si se acaban las vidas, termina el juego
            GameOver();
        }
    }

    // Método para reiniciar la pelota
    void ResetBall()
    {
        currentBall.GetComponent<BallController>().gameStarted = false;
    }

    // Método para manejar el Game Over
    void GameOver()
    {
        if(highScore < points)
        {
            highScore = points;
            UpdateScore();
        }
        Debug.Log("Game Over!");  // Aquí puedes añadir una pantalla de Game Over o reiniciar el nivel
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reiniciar la escena para reiniciar el juego
    }

    public void UpdateLives()
    {
        livesText.text = "Vidas: " + lives.ToString();
    }

    // Método para actualizar los puntos en el HUD
    public void UpdateScore()
    {
        scoreText.text = "Puntos: " + points.ToString();
    }

    // Método para actualizar el high score en el HUD
    public void UpdateHighScore()
    {
        highScoreText.text = "High Score: " + highScore.ToString();

    }
}
