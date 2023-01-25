using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -10);
        
    }
    void IgnoreCollisions(){
        foreach(GameObject fooObj in GameObject.FindGameObjectsWithTag("box"))
        {
            Physics.IgnoreCollision(fooObj.GetComponent<BoxCollider>(), GetComponent<BoxCollider>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        //IgnoreCollisions();
    }
}
