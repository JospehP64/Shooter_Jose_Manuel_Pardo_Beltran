using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ThirdPerson : MonoBehaviour
{
    Camera MainCamera;//solo es para acortar el Camera.main
    [SerializeField] float playerSpeed;
    [SerializeField] int vida = 3;
    CharacterController CController;
    [SerializeField] float angleRotation;
     [SerializeField] float SmoothingTime;
    [SerializeField] float RotationSpeed;
    Animator anima;

    // Start is called before the first frame update
    void Start()
    {
        CController = GetComponent<CharacterController>();
        anima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h, v;
        NewMethod(out h, out v);

        Vector2 input = new Vector2(h, v);
        if (input.sqrMagnitude > 0)
        {


            //Para mover un objeto con un "Character controller", usa move()
            //Vector3 movement = new Vector3(h, 0, v).normalized;

            angleRotation = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            float SmoothedAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angleRotation, ref RotationSpeed, SmoothingTime);
            transform.eulerAngles = new Vector3(0, angleRotation, 0);
            Vector3 movement = Quaternion.Euler(0, angleRotation, 0) * Vector3.forward;
            CController.Move(movement * playerSpeed * Time.deltaTime);
        }

    }

    private void NewMethod(out float h, out float v)
    {
        Cursor.lockState = CursorLockMode.Locked;
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
         
        anima.SetBool("BoolWalking", true);
    }
}
