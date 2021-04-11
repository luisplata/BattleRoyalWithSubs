using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour
{

    public Sprite cerrada, abierta;   
    public bool puertaCerrada;
    public BoxCollider2D colliderPuerta;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (puertaCerrada == true)
        {
            GetComponent<SpriteRenderer>().sprite = cerrada;
            colliderPuerta.enabled = true;
        }
        else if (puertaCerrada == false)
        {
            GetComponent<SpriteRenderer>().sprite = abierta;
            colliderPuerta.enabled = false;
        }
    }
}
