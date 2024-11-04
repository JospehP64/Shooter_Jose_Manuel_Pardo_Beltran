using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Foe : MonoBehaviour
{
    [SerializeField] Transform attackPointPosition;
    [SerializeField] float attackRadius;

    //Foe = Enemigo
    Animator animate;
    FirstPerson Firstplayer;
    [SerializeField]GameObject player;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {

       agent = GetComponent<NavMeshAgent>();
        //player = GameObject.FindObjectOfType<FirstPerson>();//para que el enemigo persiga a su objetivo
        animate = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);

        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.isStopped = true;
            animate.SetBool("atacar", true);

        }
        [SerializeField]void AttackAnimationEnd()
        {

        }
        [SerializeField] void AttackWindowEnd()
        {

        }
        [SerializeField] void AttackWindowStart()
        {
            Physics.OverlapSphere(attackPointPosition.position, attackRadius);
        }
        
    }
}
