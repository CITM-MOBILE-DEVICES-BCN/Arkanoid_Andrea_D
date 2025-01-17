using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallController : MonoBehaviour
{
    public float speed = 5f;         // Velocidad inicial de la pelota
    public float speedIncrease = 0.2f;  // Aumento de velocidad en cada rebote
    private Rigidbody2D rb;
    private float minBounceAngle = 0.5f;  // Para evitar rebotes horizontales
    public bool gameStarted = false;
    private float timer = 2.0f;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        // Lanzar la pelota en una direcci�n inicial aleatoria
        rb.velocity = new Vector2(Random.Range(-1f, 1f), 1).normalized * speed;
    }

    void Update()
    {
        if (!gameStarted)
        {
            // Coloca la bola sobre la plataforma
            transform.position = new Vector2(GameObject.Find("Platform").transform.position.x, 0.5f);
            timer -= Time.deltaTime;
            speed = 5f;
            // Lanza la bola despu�s de 2 segundos
            if (timer < 0.0f)
            {
                gameStarted = true;
                rb.velocity = new Vector2(2, 10).normalized * speed; // Direcci�n inicial
                timer = 2.0f;
            }
        }
    }

    // Cuando choca con algo, aumenta la velocidad
    void OnCollisionEnter2D(Collision2D col)
    {
        // Aumentar la velocidad despu�s de cada colisi�n
        speed += speedIncrease;
        audioSource.Play();

        if (rb != null)
        {
            // Normalizar la velocidad despu�s de cada rebote
            rb.velocity = rb.velocity.normalized * speed;

            // Asegurarse de que la pelota no tenga un �ngulo de rebote completamente horizontal
            if (Mathf.Abs(rb.velocity.y) < minBounceAngle)
            {
                rb.velocity = new Vector2(rb.velocity.x, Mathf.Sign(rb.velocity.y) * minBounceAngle).normalized * speed;
            }
        }

    }
}
