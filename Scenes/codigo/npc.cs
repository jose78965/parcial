using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour
{
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

}
