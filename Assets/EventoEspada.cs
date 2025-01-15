using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventoEspada : MonoBehaviour
{
    Foe EnemyScript;
    // Start is called before the first frame update
    private void Awake()
    {
        EnemyScript = FindAnyObjectByType<Foe>();  
    }
    public void AtaqueEspadaAEnemigo()
    {
        AnimationEvent AtaqueFisicoDeEspada= new AnimationEvent();
        if (Physics.SphereCast(transform.position, 0.5f, transform.forward, out RaycastHit Attackhit, 0.75f))
        {
            if (Attackhit.transform.gameObject.CompareTag("Player"))
            {
                EnemyScript.VidaEnemigpo--;
            }
        }
}
    }
