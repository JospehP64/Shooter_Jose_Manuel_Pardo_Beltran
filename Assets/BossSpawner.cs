using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    Corrutina CorrutinaEnemigo;
     [SerializeField]GameObject BossToSpawn;
    bool BossSpawned = false;
    // Start is called before the first frame update
    private void Update()
    {
        InvocarBoss();
    }
    void InvocarBoss()
    {
        if (CorrutinaEnemigo.rondas >= 4 && BossSpawned == false)
        {
            Instantiate(BossToSpawn, transform.position, Quaternion.identity);
            BossSpawned = true;

        }
        else
        {

        }
    }

}
