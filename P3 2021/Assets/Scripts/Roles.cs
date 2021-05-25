using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roles : MonoBehaviour
{
    public string tagg;
    public Hider hide;
    public Seeker seek;
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void roleUp()
    {
        tagg = gameObject.tag;
        Debug.Log(tagg);
        if (tagg == "Hider") hide.enabled = true;
        if (tagg == "Seeker") seek.enabled = true;
    }
}
