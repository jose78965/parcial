using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Contadorenemigos : MonoBehaviour
{
    // Start is called before the first frame update
    public int score =1;
    public TMP_Text enemiText;
    void Start()
    {

    }


    // Update is called once per frame
    public void actualizar(int puntos)
    {
        score += puntos;
        enemiText.text = "enemigos:" + score;
    }
}
