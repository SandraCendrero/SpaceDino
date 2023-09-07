using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    // Variable privada pero modificable solo en unity
    [SerializeField]
    private float speed;
    private GameManager gameManager;
    void Start()
    {
        speed=10.0f;
    }


    void Update()
    {
        //crear el movimiento del laser
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        //Preguntar si ha salido del límite de la psntslls y suicidarlo en ese caso

        if (transform.position.x < -8)
        {
            Destroy(gameObject);
        }
    }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //Debug.Log("Collaider: " + collision.name);
            //Si hemos colisionado con el asteroide.
            if (collision.tag == "Asteroide")
            {
                Destroy(gameObject);
            }
        }
}
