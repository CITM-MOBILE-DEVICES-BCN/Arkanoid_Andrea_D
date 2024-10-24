using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private SaveLoadSystem SLSystem;
    private bool canContinue = false;
    // Start is called before the first frame update
    void Start()
    {
        SLSystem = GetComponent<SaveLoadSystem>();
        PlayerData data = SLSystem.LoadData();
        if(data != null)
        {
            canContinue = data.newGame;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerData Loaddata = SLSystem.LoadData();
            if (Loaddata != null)
            {
                PlayerData Savedata = new PlayerData();
                Savedata.lives = 3;
                Savedata.points = 0;
                Savedata.highScore = Loaddata.highScore;
                Savedata.currentlvl = 0;
                Savedata.newGame = true;
                SLSystem.SaveData(Savedata);
            }
            else
            {
                PlayerData Savedata = new PlayerData();
                Savedata.newGame = true;
                SLSystem.SaveData(Savedata);
            }
            SceneManager.LoadScene("Level1");
        }
        else if (Input.GetKeyDown(KeyCode.Z) && !canContinue)
        {

            PlayerData data = SLSystem.LoadData();
            if (data != null)
            {
                if (data.currentlvl == 0)
                {
                    SceneManager.LoadScene("Level1");
                }
                else
                {
                    SceneManager.LoadScene("Level2");
                }
            }
        }
    }
}
