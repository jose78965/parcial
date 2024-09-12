using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class movimineto : MonoBehaviour
{
    // Start is called before the first frame update
    public float spedd = 5;
    public float hInput;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.right *hInput* Time.deltaTime* spedd);
    }
    
}
