using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject octo1, octo2;
    public RectTransform avatar, con, concon;
    void Start()
    {
        avatar.DOMove(new Vector3(950, 525, 0), 1f);
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

    public void Resetter()
    {
        
    }
    public void Aout()
    {
        avatar.DOMove(new Vector3(4920, 1077, 0), 1f);
        con.DOMove(new Vector3(950, 525, 0), 1f);
    }
public void conOUT()
    {
        concon.DOMove(new Vector3(1920, 4077, 0), 1f);
    }


    public void bye()
    {
        Application.Quit();
    }
}
