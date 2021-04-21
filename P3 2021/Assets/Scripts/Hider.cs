using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hider : MonoBehaviour
{
    public Material[] material;

    public Renderer rend; 


    void Start()
    {
      //  rend = GetComponent<Renderer>();
       // rend.enabled = true;
        rend.sharedMaterial = material[0]; 
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitdata; 
         
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out hitdata, 5f);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)*5, Color.green);
        Debug.Log(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitdata, 5f));

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitdata, 5f))
        {
            Material mat = hitdata.collider.gameObject.GetComponent<Renderer>().material;
            rend.material = mat;
            Debug.Log(mat);
        }
       
        if(Input.GetButtonDown("Fire2"))
        {
            hide();
        }
        

    }

    public void hide()
    {
        Debug.Log("i'm hidinnngggg");
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.TransformDirection(Vector3.forward));
    }*/



    /*
     void OnCollisionEnter(Collision col)
    {
      if (col.gameObject.tag == "1")
        {
            //rend = this.GetComponent<Renderer>();
            Debug.Log("grennn");
            rend.sharedMaterial = material[1];
        }
        if (col.gameObject.tag == "2")
        {
            //rend = this.GetComponent<Renderer>();
            Debug.Log("grennn");
            rend.sharedMaterial = material[2];
        }
    }*/
}
