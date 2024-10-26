using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
      
    public void ResumeGame()
    {
        gameObject.SetActive(false);
        GameObject GM = GameObject.Find("GameManager");
        GameManager gmScript = GM.GetComponent<GameManager>();
        gmScript.ResumeGame();
    }

    public void GoToMenu()
    {
        GameObject GM = GameObject.Find("GameManager");
        GameManager gmScript = GM.GetComponent<GameManager>();
        gmScript.ResumeGame();
        SceneManager.LoadScene("Menu");
    }
}
