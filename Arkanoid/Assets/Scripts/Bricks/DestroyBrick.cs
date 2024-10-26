using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Brick : MonoBehaviour
{
    private int currentResistance;  // Resistencia actual del bloque
    public bool power = false;


    void Start()
    {
        currentResistance = Random.Range(1,4);  // Inicializa la resistencia actual
        getColor();

        int random = Random.Range(1, 7);

        if (random == 3)
        {
            power = true;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Comprobar si la colisión fue con la pelota
        if (collision.gameObject.CompareTag("Ball"))
        {
            TakeDamage();  // El bloque recibe daño
        }
    }
    // Método para que el bloque reciba daño
    void TakeDamage()
    {
        currentResistance--;  // Reduce la resistencia actual en 1

        GameObject GM = GameObject.Find("GameManager");
        GameManager gmScript = GM.GetComponent<GameManager>();

        // Si la resistencia del bloque llega a 0, se destruye
        if (currentResistance <= 0)
        {
            gmScript.points += 10;
            gmScript.currentblocks -= 1;
            gmScript.PlayBlockSound();
            DestroyBlock();
        }
        else
        {
            getColor();
            gmScript.points += 1;
        }
    }
    // Método para destruir el bloque
    void DestroyBlock()
    {
        if (power)
        {
            GameObject GM = GameObject.Find("GameManager");
            GameManager gmScript = GM.GetComponent<GameManager>();
            gmScript.PowerUP();
        }
       
        Destroy(gameObject);  // Destruye el bloque
    }

    void getColor()
    {
        if (power)
        {
            GetComponent<Image>().color = new Color(0, 0, 0, 255);
        }
        else
        {
            switch (currentResistance)
            {
                case 3:
                    GetComponent<Image>().color = new Color(255, 0, 0, 255);
                    break;
                case 2:
                    GetComponent<Image>().color = new Color(255, 0, 255, 255);
                    break;
                case 1:
                    GetComponent<Image>().color = new Color(255, 255, 0, 255);
                    break;
            }
        }
     
        
    }

}