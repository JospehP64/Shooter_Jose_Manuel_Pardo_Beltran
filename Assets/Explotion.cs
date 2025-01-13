using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explotion : MonoBehaviour
{
    Corrutina CorrutinaEnemigo;
    // Start is called before the first frame update
    void Start()
    {
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
            Destroy(ExplodeEnemy.gameObject);
            CorrutinaEnemigo.EnemyCount--;
        }
    }
}
