using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo : MonoBehaviour
{
    public float speed;
    public float fireRate = 0.5f;  // Tiempo en segundos entre disparos
    private float nextFireTime = 0f;  // Controla cuándo el jugador puede disparar de nuevo

    private puntuacion scriptPuntuacion;
    private Contadorenemigos scriptenemigos;

    void Start()
    {
        scriptPuntuacion = GameObject.Find("controlPuntuacion").GetComponent<puntuacion>();
        scriptenemigos = GameObject.Find("controlEnemigos").GetComponent<Contadorenemigos>();

    }

    void Update()
    {
        // Mueve el proyectil
        transform.Translate(Vector2.up * Time.deltaTime * speed);

        // Si el jugador presiona la tecla de disparo y el tiempo de cooldown ha pasado
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;  // Actualiza el tiempo para el próximo disparo
        }
    }

  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemigo")
        {
            Destroy(collision.gameObject);  // Destruye el enemigo
            scriptPuntuacion.actualizar(10);  // Actualiza la puntuación
            scriptenemigos.actualizar(1);
            Destroy(gameObject);  // Destruye el proyectil
        }
        if (collision.gameObject.tag == "GameObject")
        {
            Destroy(gameObject);  // Destruye el proyectil si colisiona con otro objeto
        }
    }
}
