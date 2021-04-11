using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaMovimiento : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Muros")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "EnemyNormal")
        {
            collision.gameObject.GetComponent<EnemigoMovimiento>().vida -= 1;
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "EnemigoGira")
        {
            collision.gameObject.GetComponent<EnemigoGira>().vida -= 1;
            Destroy(gameObject);
        }
    }

}
