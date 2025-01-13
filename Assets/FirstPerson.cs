using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FirstPerson : MonoBehaviour
{
    Foe Enemy;
    [SerializeField] GameObject grenade;
    [SerializeField] Transform grenadespawn;
    [SerializeField] GameObject[] armas;
    [SerializeField]Camera MainCamera;//solo es para acortar el Camera.main
    [SerializeField] float playerSpeed;
    [SerializeField] int vida = 3;
    [SerializeField]CharacterController CController;
    float playergravity = -9.81f;
    [SerializeField]float _gravity_velocity;
    [SerializeField]float gravityMultiplier = 3;
    float h, v;
    AmmoBox AmmoboxObject;
    RaycastHit hit;
    Vector3 movement;



    private Transform Interactable;
    [SerializeField] float raycastsyze = 2;

    public CharacterController CController1 { get => CController; set => CController = value; }


    // Start is called before the first frame update
    void Start()
    {
        Enemy = FindObjectOfType<Foe>();
        AmmoboxObject = FindObjectOfType<AmmoBox>();
        
        CController = GetComponent<CharacterController>();
        MainCamera = Camera.main;
        armas[0].SetActive(false);
        armas[1].SetActive(false);
        armas[2].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log("Vida restante: " + vida);
        activarARMA();
        Movimiento();
        detectarRecolectable();
        GravedadDelJugador();

    }

    private void GravedadDelJugador()
    {
        //_gravity_velocity += playergravity * gravityMultiplier * Time.deltaTime;
        //movement.y = _gravity_velocity;
    }

    private void Movimiento()
    {
        Cursor.lockState = CursorLockMode.Locked;
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        Vector2 input = new Vector2(h, v).normalized;
        float angleRotation = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + MainCamera.transform.eulerAngles.y;

        if (input.sqrMagnitude > 0)
        {

            transform.eulerAngles = new Vector3(0, MainCamera.transform.eulerAngles.y, 0);

            //Para mover un objeto con un "Character controller", usa move()

            movement = Quaternion.Euler(0, angleRotation, 0) * Vector3.forward;


        }
        CController.Move(input.magnitude * movement * 3 * Time.deltaTime);
    }

    void detectarRecolectable()
    {
        if (Physics.Raycast(MainCamera.transform.position, MainCamera.transform.forward, out  hit, raycastsyze))
        {
            if (hit.transform.TryGetComponent<AmmoBox>(out AmmoboxObject))
            {
                Interactable = hit.transform;
                Interactable.GetComponent<Outline>().enabled = true;
                if (Input.GetKeyDown(KeyCode.E))//para activar la animacion de abrir la caja
                {
                    AmmoboxObject.abrir();
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
        
        else if (Input.GetKeyDown(KeyCode.F))
        {
            armas[0].SetActive(false);
            armas[1].SetActive(false);
            armas[2].SetActive(false);
        }
        else
        {

        }

        if (armas[0].activeSelf)
        {
            if (Input.GetMouseButtonDown(0))
            {
                LanzaGranadas();
            }

        }
        else if (armas[1].activeSelf)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(MainCamera.transform.position, transform.forward, out hit, raycastsyze ))
                {
                    if (hit.transform.TryGetComponent<Foe>(out Enemy))
                    {
                        if (hit.transform.CompareTag("Enemy"))
                        {
                            Enemy.VidaEnemigpo--;
                            Debug.Log("has disparado a un enemigo");
                        }
                    }
                    else
                    {

                    }
                    
                }
            }
        }
        else if (armas[2].activeSelf)
        {

        }
        else
        {

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
   public void RecibirAtaque()
    {

        
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            vida--;
            Debug.Log("¡has recibido daño!");
            Debug.Log("Te quedan: " + vida);
        }

    }
}
