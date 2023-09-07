using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroide : MonoBehaviour
{
    //1Velocidad del asteroide
    [SerializeField]
    private float _velocidad;
    void Start()
    {
        //2Inicializamos velocidad del meteoro
        _velocidad = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //Movemos el asteroide
        transform.Translate(Vector3.right * _velocidad * Time.deltaTime);

        if (transform.position.x > 8)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Collider: " + collision.name);
        if (collision.tag == "Laser") 
        {
            Destroy(gameObject);
        }
    }
}
