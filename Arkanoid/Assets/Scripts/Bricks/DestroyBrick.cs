using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Brick : MonoBehaviour
{
    public Sprite[] damageSprites;  // Array de sprites para mostrar el da�o (opcional)

    private int currentResistance;  // Resistencia actual del bloque
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        currentResistance = Random.Range(1,4);  // Inicializa la resistencia actual
        spriteRenderer = GetComponent<SpriteRenderer>();  // Obtiene el SpriteRenderer si necesitas cambiar el sprite del bloque da�ado
        getColor();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Comprobar si la colisi�n fue con la pelota
        if (collision.gameObject.CompareTag("Ball"))
        {
            TakeDamage();  // El bloque recibe da�o
        }
    }
    // M�todo para que el bloque reciba da�o
    void TakeDamage()
    {
        currentResistance--;  // Reduce la resistencia actual en 1

        GameObject GM = GameObject.Find("GameManager");
        GameManager gmScript = GM.GetComponent<GameManager>(); ;

        // Si se han definido sprites para mostrar el da�o
        if (damageSprites != null && currentResistance > 0 && currentResistance <= damageSprites.Length)
        {
            spriteRenderer.sprite = damageSprites[currentResistance - currentResistance];  // Cambia el sprite
        }

        // Si la resistencia del bloque llega a 0, se destruye
        if (currentResistance <= 0)
        {
            gmScript.points += 10;
            DestroyBlock();
        }
        else
        {
            getColor();
            gmScript.points += 1;
        }
    }
    // M�todo para destruir el bloque
    void DestroyBlock()
    {
        // Aqu� puedes agregar m�s l�gica, como sumar puntos
        Destroy(gameObject);  // Destruye el bloque
    }

    void getColor()
    {
        switch (currentResistance)
        {
            case 3:
                GetComponent<Image>().color = new Color(255, 0, 0, 255);
                break;
            case 2:
                GetComponent<Image>().color = new Color(0, 255, 0, 255);
                break;
            case 1:
                GetComponent<Image>().color = new Color(0, 0, 255, 255);
                break;
        }
        
    }

}