using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FirstPerson : MonoBehaviour
{
    
    Camera MainCamera;//solo es para acortar el Camera.main
    [SerializeField]float playerSpeed;
    [SerializeField] int vida = 3;
    CharacterController CController;
    [SerializeField] float angleRotation;
    
    
    private Transform Interactable;
    [SerializeField]float raycastsyze = 2;
    

    // Start is called before the first frame update
    void Start()
    {
       CController = GetComponent<CharacterController>();
        MainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 input = new Vector2(h, v);
        if (input.sqrMagnitude > 0)
        {


            //Para mover un objeto con un "Character controller", usa move()
            //Vector3 movement = new Vector3(h, 0, v).normalized;

            angleRotation = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            transform.eulerAngles = new Vector3(0, angleRotation, 0);
            Vector3 movement = Quaternion.Euler(0, angleRotation, 0) * Vector3.forward;
            CController.Move(movement * playerSpeed * Time.deltaTime);


        }

        detectarRecolectable();
        
    }
    void detectarRecolectable()
    {
        if (Physics.Raycast(MainCamera.transform.position, MainCamera.transform.forward, out RaycastHit hit, raycastsyze))
        {
            if (hit.transform.TryGetComponent(out AmmoBox MunitionBox))
            {
                Interactable = hit.transform;
                Interactable.GetComponent<Outline>().enabled = true;
                if (Input.GetKeyDown(KeyCode.E))//para activar la animacion de abrir la caja
                {
                    MunitionBox.abrir();
                }
            }
        }
        else if (Interactable)
        {
            Interactable.GetComponent<Outline>().enabled = false;
            Interactable = null;
                    
        }
    }
}
