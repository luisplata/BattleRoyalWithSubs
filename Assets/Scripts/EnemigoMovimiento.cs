using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemigoMovimiento : MonoBehaviour
{

    public GameObject habitacion;
    public Text texto;
    int random1, random2, random3;
    public int vida = 2;
    public float rotationSpeed = 1, distanciaSeguridad = 20;
    public GameObject Bullet;
    float BulletTime;
    public float BulletDelay = 2f;

    void Start()
    {
        texto.text = gameObject.name;
        BulletDelay = BulletDelay * Random.Range(1, 1.5f);
        metodoCambiarRuta();
    }

    void Update()
    {
        rotationSpeed = Random.Range(10, 30);
        transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(random1, random2, random3), rotationSpeed * Time.deltaTime);


        foreach (var item in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (item.name != gameObject.name)
            {
                if (Vector2.Distance(transform.position, item.transform.position) < distanciaSeguridad)
                {
                    transform.position = Vector3.MoveTowards(transform.position, item.transform.position,
                    rotationSpeed * Time.deltaTime);

                    if (BulletTime < 0)
                    {
                        Vector3 direction = item.transform.position - transform.position;
                        direction.Normalize();
                        float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                        var bullet = Instantiate(Bullet, transform.position, Quaternion.Euler(0f, 0f, rotation));
                        bullet.transform.parent = gameObject.transform;

                        BulletTime = BulletDelay;
                    }
                }
            }
            BulletTime -= Time.deltaTime;
        }
    }

    public void metodoCambiarRuta()
    {
        StartCoroutine("cambiarRuta");
    }
    IEnumerator cambiarRuta()
    {
        random1 = Random.Range(-1000, 1000);
        random2 = Random.Range(-1000, 1000);
        random3 = Random.Range(-1000, 1000);

        float tiempoRandom = Random.Range(3, 6);
        yield return new WaitForSeconds(tiempoRandom);
        metodoCambiarRuta();
    }
}