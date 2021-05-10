using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controlz : MonoBehaviour
{
    public bool floot;
    public float speed, rotationSpeed;
    public Rigidbody rb;

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



        // Move translation along the object's z-axis
        transform.Translate(0, upDown, translation);
        //rb.MovePosition(transform.position + m_Input * Time.deltaTime * speed);

        // Rotate around our y-axis
        transform.Rotate(0, rotation, 0);
        //rb.MoveRotation(0, rotation, 0);

       // Flotation();

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
}
