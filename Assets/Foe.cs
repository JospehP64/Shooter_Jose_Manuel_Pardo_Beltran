using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Foe : MonoBehaviour
{

    //Foe = Enemigo
    FirstPerson Firstplayer;
    [SerializeField]GameObject player;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {

       agent = GetComponent<NavMeshAgent>();
        //player = GameObject.FindObjectOfType<FirstPerson>();//para que el enemigo persiga a su objetivo
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }
}
