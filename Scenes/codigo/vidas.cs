using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;// Asegúrate de importar este espacio de nombres

public class vidas : MonoBehaviour
{
    public int lives = 3;
    public Image[] vidasUI;  // UI para mostrar las vidas restantes
    public TextMeshProUGUI gameOverText;  // Referencia al texto de Game Over
    private bool isGameOver = false;

    void Start()
    {
        // Asegúrate de que el texto de Game Over esté oculto al inicio
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemigo")
        {
            Destroy(collision.gameObject);  // Destruye el enemigo
            lives -= 1;
            UpdateLivesUI();

            if (lives <= 0 && !isGameOver)
            {
                GameOver();
            }
        }
    }

    private void UpdateLivesUI()
    {
        for (int i = 0; i < vidasUI.Length; i++)
        {
            if (i < lives)
            {
                vidasUI[i].enabled = true;
            }
            else
            {
                vidasUI[i].enabled = false;
            }
        }
    }

    private void GameOver()
    {
        isGameOver = true;
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true);  // Muestra el texto de Game Over
        }
        Time.timeScale = 0;  // Pausa el juego
    }
}
