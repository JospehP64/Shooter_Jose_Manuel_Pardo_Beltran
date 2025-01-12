using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FirstPerson : MonoBehaviour
{
    [SerializeField] GameObject grenade;
    [SerializeField] Transform grenadespawn;
    [SerializeField] GameObject[] armas;
    [SerializeField]Camera MainCamera;//solo es para acortar el Camera.main
    [SerializeField] float playerSpeed;
    [SerializeField] int vida = 3;
    [SerializeField]CharacterController CController;
    [SerializeField] float angleRotation;


    private Transform Interactable;
    [SerializeField] float raycastsyze = 2;


    // Start is called before the first frame update
    void Start()
    {
        armas = GetComponentsInChildren<GameObject>();
        CController = GetComponent<CharacterController>();
        MainCamera = Camera.main;
        armas[0].SetActive(false);
        armas[1].SetActive(false);
        armas[2].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        activarARMA();
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

        //detectarRecolectable();

    }

    void detectarRecolectable()
    {
        if (!Physics.Raycast(MainCamera.transform.position, MainCamera.transform.forward, out RaycastHit hit, raycastsyze))
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
    void activarARMA()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            armas[0].SetActive(true);
            armas[1].SetActive(false);
            armas[2].SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            armas[0].SetActive(false);
            armas[1].SetActive(true);
            armas[2].SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            armas[0].SetActive(false);
            armas[1].SetActive(false);
            armas[2].SetActive(true);
        }
        if (Input.GetMouseButtonDown(0))
        {
            LanzaGranadas();
        }
    }
    //void armaMouse()
    //{
    //    float scrollwheel = Input.GetAxis("Mouse Scrollwheel");
    //        if (scrollwheel > 0)
    //    {
    //        armas[0].SetActive (true);
    //        armas[1].SetActive (false);
    //    }
    //        else if (scrollwheel < 0)
    //    {
    //        armas[0].SetActive(false);
    //        armas[1].SetActive(true);
    //    }
    //}
    void LanzaGranadas()
    {
        Instantiate(grenade, grenadespawn.position, grenadespawn.rotation);

    }

   //void DisparoDeMetralleta()
   //{
   //    if (armas.Length >= 3 && Input.GetMouseButton(0))
   //    {
   //        Physics.Raycast(MainCamera.transform, )
   //    }
}
