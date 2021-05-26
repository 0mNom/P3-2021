using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject octo1, octo2;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void oct1()
    {
        octo1.tag = "Hider";
        octo2.tag = "Seeker";

    }

    public void oct2()
    {
        octo2.tag = "Hider";
        octo1.tag = "Seeker";
    }

    public void bye()
    {
        Application.Quit();
    }
}
