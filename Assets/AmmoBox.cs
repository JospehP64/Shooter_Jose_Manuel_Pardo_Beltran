using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    [SerializeField]Animator animate;
    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void abrir ()//para activar la animacion de abrir la caja
    {
        animate.SetTrigger("OpenTrigger");
    }
}
