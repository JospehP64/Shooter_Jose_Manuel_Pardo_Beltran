using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public Animator swordAnimator;
    // Start is called before the first frame update
    void Start()
    {
        swordAnimator = GetComponent<Animator>();
    }

    public void UsarEspada()
    {
        swordAnimator.SetTrigger("swordattack");
    }
}
