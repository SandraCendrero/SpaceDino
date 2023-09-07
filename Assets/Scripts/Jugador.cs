using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    //Creación de variable para capturar los ejes de movimiento, en este caso horizontal.
    public float horizontalInput;

    //Creación de variable para capturar los ejes de movimiento, en este caso vertical.
    public float verticalInput;

    //Creación de variable de velocidad. 
    public float velocidad;

    //Variable para coger el laser prefab
    [SerializeField]
    private GameObject _laserPrefab;

    //Variable de tiempo entre disparos
    [SerializeField]
    private float _EspacioEntreDisparos;
    //Variable que nos diga que ya posdemos disparar
    [SerializeField]
    private float _PuedesDisparar;

    [SerializeField]
    private bool _TripleDisparo;
    //Variable de gameObject de prefab triple disparo
    [SerializeField]
    private GameObject _TripleDisparoPrefab;

    [SerializeField]
    private bool _MasVelocidad;
    [SerializeField]
    private GameObject _MasVelocidadPrefab;

    [SerializeField]
    private bool _Escudo;
    [SerializeField]
    private GameObject _EscudoPrefab;

    void Start()
    {
        //Colocamos la nave de ataque en el centro.
        //La cargamos en el Start.
        this.transform.position = new Vector3(6, 0, 0);

        //Inicializamos la velocidad.
        velocidad = 5f;

        //Inicializar variables de tiempo entre disparos
        _EspacioEntreDisparos = 0.25f;
        _PuedesDisparar = 0.0f;

        _TripleDisparo = false;
        _MasVelocidad = false;
        _Escudo = false;
    }
    void Update()
    {

       

       

       // public void Movimiento()
       
        
        //Cargamos la variable con el eje horizontal.
        horizontalInput = Input.GetAxis("Horizontal");

        //Le decimos que se traslade hacia la derecha por la velocidad que va a desplazarse
        //por la dirección hacia la que va, positiva derecha, negativa izquierda por el
        //tiempo que gestiona la uniformidad del movimiento.
        this.transform.Translate(Vector3.right*velocidad*horizontalInput*Time.deltaTime);

        //Cargamos la variable con el eje vertical.
        verticalInput = Input.GetAxis("Vertical");

        //Le decimos que se traslade hacia arriba por la velocidad que va a desplazarse
        //por la dirección hacia la que va, positiva arriba, negativa abajo por el
        //tiempo que gestiona la uniformidad del movimiento.
        this.transform.Translate(Vector3.up*velocidad*verticalInput*Time.deltaTime);

        //Ponemos los límites de arriba y abajo preguntando cada límite por separado y lo reubicamos
        //en la posición de Y y mantenemos en la que esté en X.
        if (transform.position.y > 3f)
        {
            transform.position = new Vector3(transform.position.x, 3f, 0);
        }
        else if (transform.position.y < -4f)
        {
            transform.position = new Vector3(transform.position.x, -4f, 0);
        }
       if (transform.position.x > 7f)
        {
            transform.position = new Vector3(7f, transform.position.y, 0);
        }
        else if (transform.position.x < -5f)
        {
            transform.position = new Vector3(-5f, transform.position.y, 0);
        }

        //Se coloca la z porque el space se bloquea con las flechas de derecha y abajo
        //Preguntamos si podemos disparar
        if (Time.time > _PuedesDisparar)
        { 
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0))

        { Instantiate(_laserPrefab, transform.position + new Vector3(0f, 0.42f, 0), Quaternion.identity); 
             //Establecemo0s el tiempo de disparo
        _PuedesDisparar = Time.time + _EspacioEntreDisparos;
            }
        
        }
        
    }

    public void Movimiento()
    {
        if (_MasVelocidad == true)
        {
            horizontalInput = Input.GetAxis("Horizontal");

            this.transform.Translate(Vector3.right * velocidad *  15f * horizontalInput * Time.deltaTime);

            verticalInput = Input.GetAxis("Vertical");

            this.transform.Translate(Vector3.up * velocidad * 15f * verticalInput * Time.deltaTime);
        }
        else
        {
            horizontalInput = Input.GetAxis("Horizontal");
            this.transform.Translate(Vector3.right * velocidad * horizontalInput * Time.deltaTime);
            verticalInput = Input.GetAxis("Vertical");
            this.transform.Translate(Vector3.up * velocidad * verticalInput * Time.deltaTime);
        }
    }

    public void Disparo()
    {
        //Es triple disparo??
        if (_TripleDisparo==false)
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0f, 0.42f, 0), Quaternion.identity);
            //Establecemo0s el tiempo de disparo
            _PuedesDisparar = Time.time + _EspacioEntreDisparos;
        }
        else
        {
            //Creamos el disparo triple
            Instantiate(_TripleDisparoPrefab, this.transform.position, Quaternion.identity);
        }
    }
    //Creamos el metodo que activa el triple disparo
    public void TripleDisparoPowerUpOn() 
    {
        //Hacemos que el power up triple disparo se active
        _TripleDisparo = true;
    }

    public void SuperVelocidadPowerUpOn()
    {
        //Hacemos que el power up triple disparo se active
        _MasVelocidad = true;
    }

    public void EscudoPowerUpOn()
    {
        //Hacemos que el power up triple disparo se active
        _Escudo = true;
    }
}