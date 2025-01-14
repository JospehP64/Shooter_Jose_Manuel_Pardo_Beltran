using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventosDeJuego : MonoBehaviour
{
    public bool SonidoActivado;

    private void Awake()
    {
        SonidoActivado = true;
    }
    void EmpezarPartida()
    {

    }
    void SalirDePartida()
    {

    }
    void ConfiguracionSonido()
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
}
