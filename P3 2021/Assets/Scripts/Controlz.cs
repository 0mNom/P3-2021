using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controlz : MonoBehaviour
{
    public bool floot;
    public float speed, rotationSpeed;

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

        // Move translation along the object's z-axis
        transform.Translate(0, upDown, translation);

        // Rotate around our y-axis
        transform.Rotate(0, rotation, 0);

        Flotation();

    }

   public void Flotation()
    {
        if (floot) StartCoroutine("flot");
    }


    IEnumerator flot()
    {
        floot = false;
        transform.Translate(new Vector3(0, 1, 0));
        yield return new WaitForSeconds(.5f);
        transform.Translate(new Vector3(0, -1, 0));
        yield return new WaitForSeconds(.5f);
        floot = true;
    }
}
