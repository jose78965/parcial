using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigos : MonoBehaviour
{
    public float speed = 5;
    public GameObject enemigo;  // Prefab del enemigo
    public float tiempo = 1f;  // Tiempo entre la invocaci�n de nuevos enemigos
    public Vector2 posicionFija;  // Posici�n fija para la aparici�n de nuevos enemigos
    public int maxEnemigos = 10;  // L�mite m�ximo de enemigos

    private int currentEnemigos = 0;  // Contador de enemigos actuales

    void Start()
    {
        // Repite la generaci�n de enemigos cada 'tiempo' segundos
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
            // Mueve al enemigo hacia abajo y cambia la direcci�n
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            speed *= -1;
        }
    }

    private void GenerarEnemigo()
    {
        // Verifica si el n�mero actual de enemigos es menor que el l�mite
        if (currentEnemigos < maxEnemigos)
        {
            // Usa la posici�n fija para la aparici�n de nuevos enemigos
            Vector2 posicion = posicionFija;

            // Instancia el prefab en la posici�n fija
            Instantiate(enemigo, posicion, Quaternion.identity);
            currentEnemigos++;  // Incrementa el contador de enemigos
        }
    }

    // Llama a este m�todo cuando un enemigo se destruya
    public void EnemigoDestruido()
    {
        currentEnemigos--;  // Decrementa el contador de enemigos
    }
}
