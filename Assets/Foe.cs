using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Foe : MonoBehaviour
{
    //[SerializeField] Transform attackPointPosition;
    //[SerializeField] float attackRadius;

    //Foe = Enemigo
    EventosDeJuego GameEvents;
    AudioSource foe_AudioSource;
    Animator animate;
    FirstPerson player;
    NavMeshAgent agent;
    [SerializeField]float vidaEnemigpo = 3;

    public float VidaEnemigpo { get => vidaEnemigpo; set => vidaEnemigpo = value; }

    // Start is called before the first frame update
    void Start()
    {
        GameEvents = FindAnyObjectByType<EventosDeJuego>();
        foe_AudioSource = GetComponent<AudioSource>();
       agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<FirstPerson>();//para que el enemigo persiga a su objetivo
        animate = GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {

        if (GameEvents.SonidoActivado == true)
        {
            foe_AudioSource.enabled = true;
        }
        else
        {
            foe_AudioSource.enabled = false;
        }

        FoeMovement();

       
        
        MuerteENEMIGO();

    }

    private void MuerteENEMIGO()
    {
        Debug.Log("Vida de Enemigo restante: " + vidaEnemigpo);
        if (vidaEnemigpo <= 0)
        {
            
            animate.SetTrigger("morir");
        }
        else
        {

        }
    }

    



    private void FoeMovement()
    {
        if (vidaEnemigpo != 0)
        {
            agent.SetDestination(player.transform.position);
            animate.SetFloat("BlendVelocity", agent.velocity.magnitude / agent.speed);
        }
        else
        {
            agent.enabled = false;
        }
        
    }
    public void OnTriggerEnter(Collider DetectPlayer)
    {
        if (DetectPlayer.gameObject.CompareTag("Player") && vidaEnemigpo != 0)
        {
            animate.SetTrigger("atacar");
           
        }
        else
        {

        }
    }
    
}
