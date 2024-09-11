using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class puntuacion : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public TMP_Text scoreText;
    void Start()
    {
        
    }
   

    // Update is called once per frame
   public void actualizar(int puntos)
    {
        score +=puntos;
        scoreText.text = "score:"+ score;
    }
}
