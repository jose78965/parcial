using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigos : MonoBehaviour
{
    public float speed = 5;
    public GameObject enemigo;  // Prefab del enemigo
    public float tiempo = 1f;  // Tiempo entre la invocación de nuevos enemigos
    public Vector2 posicionFija;  // Posición fija para la aparición de nuevos enemigos
    public int maxEnemigos = 10;  // Límite máximo de enemigos

    private int currentEnemigos = 0;  // Contador de enemigos actuales

    void Start()
    {
        // Repite la generación de enemigos cada 'tiempo' segundos
        InvokeRepeating("GenerarEnemigo", 6f, tiempo);
    }

    void Update()
    {
        // Movimiento horizontal de los enemigos
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GameObject")
        {
            // Mueve al enemigo hacia abajo y cambia la dirección
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            speed *= -1;
        }
    }

    private void GenerarEnemigo()
    {
        // Verifica si el número actual de enemigos es menor que el límite
        if (currentEnemigos < maxEnemigos)
        {
            // Usa la posición fija para la aparición de nuevos enemigos
            Vector2 posicion = posicionFija;

            // Instancia el prefab en la posición fija
            Instantiate(enemigo, posicion, Quaternion.identity);
            currentEnemigos++;  // Incrementa el contador de enemigos
        }
    }

    // Llama a este método cuando un enemigo se destruya
    public void EnemigoDestruido()
    {
        currentEnemigos--;  // Decrementa el contador de enemigos
    }
}
