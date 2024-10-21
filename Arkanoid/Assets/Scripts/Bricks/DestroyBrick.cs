using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Brick : MonoBehaviour
{
    public int resistance = 1;  // Resistencia del bloque (cu�ntos golpes puede recibir)
    public Sprite[] damageSprites;  // Array de sprites para mostrar el da�o (opcional)

    private int currentResistance;  // Resistencia actual del bloque
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        currentResistance = resistance;  // Inicializa la resistencia actual
        spriteRenderer = GetComponent<SpriteRenderer>();  // Obtiene el SpriteRenderer si necesitas cambiar el sprite del bloque da�ado
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
            spriteRenderer.sprite = damageSprites[resistance - currentResistance];  // Cambia el sprite
        }

        // Si la resistencia del bloque llega a 0, se destruye
        if (currentResistance <= 0)
        {
            gmScript.points += 10;
            DestroyBlock();
        }
        else
        {
            gmScript.points += 1;
        }
    }
    // M�todo para destruir el bloque
    void DestroyBlock()
    {
        // Aqu� puedes agregar m�s l�gica, como sumar puntos
        Destroy(gameObject);  // Destruye el bloque
    }

}