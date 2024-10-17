using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    [SerializeField]float playerSpeed;
    [SerializeField] int vida = 3;
    CharacterController CController;
    [SerializeField] float angleRotation;
    

    // Start is called before the first frame update
    void Start()
    {
       CController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
       // Vector2 input = new Vector2(h, v) * Mathf.Rad2Deg; CORREGIR
        //if (input.magnitude > 0) CORREGIR
        {


            //Para mover un objeto con un "Character controller", usa move()
            //Vector3 movement = new Vector3(h, 0, v).normalized;

          //  angleRotation = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y; CORREGIR
          //  transform.eulerAngles = new Vector3(0, angleRotation, 0); CORREGIR
          //  Vector3 movement = quaternion.Euler(0, angleRotation, 0) * Vector3.forward; CORREGIR
            //CController.Move(movement * playerSpeed * Time.deltaTime); CORREGIR
        }
        
    }
}
