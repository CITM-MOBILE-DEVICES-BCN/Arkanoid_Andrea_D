using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformController : MonoBehaviour
{
    public float speed = 10f;              // Velocidad de la plataforma
    public float autoSpeed = 8f;           // Velocidad en modo autom�tico
    public bool autoMode = false;          // Alternar entre modo manual y autom�tico
    public GameObject ball;                // Referencia a la pelota
    public Slider controlSlider;           // Referencia al Slider


    private float screenHalfWidthInWorldUnits;
    private float halfPlatformWidth;

    void Start()
    {
        halfPlatformWidth = GetComponent<RectTransform>().rect.width / 2;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize - halfPlatformWidth;
    }


    void MoveWithSlider()
    {
        // Obtener el valor del Slider (de 0 a 1)
        float sliderValue = controlSlider.value;

        // Calcular la posici�n horizontal seg�n el valor del Slider
        float targetX = Mathf.Lerp(-screenHalfWidthInWorldUnits, screenHalfWidthInWorldUnits, sliderValue);

        // Mover la plataforma hacia la nueva posici�n
        transform.position = new Vector2(targetX, transform.position.y);
    }

    // Modo autom�tico para mover la plataforma siguiendo la pelota
    void AutoMove()
    {
        ball = GameObject.FindGameObjectWithTag("Ball"); //Al no detectar la bola le a�adimos esto
        if (ball != null)
        {
            // Obtener la posici�n de la pelota
            float ballX = ball.transform.position.x;

            // Mover la plataforma hacia la pelota con cierta velocidad
            float targetX = Mathf.MoveTowards(transform.position.x, ballX, autoSpeed * Time.deltaTime);

            // Limitar el movimiento dentro de los l�mites de la pantalla
            targetX = Mathf.Clamp(targetX, -screenHalfWidthInWorldUnits, screenHalfWidthInWorldUnits);

            // Aplicar el movimiento a la plataforma
            transform.position = new Vector2(targetX, transform.position.y);
         

        }
    }

    void Update()
    {
        halfPlatformWidth = transform.localScale.x/2;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize - halfPlatformWidth;

        // Alternar entre modo autom�tico y manual al presionar la tecla A
        if (Input.GetKeyDown(KeyCode.A))
        {
            autoMode = !autoMode;
        }

        if (!autoMode)  // Modo controlado por el jugador
        {
            MoveWithSlider();
        }
        else            // Modo autom�tico
        {
            AutoMove();
        }

        //Debug.Log(GetComponent<RectTransform>().offsetMax.x);
    }
}