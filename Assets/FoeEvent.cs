using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FoeEvent : MonoBehaviour
{
    GameObject TargetPlayer;
    Corrutina CorrutinaEnemigo;
    int dropRandomizer;
    [SerializeField]GameObject ItemToDrop;
    // Start is called before the first frame update
    private void Awake()
    {
        TargetPlayer = GameObject.FindGameObjectWithTag("Player");
        CorrutinaEnemigo = FindObjectOfType<Corrutina>();
    }
    void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void MuerteDeEnemigo()
    {
        AnimationEvent MuerteDeEnemigo = new AnimationEvent();
        CorrutinaEnemigo.EnemyCount--;
        CorrutinaEnemigo.enemyDefeated++;

        dropRandomizer = Random.Range(0, 2);
        if (dropRandomizer >= 1)
        {

        }
        else if (dropRandomizer <= 0)
        {
            Instantiate(ItemToDrop, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
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
