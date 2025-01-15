using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject CanvasPausa;
    public bool TimeIsStopped = false;
    // Start is called before the first frame update
    void Start()
    {
        TimeIsStopped = false;
        Time.timeScale = 1.0f;
        CanvasPausa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        StopTimeEscape();
    }

    public void StopTime()
    {
        if ( TimeIsStopped == false)
        {
            Time.timeScale = 0;
            CanvasPausa.SetActive(true);
            TimeIsStopped = true;
        }
        else if (TimeIsStopped == true)
        {
            CanvasPausa.SetActive(false);
            Time.timeScale = 1.0f;
            TimeIsStopped = false;
        }
    } public void StopTimeEscape()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && TimeIsStopped == false)
        {
            Time.timeScale = 0;
            CanvasPausa.SetActive(true);
            TimeIsStopped = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && TimeIsStopped == true)
        {
            CanvasPausa.SetActive(false);
            Time.timeScale = 1.0f;
            TimeIsStopped = false;
        }
    }
}
