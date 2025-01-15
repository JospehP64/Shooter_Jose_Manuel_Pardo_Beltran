using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnimateScript : MonoBehaviour
{
    Animator GunAnimator;
    // Start is called before the first frame update
    void Start()
    {
        GunAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Disparar()
    {
        GunAnimator.SetTrigger("Disparar_arma");
    }
    public void Recargar()
    {
        GunAnimator.SetTrigger("Cargar_arma");
    }
}