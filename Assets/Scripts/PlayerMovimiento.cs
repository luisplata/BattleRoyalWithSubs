using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovimiento : MonoBehaviour
{
    public Sprite arriba, abajo, derecha, izquierda, vidaSi, vidaNo, muerte;
    public GameObject Bullet, pergamino, gameOver;
    public GameObject[] contadorVidas;
    public int vidaRestante = 3, vidaAnterior, vidaTotal;
    public float speed;
    float BulletTime;
    public float BulletDelay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        vidaRestante = vidaAnterior;
    }

    // Update is called once per frame
    void Update()
    {
        if (vidaRestante > 0)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                GetComponent<SpriteRenderer>().sprite = izquierda;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                GetComponent<SpriteRenderer>().sprite = derecha;
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                GetComponent<SpriteRenderer>().sprite = arriba;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                GetComponent<SpriteRenderer>().sprite = abajo;
            }

            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                transform.position += new Vector3(speed * Input.GetAxisRaw("Horizontal") * Time.deltaTime,
                    speed * Input.GetAxisRaw("Vertical") * Time.deltaTime);
            }
                                          
            if (Input.GetKeyDown(KeyCode.Keypad0))
            {
                if (BulletTime < 0)
                {
                    switch (GetComponent<SpriteRenderer>().sprite.name)
                    {
                        case "pj1":
                            Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 270));
                            break;
                        case "pj2":
                            Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 180));
                            break;
                        case "pj3":
                            Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 0));
                            break;
                        case "pj4":
                        default:
                            Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 90));
                            break;
                    }
                    BulletTime = BulletDelay;
                }
            }
            BulletTime -= Time.deltaTime;

            #region  Disparar sin importar donde está mirando el PJ
            //if (Input.GetAxis("HorizontalShoot") != 0 || Input.GetAxis("VerticalShoot") != 0)
            //{
            //    if (BulletTime < 0)
            //    {
            //        if (Input.GetAxis("HorizontalShoot") == 1)
            //        {
            //            //transform.rotation = Quaternion.Euler(0, 0, 0);
            //            Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 0));
            //        }
            //        else if (Input.GetAxis("HorizontalShoot") == -1)
            //        {
            //            //transform.rotation = Quaternion.Euler(0, 0, 180);
            //            Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 180));
            //        }
            //        else if (Input.GetAxis("VerticalShoot") == -1)
            //        {
            //            //transform.rotation = Quaternion.Euler(0, 0, 90);
            //            Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 90));
            //        }
            //        else if (Input.GetAxis("VerticalShoot") == 1)
            //        {
            //            // transform.rotation = Quaternion.Euler(0, 0, 270);
            //            Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 270));
            //        }

            //        BulletTime = BulletDelay;
            //    }
            //}
            #endregion
            
            if (vidaRestante != vidaAnterior)
            {
                for (int i = 0; i < vidaTotal; i++)
                {
                    if (vidaRestante > i)
                    {
                        contadorVidas[i].GetComponent<SpriteRenderer>().sprite = vidaSi;
                    }
                    else
                    {
                        contadorVidas[i].GetComponent<SpriteRenderer>().sprite = vidaNo;
                    }
                }


                vidaAnterior = vidaRestante;
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = muerte;
            pergamino.SetActive(true);
            gameOver.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Y))
            {
                //Ambas formas funcionan
                //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                SceneManager.LoadScene(1);
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                //Go to Main Menu
                SceneManager.LoadScene(0);
            }
        }
    }
}
