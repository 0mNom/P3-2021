using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Seeker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cam, otherOcto, otherOctoCam, otherOctoCam2;
    public SkinnedMeshRenderer Skin;
    public MeshRenderer Hat;
    public Outline outt;
    public Mesh OCTOMESH;
    public Image found;

    void Start()
    {
        
       // StartCoroutine("find");
        Skin.enabled = false;
        Hat.enabled = false;
        //gameObject.SetActive(false);
        cam.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {


        RaycastHit hitdata;

        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitdata, 5f);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 5, Color.green);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitdata, 5f))
        {
            if (hitdata.collider.gameObject.GetComponentInChildren<Outline>() == null) return;
            else
            {
                if ((hitdata.collider.gameObject.tag == "Hider")) 
                {

                    outt = hitdata.collider.gameObject.GetComponentInChildren<Outline>();
                    outt.enabled = true;
                    Debug.Log("found you");
                    // hitdata.collider.gameObject.GetComponent<SkinnedMeshRenderer>().sharedMesh = OCTOMESH;
                    found.rectTransform.DOMove(new Vector3(950, 500, 0), 2f);
                }

                

            }


        }
        
    }

    public void finding()
    {
        Skin.enabled = true;
        Hat.enabled = true;
        // gameObject.SetActive(true);
        cam.SetActive(true);
        // otherOcto.SetActive(false);
        //otherOcto.GetComponent<Hider>().enabled = false ;
        otherOcto.GetComponent<Controlz>().enabled = false;
        otherOctoCam.SetActive(false);
        otherOctoCam2.SetActive(false);
        Debug.Log("im coming to find youuuuu");
    }


    IEnumerator find()
    {
        Debug.Log("imma get you soon");
        yield return new WaitForSeconds(15f);
        Skin.enabled = true;
        Hat.enabled = true;
       // gameObject.SetActive(true);
        cam.SetActive(true);
        // otherOcto.SetActive(false);
        otherOcto.GetComponent<Hider>().enabled = false ;
        otherOcto.GetComponent<Controlz>().enabled = false ;
        otherOctoCam.SetActive(false);
        otherOctoCam2.SetActive(false);
        Debug.Log("im coming to find youuuuu");


        

    }
}
