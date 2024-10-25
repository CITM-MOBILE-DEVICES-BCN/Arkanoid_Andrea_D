using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NextLvl : MonoBehaviour
{
    public TextMeshProUGUI CurrentLvlText;
    public TextMeshProUGUI NextLvlText;
    private SaveLoadSystem SLSystem;
    private float timeToChangeScree;
    private PlayerData lvlData;
    // Start is called before the first frame update
    void Start()
    {
        SLSystem = GetComponent<SaveLoadSystem>();
        lvlData = SLSystem.LoadData();
        if(lvlData.currentlvl == 0)
        {
            CurrentLvlText.text = "Level " + (lvlData.currentlvl + 2).ToString() + " finished";
        }
        else
        {
            CurrentLvlText.text = "Level " + (lvlData.currentlvl).ToString() + " finished";
        }
        NextLvlText.text = "Next: Level " + (lvlData.currentlvl + 1).ToString();
        timeToChangeScree = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        timeToChangeScree -= Time.deltaTime;
        if(timeToChangeScree <= 0.0f)
        {
            if (lvlData.currentlvl == 0)
            {
                SceneManager.LoadScene("Level1");
            }
            else if (lvlData.currentlvl == 1)
            {
                SceneManager.LoadScene("Level2");
            }
        }
    }
}
