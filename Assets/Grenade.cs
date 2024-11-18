using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] GameObject explotion;
    [SerializeField] float grenadeLifeTime;
    [SerializeField] Transform Gundirecction;
    float explotionRadius = 5;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce (transform.forward.normalized * 5, ForceMode.Impulse);
        Destroy (gameObject, grenadeLifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        Instantiate(explotion, transform.position, Quaternion.identity);
        Collider[] ColliderDetected = Physics.OverlapSphere(transform.position, explotionRadius);
        Debug.Log("¡Ha explotado esta granada!");
        if (ColliderDetected.Length > 0)
        {

        }
        foreach (Collider coll in ColliderDetected)
        {
            //coll.GetComponent<EnemyPart>().Explode(); //deshabilita el movimiento de los enemigos impactados
            coll.GetComponent<Rigidbody>().AddExplosionForce(50,transform.position, explotionRadius, 5, ForceMode.Impulse);//fuerza y radio de la explosion
            //coll.GetComponent<Rigidbody>().isKinematic = false; //dejas los huesos del enemigo den dinámico. RECUERDA USAR RAGDOLL EN LOS ENEMIGOS

        }
    }
}
