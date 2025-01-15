using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventosDeJuego : MonoBehaviour
{
    public bool SonidoActivado;

    private void Awake()
    {
        SonidoActivado = true;
    }
   public  void EmpezarPartida()
    {
        SceneManager.LoadScene(1);
    }
    public void SalirDePartida()
    {
        Application.Quit();
    }
    public void ConfiguracionSonido()
    {
        if (SonidoActivado == true)
        {
            SonidoActivado = false;
        }
        else if (SonidoActivado == false)
        {
            SonidoActivado = true;
        }
    }

    public void VolverALaPantallaDeTitulo()
    {
        SceneManager.LoadScene (0);
    }
}
