using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Hider : MonoBehaviour
{

    public GameObject underSkin, undersphere, hat, CamMove, CamHidek, CamHidec, CamHide;
    public Material[] material;
    public Renderer rend;
   public Outline oldout;

    public Mesh meshNew, MeshOCTO;
    public SkinnedMeshRenderer mRend;

    public string tag;

    public RectTransform timerr;



    public Soundmanager sound;


    public Animator anim, AniTop, AniBottom;
    public bool hid = false;

    public HealthBarJuice bar;

    void Start()
    {
        gameObject.SetActive(true);
      //  rend = GetComponent<Renderer>();
       // rend.enabled = true;
       // rend.sharedMaterial = material[0];
        underSkin.SetActive(false);
        CamMove.SetActive(true);
        CamHidec.SetActive(false);
        CamHidek.SetActive(false);
        StartCoroutine("timer");
        bar.StartJuice();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitdata;

        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitdata, 5f);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 5, Color.green);
        // Debug.Log(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitdata, 5f));

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitdata, 5f))
        {
            if (hitdata.collider.gameObject.GetComponent<Outline>() == null) oldout.enabled= false;
            else
            {
                oldout.enabled = false;
                oldout = hitdata.collider.gameObject.GetComponent<Outline>();
                oldout.enabled = true;
               
            }


            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 5, Color.green);

            


        }
        else oldout.enabled = false;
        if (Input.GetButtonDown("Fire2K"))
        {
            CamHide = CamHidek;
            hide();

           // Debug.Log("KeyCAm");
        }
        if (Input.GetButtonDown("Fire2C"))
        {
            CamHide = CamHidec;
            hide();

           // Debug.Log("ConCAm");
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

            if (hitdata.collider.gameObject == null)
            {
                mRend.sharedMesh = MeshOCTO;
                //underSkin.GetComponent<Transform>().localScale = Vector3.zero;

                //Debug.Log("nop");

            }
            else
            {

                //underSkin.GetComponent<Transform>().localScale=Vector3.zero;
                meshNew = hitdata.collider.gameObject.GetComponent<MeshFilter>().mesh;
                //underSkin.GetComponent<Transform>().DOScale(hitdata.collider.gameObject.GetComponent<Transform>().localScale, 1f);
               // mRend.sharedMesh = meshNew;
               // Debug.Log(meshNew);
            }


        }
        else rend.material = material[0];


        if (hid)
        {
           // StartCoroutine("hidder");
            anim.SetTrigger("out");
            sound.bobble1();
            underSkin.SetActive(true);
            hat.GetComponent<Transform>().DOScale(Vector3.zero, 1f);
            underSkin.GetComponent<Transform>().DOScale(hitdata.collider.gameObject.GetComponent<Transform>().localScale, 1f);
            mRend.sharedMesh = meshNew;
            undersphere.GetComponent<MeshCollider>().sharedMesh = null;
            undersphere.GetComponent<MeshCollider>().sharedMesh = meshNew;
            




        } else if (!hid)
        {
           
            anim.SetTrigger("in");
            sound.bobble2();
            hat.GetComponent<Transform>().DOScale(new Vector3(100,100,100), 1f);
            underSkin.GetComponent<Transform>().DOScale(Vector3.zero, 1f);
            //underSkin.SetActive(false);
            StartCoroutine("hidden");
            CamMove.SetActive(true);
            CamHide.SetActive(false);
            
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
        

    }
    
    IEnumerator timer()
    {
        yield return new WaitForSeconds(20f);
        timerr.DOScale(0, 2f);
       
       
        

    }
    
}
