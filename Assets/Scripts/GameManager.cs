using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float tiempo;
    // Variable que contenga el asteroide
    [SerializeField]
    private GameObject _asteroide;
    void Start()
    {
        //Inicio de la corrutina
        StartCoroutine(Asteroides());
        tiempo = 2f;
    }

    // Para controlar el tiempo con la corrutina
    IEnumerator Asteroides()
    {     //Creo un bucle que va a ir creando los asteroides
        while (true)
        {
            Instantiate(_asteroide, new Vector3(-10, Random.Range(3.8f, -4f), 0), Quaternion.identity);

            //Dar un tiempo entre un asteroide y otro
            yield return new WaitForSeconds(tiempo);

        }
    }
}

//Instantiate(_asteroide, new Vector3(9,Random.Range (4f, -4f), 0), Quaternion.identity);

