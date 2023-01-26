using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialMovement : MonoBehaviour
{
    float speed = 10.1f;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -10);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector3.forward * Time.deltaTime * speed);
    }
}
