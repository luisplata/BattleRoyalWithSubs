using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject HabitacionActual;
    private Vector3 ref1 = Vector3.zero;
    private Vector3 posicionFinal;
    public float smoothness;
    
    void Update()
    {
        if (transform.position != new Vector3(HabitacionActual.transform.position.x, HabitacionActual.transform.position.y, -10.3f))
        {
            posicionFinal = new Vector3(HabitacionActual.transform.position.x, HabitacionActual.transform.position.y, -10.3f);
            transform.position = Vector3.SmoothDamp(transform.position, posicionFinal, ref ref1, smoothness);
        }
    }
}
