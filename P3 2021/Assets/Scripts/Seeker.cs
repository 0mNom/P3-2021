using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cam;
    void Start()
    {
        gameObject.SetActive(false);
        cam.SetActive(false);
        StartCoroutine("find");

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator find()
    {
        yield return new WaitForSeconds(30f);
        gameObject.SetActive(true);
        cam.SetActive(true);

    }
}
