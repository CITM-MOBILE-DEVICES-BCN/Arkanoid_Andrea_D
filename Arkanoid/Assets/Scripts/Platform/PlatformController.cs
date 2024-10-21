using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float speed = 10f;              // Velocidad de la plataforma
    public float autoSpeed = 8f;           // Velocidad en modo automático
    public bool autoMode = false;          // Alternar entre modo manual y automático
    public GameObject ball;                // Referencia a la pelota
    
    private float screenHalfWidthInWorldUnits;

    void Start()
    {
       
        // Calculamos la mitad de la pantalla en unidades del mundo para limitar el movimiento
        float halfPlatformWidth = transform.localScale.x / 2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize - halfPlatformWidth;

    }


    // Mover la plataforma con el ratón
    void MoveWithMouse()
    {
        // Obtener la posición del ratón en coordenadas del mundo
        float mouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;

        // Limitar el movimiento de la plataforma dentro de los límites de la pantalla
        mouseX = Mathf.Clamp(mouseX, -screenHalfWidthInWorldUnits, screenHalfWidthInWorldUnits);

        // Mover la plataforma a la posición del ratón en el eje X
        transform.position = new Vector2(mouseX, transform.position.y);
    }

    // Modo automático para mover la plataforma siguiendo la pelota
    void AutoMove()
    {
        ball = GameObject.FindGameObjectWithTag("Ball"); //Al no detectar la bola le añadimos esto
        if (ball != null)
        {
            // Obtener la posición de la pelota
            float ballX = ball.transform.position.x;

            // Mover la plataforma hacia la pelota con cierta velocidad
            float targetX = Mathf.MoveTowards(transform.position.x, ballX, autoSpeed * Time.deltaTime);

            // Limitar el movimiento dentro de los límites de la pantalla
            targetX = Mathf.Clamp(targetX, -screenHalfWidthInWorldUnits, screenHalfWidthInWorldUnits);

            // Aplicar el movimiento a la plataforma
            transform.position = new Vector2(targetX, transform.position.y);
         

        }
    }

    void Update()
    {

        // Alternar entre modo automático y manual al presionar la tecla A
        if (Input.GetKeyDown(KeyCode.A))
        {
            autoMode = !autoMode;
        }

        if (!autoMode)  // Modo controlado por el jugador
        {
            MoveWithMouse();
        }
        else            // Modo automático
        {
            AutoMove();
        }
    }
}