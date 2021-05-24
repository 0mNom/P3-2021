using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hider : MonoBehaviour
{

    public GameObject underSkin, CamMove, CamHidek, CamHidec, CamHide;
    public Material[] material;
    public Renderer rend;

    public Mesh meshNew, MeshOCTO;
    public SkinnedMeshRenderer mRend;

    public string tag;



    public Soundmanager sound;


    public Animator anim, AniTop, AniBottom;
    public bool hid = false; 

    void Start()
    {
      //  rend = GetComponent<Renderer>();
       // rend.enabled = true;
       // rend.sharedMaterial = material[0];
        underSkin.SetActive(false);
        CamMove.SetActive(true);
        CamHidec.SetActive(false);
        CamHidek.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*RaycastHit hitdata; 
         
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out hitdata, 5f);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)*5, Color.green);
       // Debug.Log(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitdata, 5f));

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitdata, 5f))
        {
            if (hitdata.collider.gameObject.GetComponent<Renderer>() == null) rend.material = material[0];
            else
            {
                Material mat = hitdata.collider.gameObject.GetComponent<Renderer>().material;

                rend.material = mat;
               // Debug.Log(mat);
            }

            if (hitdata.collider.gameObject.GetComponent<MeshFilter>() == null)
            {
                mRend.sharedMesh = MeshOCTO;
               
                Debug.Log("nop");
               
            }
            else
            {
                meshNew = hitdata.collider.gameObject.GetComponent<MeshFilter>().mesh;
                underSkin.GetComponent<Transform>().localScale = hitdata.collider.gameObject.GetComponent<Transform>().localScale;
                mRend.sharedMesh = meshNew;
                Debug.Log(meshNew);
            }


        }
        else rend.material = material[0];*/

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 5, Color.green);

        if (Input.GetButtonDown("Fire2K"))
        {
            CamHide = CamHidek;
            hide();
            
            Debug.Log("KeyCAm");
        }
        if (Input.GetButtonDown("Fire2C"))
        {
            CamHide = CamHidec;
            hide();
            
            Debug.Log("ConCAm");
        }
        

    }

    public void hide()
    {
        RaycastHit hitdata;
        Debug.Log("i'm hidinnngggg");
        hid = !hid;
        CamMove.SetActive(false);
        CamHide.SetActive(true);
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitdata, 5f);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 5, Color.green);
        // Debug.Log(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitdata, 5f));

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitdata, 5f))
        {
            if (hitdata.collider.gameObject.GetComponent<Renderer>() == null) rend.material = material[0];
            else
            {
                Material mat = hitdata.collider.gameObject.GetComponent<Renderer>().material;

                rend.material = mat;
                // Debug.Log(mat);
            }

            if (hitdata.collider.gameObject.GetComponent<MeshFilter>() == null)
            {
                mRend.sharedMesh = MeshOCTO;

                Debug.Log("nop");

            }
            else
            {
                meshNew = hitdata.collider.gameObject.GetComponent<MeshFilter>().mesh;
                underSkin.GetComponent<Transform>().localScale = hitdata.collider.gameObject.GetComponent<Transform>().localScale;
                mRend.sharedMesh = meshNew;
                Debug.Log(meshNew);
            }


        }
        else rend.material = material[0];


        if (hid)
        {
            StartCoroutine("hidder");
            anim.SetTrigger("out");
            sound.bobble1();
           
            if (tag == "coral") 
            {
                AniTop.SetTrigger("coral");
                AniBottom.SetTrigger("coral");
            } 
            else
            {
                AniTop.SetTrigger("hide");
                AniBottom.SetTrigger("hide");
            }
         
         
        } else if (!hid)
        {
           
            anim.SetTrigger("in");
            sound.bobble2();
            StartCoroutine("hidden");
            CamMove.SetActive(true);
            CamHide.SetActive(false);
            if (tag == "coral")
            {
                AniTop.SetTrigger("uncoral");
                AniBottom.SetTrigger("uncoral");
            }
            else
            {
                AniTop.SetTrigger("unhide");
                AniBottom.SetTrigger("unhide");
            }
        }
        
    }

    IEnumerator hidden()
    {
        yield return new WaitForSeconds(1f);
        underSkin.SetActive(false);
    }
    IEnumerator hidder()
    {
        yield return new WaitForSeconds(.5f);
        underSkin.SetActive(true);
        if (tag == "coral")
        {
            AniTop.SetTrigger("coral");
            AniBottom.SetTrigger("coral");
        }
        else
        {
            AniTop.SetTrigger("hide");
            AniBottom.SetTrigger("hide");
        }

    }
    
}
