using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Velocidad de bajada del powerup
    [SerializeField]
    private float _speed;
    //Variable para asignar el tipo de power up
    [SerializeField]
    private int powerUpID; //0=disparotriple, 1=velocidad, 2=escudo

    void Start()
    {
        //Inicializar la velocidad
        _speed = 1.0f;
    }

   
    void Update()
    {
        //que baje el powe up
        this.transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Con qué colisionamos
        //Debug.Log("Choca con " + collision.name);
        //Creo un objeto de tipo clase jugador y obtengo todos los métodos(componentes)
        Jugador jugador = collision.GetComponent<Jugador>();

        if (jugador != null)
        {

            if(powerUpID==0)
                {
                jugador.TripleDisparoPowerUpOn();
            }

            else if (powerUpID==1)
            {
                jugador.SuperVelocidadPowerUpOn();
            }

            else if (powerUpID == 2)
            {
                jugador.EscudoPowerUpOn();
            }
            //Mandamos ejecutar en Jugador el metodo de triple disparo a true 
            
        }
        //Destruimos el power up

        Destroy(this.gameObject);
    }

}
