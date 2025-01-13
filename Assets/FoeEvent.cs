using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FoeEvent : MonoBehaviour
{
    GameObject TargetPlayer;
    // Start is called before the first frame update
    private void Awake()
    {
        TargetPlayer = GameObject.FindGameObjectWithTag("Player");

    }
    void Start()
    {
        
    }

    private void Update()
    {
        
    }
    public void AtaqueAJugador()
    {
        AnimationEvent AtaqueEnemigo = new AnimationEvent();
        if (Physics.SphereCast(transform.position, 0.5f, transform.forward, out RaycastHit Attackhit, 0.75f))
        {
            if (Attackhit.transform.gameObject.CompareTag("Player"))
            {
                Attackhit.collider.GetComponent<FirstPerson>().RecibirAtaque();
            }
        }
        
    }
}