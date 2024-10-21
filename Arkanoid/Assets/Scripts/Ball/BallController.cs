using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallController : MonoBehaviour
{
    public float speed = 5f;         // Velocidad inicial de la pelota
    public float speedIncrease = 0.2f;  // Aumento de velocidad en cada rebote
    private Rigidbody2D rb;
    private float minBounceAngle = 0.1f;  // Para evitar rebotes horizontales
    private bool gameStarted = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Lanzar la pelota en una dirección inicial aleatoria
        rb.velocity = new Vector2(Random.Range(-1f, 1f), 1).normalized * speed;
    }

    void Update()
    {
        if (!gameStarted)
        {
            // Coloca la bola sobre la plataforma
            transform.position = new Vector2(GameObject.Find("Platform").transform.position.x, -3.5f);

            // Lanza la bola después de 2 segundos
            if (Time.time > 2f)
            {
                gameStarted = true;
                rb.velocity = new Vector2(2, 10).normalized * speed; // Dirección inicial
            }
        }
    }

    // Cuando choca con algo, aumenta la velocidad
    void OnCollisionEnter2D(Collision2D col)
    {
        // Aumentar la velocidad después de cada colisión
        speed += speedIncrease;

        if (rb != null)
        {
            // Normalizar la velocidad después de cada rebote
            rb.velocity = rb.velocity.normalized * speed;

            // Asegurarse de que la pelota no tenga un ángulo de rebote completamente horizontal
            if (Mathf.Abs(rb.velocity.y) < minBounceAngle)
            {
                rb.velocity = new Vector2(rb.velocity.x, Mathf.Sign(rb.velocity.y) * minBounceAngle).normalized * speed;
            }
        }
    }
}
