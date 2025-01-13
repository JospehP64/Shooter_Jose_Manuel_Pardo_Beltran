using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Foe : MonoBehaviour
{
    //[SerializeField] Transform attackPointPosition;
    //[SerializeField] float attackRadius;
    
    //Foe = Enemigo
    Animator animate;
    FirstPerson player;
    NavMeshAgent agent;
    [SerializeField]float vidaEnemigpo = 3;

    public float VidaEnemigpo { get => vidaEnemigpo; set => vidaEnemigpo = value; }

    // Start is called before the first frame update
    void Start()
    {

       agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<FirstPerson>();//para que el enemigo persiga a su objetivo
        animate = GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {



        FoeMovement();

       
        
        MuerteENEMIGO();

    }

    private void MuerteENEMIGO()
    {
        Debug.Log("Vida de Enemigo restante: " + vidaEnemigpo);
        if (vidaEnemigpo <= 0)
        {
            Destroy(gameObject);
        }
        else
        {

        }
    }

   

    private void FoeMovement()
    {
        agent.SetDestination(player.transform.position);
        animate.SetFloat("BlendVelocity", agent.velocity.magnitude / agent.speed);
    }
    public void OnTriggerEnter(Collider DetectPlayer)
    {
        if (DetectPlayer.gameObject.CompareTag("Player"))
        {
            animate.SetTrigger("atacar");
           
        }
        else
        {

        }
    }
    
}
