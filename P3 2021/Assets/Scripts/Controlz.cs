using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controlz : MonoBehaviour
{
    public bool floot;
    public float speed, rotationSpeed;
    public Rigidbody rb;
    public bool wave, WAVING, run;
    private Vector3 velocity = new Vector3(1, 0, 1);

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        rotationSpeed = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        float upDown = Input.GetAxis("upDown") * speed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        upDown *= Time.deltaTime;

        Vector3 m_Input = new Vector3 (0,upDown,translation);


        //animation

        if (translation == 0 && upDown != 0)
        {
            anim.SetBool("idle", false);
            anim.SetBool("swim", false);
            anim.SetBool("puff", true);
        }
        if (translation == 0 && upDown == 0) 
        {
            if (anim.GetBool("idle") == true)
            {
                anim.SetBool("swim", false);
                anim.SetBool("puff", false);
            }
            else
            {
                anim.SetBool("idle", true);
                Debug.Log("stilling");
            }
            anim.SetBool("swim", false);
            anim.SetBool("puff", false);

        }
        if (translation != 0) { anim.SetBool("idle", false); anim.SetBool("swim", true); anim.SetBool("puff", false); }

        // Move translation
        transform.Translate(0, upDown, translation);
      //  rb.MovePosition(transform.position + m_Input * Time.deltaTime * speed);

        // Rotate around our y-axis
        transform.Rotate(0, rotation, 0);


        if (WAVING)
        {
            Vector3 NEW = transform.position + new Vector3(1, 0, 1);
            if (wave)
            {

                gameObject.transform.position = Vector3.SmoothDamp(transform.position, NEW, ref velocity, 2f);
                Debug.Log("Going");
            }
            else
            {
                NEW = transform.position + new Vector3(-1, 0, -1);
                gameObject.transform.position = Vector3.SmoothDamp(transform.position, NEW, ref velocity, 2f);
            }
        }

        if (!run) StartCoroutine("waving");




        Flotation();

    }

   public void Flotation()
    {
        if (floot) StartCoroutine("flot");
    }


    IEnumerator flot()
    {
        floot = false;
        transform.Translate(new Vector3(0, .1f, 0));
        yield return new WaitForSeconds(.1f);
        transform.Translate(new Vector3(0, .1f, 0));
        yield return new WaitForSeconds(.1f);
        transform.Translate(new Vector3(0, .1f, 0));
        yield return new WaitForSeconds(.1f);
        transform.Translate(new Vector3(0, .1f, 0));
        yield return new WaitForSeconds(.1f);
        transform.Translate(new Vector3(0, .1f, 0));
        yield return new WaitForSeconds(.1f);
        transform.Translate(new Vector3(0, -.1f, 0));
        yield return new WaitForSeconds(.1f);
        transform.Translate(new Vector3(0, -.1f, 0));
        yield return new WaitForSeconds(.1f);
        transform.Translate(new Vector3(0, -.1f, 0));
        yield return new WaitForSeconds(.1f);
        transform.Translate(new Vector3(0, -.1f, 0));
        yield return new WaitForSeconds(.1f);
        transform.Translate(new Vector3(0, -.1f, 0));
        yield return new WaitForSeconds(.1f);
        
        floot = true;
    }

    IEnumerator waving()
    {
        run = true;
        yield return new WaitForSeconds(15f);
        WAVING = true;
        StartCoroutine("wavee");
        run = false;

    }

    IEnumerator wavee()
    {

        yield return new WaitForSeconds(3f);
        wave = true;
        yield return new WaitForSeconds(3f);
        wave = false;

        WAVING = false;


    }
}
