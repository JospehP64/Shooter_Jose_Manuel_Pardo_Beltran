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
    // Start is called before the first frame update
    void Start()
    {

       agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<FirstPerson>();//para que el enemigo persiga a su objetivo
        
        
        
    }

    // Update is called once per frame
    void Update()
    {

        

       // FoeAttack();
        agent.destination = player.transform.position;
        

    }

    private void FoeAttack()
    {
        if (agent.pathPending == false && agent.remainingDistance <= agent.stoppingDistance)//tambien puedes usar !agent.pathPending (recuerda que ! es para negar)
        {
            agent.isStopped = true;
            animate.SetBool("atacar", true);

        }
    }
}
