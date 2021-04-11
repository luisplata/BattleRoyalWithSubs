using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habitaciones : MonoBehaviour
{
    public GameObject[] puertas;
    public GameObject[] enemigos;
    public bool abierta, enemigosMuertos;
    private bool puertasAbiertas, primeraVisita;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        puertasAbiertas = !puertas[0].GetComponent<Puertas>().puertaCerrada;

        if (abierta == false && puertasAbiertas == true)
        {
            foreach (GameObject puerta in puertas)
            {
                puerta.GetComponent<Puertas>().puertaCerrada = true;
            }
        }
        else if (abierta == true && puertasAbiertas == false)
        {
            foreach (GameObject puerta in puertas)
            {
                puerta.GetComponent<Puertas>().puertaCerrada = false;
            }
        }

        if (enemigosMuertos)
        {
            abierta = true;
        }
        //Debug.Log("abierta: " + abierta + "******* puertasAbiertas: " + puertasAbiertas);
    }

    public void CompruebaMuertos()
    {
        //enemigosMuertos = true;
        int contador = 0;
        for (int i = 0; i < enemigos.Length; i++)
        {
            if (enemigos[i] != null)
            {
                contador++;
                enemigosMuertos = false;
            }
            
            //Como llama antes de morir, si queda 1 es justo el último que muere
            if (contador <= 1) enemigosMuertos = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (primeraVisita == false)
            {
                primeraVisita = true;
                abierta = false;
            }
        }
    }

}
