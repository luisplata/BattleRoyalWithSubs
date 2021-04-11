using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaMovimientoEnemigo : MonoBehaviour
{
    public float speed;
    private string _nameOfParent;

    public string NameOfParent => _nameOfParent;
    void Start()
    {
        Destroy(gameObject, 2f);
    }

    public void Configurate(string nameOfParent)
    {
        _nameOfParent = nameOfParent;
    }

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != _nameOfParent)
        {
            if (collision.gameObject.CompareTag("Muros"))
            {
                Destroy(gameObject);
            }
            if (collision.gameObject.CompareTag("Player"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
