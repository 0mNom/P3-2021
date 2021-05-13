using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundmanager : MonoBehaviour 
{

    public AudioClip bubble1, bubble2;
    public AudioSource ear;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void bobble1()
    {
        ear.PlayOneShot(bubble1);
    }
    
    public void bobble2()
    {
        ear.PlayOneShot(bubble2);
    }
}
