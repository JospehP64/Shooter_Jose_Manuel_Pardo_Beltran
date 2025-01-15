using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunSpark : MonoBehaviour
{
    [SerializeField]GameObject ParticulaAInvocar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InvocarParticula()
    {
        Instantiate(ParticulaAInvocar, transform.position, Quaternion.identity);
    }
}
