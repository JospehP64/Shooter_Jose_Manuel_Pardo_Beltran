using System.Collections;
using System.Collections.Generic;
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
        Vector2 input = new Vector2(h, v);
        if (input.magnitude > 0)
        {


            //Para mover un objeto con un "Character controller", usa move()
            //Vector3 movement = new Vector3(h, 0, v).normalized;

            angleRotation = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            transform.eulerAngles = new Vector3(0, angleRotation, 0);
            Vector3 movement = Quaternion.Euler(0, angleRotation, 0) * Vector3.forward;
            CController.Move(movement * playerSpeed * Time.deltaTime);
        }
        
    }
}
