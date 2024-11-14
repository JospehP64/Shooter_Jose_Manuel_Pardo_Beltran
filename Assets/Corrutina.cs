using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corrutina : MonoBehaviour
{
    //LO QUE HACE ESTE SCRIPT ES CREAR UN "SPAWNER" (UNA RUTINA DE SPAWN O "APARICION) PARA LOS ENEMIGOS, TOMANDO LOS SIGUIENTES DATOS
    
    bool spawnerAtivado;//PARA ACTIVAR EL SPAWN AL ACTIVAR EL JUEGO (juegoiniciado)
    bool JuegoIniciado;//PARA INDICAR QUE EL JUEGO ESTA ACTIVADO
    [SerializeField]Transform[] spawnpoints;
    [SerializeField] Foe foewspawn;
    // Start is called before the first frame update
    void Start()
    {
        //quaternion.identity quiere decir "rotación" 0,0,0 (en matemáticas, "matriz" e "identidad" ("coordenadas" = "¿posicion?")
        StartCoroutine(semaforo());//IMPORTANTE: SE DEBE USAR STARTCOROUTINE EN START, NO EN UPDATE SOLO Y SIEMPRE QUE SE USE UN METODO IENUMERATOR
        Instantiate(foewspawn, spawnpoints[Random.Range(0, 2)].position, Quaternion.identity);//con random range puedes crear probabilidades de que se genere un nuevo enemigo en un lugar aleatorio
        
    }

    // Update is called once per frame
    void Update()
    {
        if (JuegoIniciado == true)
        {
            spawnerAtivado = true;
        }
        
    }
    IEnumerator semaforo()
    {
        while (spawnerAtivado == true)
        {
            yield return new WaitForSeconds(2);//tiempo a esperar, como "wait" en rpg maker
        }
        
    }
}
