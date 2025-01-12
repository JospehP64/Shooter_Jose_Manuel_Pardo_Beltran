using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MONSTRUO : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField]Transform player;
    // Start is called before the first frame update
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.position;
        agent.SetDestination(player.transform.position);
    }
}
