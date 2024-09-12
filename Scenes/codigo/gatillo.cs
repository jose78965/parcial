using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class gatillo : MonoBehaviour
{
    public GameObject laser;
    public float fireRate = 0.5f;  // Intervalo de tiempo entre disparos
    private float nextFireTime = 0f;
    private AudioSource audioSource;
    public AudioClip disparoSonido;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Al presionar el botón de disparo (como clic izquierdo)
        {
            Disparar();
        }

    }

    void Disparar()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            // Instancia el láser solo si ha pasado el tiempo de cooldown
            Instantiate(laser, transform.position, quaternion.identity);
            nextFireTime = Time.time + fireRate;  // Actualiza el tiempo del próximo disparo
        }
        if (disparoSonido != null && audioSource != null)
        {
            audioSource.PlayOneShot(disparoSonido); // Reproducir el sonido una vez
        }
    }
}
