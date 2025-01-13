using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explotion : MonoBehaviour
{
    Foe EnemyToExplode;
    Corrutina CorrutinaEnemigo;
    // Start is called before the first frame update
    void Start()
    {
        EnemyToExplode = FindObjectOfType<Foe>(); 
        CorrutinaEnemigo = FindObjectOfType<Corrutina>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider ExplodeEnemy)
    {
        if (ExplodeEnemy.gameObject.CompareTag("Enemy"))
        {
            if (ExplodeEnemy.TryGetComponent<Foe> (out EnemyToExplode))
            {
                EnemyToExplode.VidaEnemigpo = 0;
                CorrutinaEnemigo.EnemyCount--;
                Destroy(gameObject, 0.3f);
            }
            
            
            
            
        }
    }
}
