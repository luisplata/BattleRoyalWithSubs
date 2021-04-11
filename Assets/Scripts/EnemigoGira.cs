using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoGira : MonoBehaviour
{

    public GameObject topPart, habitacion;
    int random;
    public int vida = 2;
    private float random2;
    public float rotationSpeed, distanciaSeguridad = 20;
    public GameObject Bullet;
    float BulletTime;
    public float BulletDelay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(-1, 1);
        random2 = Random.value;
    }

    // Update is called once per frame
    void Update()
    {
        if (random == 0)
        {
            random = Random.Range(-1, 1);
        }
        if (random2 == 0)
        {
            random2 = Random.value;
        }

        transform.localRotation = transform.rotation * Quaternion.Euler(0, 0, rotationSpeed * random * -1 * random2);
        topPart.transform.localRotation = topPart.transform.rotation * Quaternion.Euler(0, 0, 1.5f * random);

        if (Vector2.Distance(transform.position, GameObject.Find("Player").transform.position) < distanciaSeguridad &&
             Camera.main.GetComponent<Camara>().HabitacionActual == habitacion)
        {
            transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Player").transform.position,
                rotationSpeed * Time.deltaTime);
            Shoot();
        }
        BulletTime -= Time.deltaTime;

        if (vida <= 0)
        {
            habitacion.GetComponent<Habitaciones>().CompruebaMuertos();
            Destroy(gameObject);
        }

    }
    void Shoot()
    {
        if (BulletTime < 0)
        {
            //Vector3 direction = GameObject.Find("Player").transform.position - transform.position;
            //direction.Normalize();
            //float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //Instantiate(Bullet, transform.position, Quaternion.Euler(0f, 0f, rotation));

            Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z));
            BulletTime = BulletDelay;
        }
    }
}
