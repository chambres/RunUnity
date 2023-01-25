using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxConstructor : MonoBehaviour
{

    
    public GameObject plane1;
    public GameObject plane2;
    public GameObject plane3;
    public GameObject plane4;

    // Start is called before the first frame update
    void Start()
    {
        plane1 = transform.GetChild(0).gameObject;
        plane2 = transform.GetChild(1).gameObject;
        plane3 = transform.GetChild(2).gameObject;
        plane4 = transform.GetChild(3).gameObject;

        Destroy(plane1.transform.GetChild(Random.Range(0, 9)).gameObject);        
        Destroy(plane2.transform.GetChild(Random.Range(0, 9)).gameObject);
        Destroy(plane3.transform.GetChild(Random.Range(0, 9)).gameObject);
        Destroy(plane4.transform.GetChild(Random.Range(0, 9)).gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

