using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GO : MonoBehaviour
{
    public class GameOverManager : MonoBehaviour
{
    public void RestartGame()
    {
        // Reiniciar el juego desde el primer nivel
        SceneManager.LoadScene("Level1Scene");
    }

    public void BackToMainMenu()
    {
        // Cargar la escena del menú principal
        SceneManager.LoadScene("MainMenu");
    }
}

// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
