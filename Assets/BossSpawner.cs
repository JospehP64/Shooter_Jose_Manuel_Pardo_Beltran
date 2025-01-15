using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    Corrutina CorrutinaEnemigo;
     [SerializeField]GameObject BossToSpawn;
    [SerializeField]bool BossSpawned = false;
    // Start is called before the first frame update

    private void Start()
    {
        CorrutinaEnemigo = FindAnyObjectByType<Corrutina>();
        StartCoroutine(BossCoorutine());
    }
    private void Update()
    {
        
        InvocarBoss();
    }
    void InvocarBoss()
    {
        if (CorrutinaEnemigo.rondas >= 4)
        {
            BossSpawned = true;

        }
        else
        {

        }
        
    }
    IEnumerator BossCoorutine()
    {
        while (BossSpawned == true)
        {
            Instantiate(BossToSpawn, transform.position, Quaternion.identity);
            
            yield return new WaitForSeconds(3);
            BossSpawned = false;
            StopCoroutine(BossCoorutine());
        }
        
    }

}
