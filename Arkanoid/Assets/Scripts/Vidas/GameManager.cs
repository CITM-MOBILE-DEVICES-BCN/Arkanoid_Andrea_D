using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // Usamos TextMeshPro

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

    void Start()
    {
        currentOrientation = Screen.orientation;
        UpdateLives();
        UpdateScore();
        UpdateHighScore();
        SpawnBall();  // Generar la primera pelota al iniciar el juego
    }

    void Update()
    {
        UpdateScore();
        // Comprobar si la pelota ha salido por la parte inferior de la pantalla
        if (currentBall != null && currentBall.transform.position.y < -5f)
        {
            LoseLife();
        }
        // Detectar si la orientación cambia
        if (Screen.orientation != currentOrientation)
        {
            currentOrientation = Screen.orientation;
            HandleOrientationChange();
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

    // Método para generar una nueva pelota
    void SpawnBall()
    {
        currentBall = Instantiate(ballPrefab, platform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
    }

    // Método para reiniciar la pelota
    void ResetBall()
    {
        // Destruir la pelota actual
        Destroy(currentBall);

        // Generar una nueva pelota en la posición de la plataforma
        SpawnBall();
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

    void HandleOrientationChange()
    {
        if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
        {
            // Aquí puedes ajustar el HUD o cualquier otro elemento para modo vertical
            Debug.Log("Cambiado a Portrait");
        }
        else if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
        {
            // Aquí puedes ajustar el HUD o cualquier otro elemento para modo horizontal
            Debug.Log("Cambiado a Landscape");
        }
    }
}
