using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnNewGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnMouseUpAsButton()
    {
        SceneManager.LoadScene("EscenaJuego");
    }
}
