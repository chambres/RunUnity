using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }



    //transform.RotateAround(objectToOrbit.position, Vector3.left, 20 * Time.deltaTime);

    private Quaternion startingRotation;

    IEnumerator RotateMe(Vector3 byAngles, float inTime) 
     {    
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for(var t = 0f; t < 1; t += Time.deltaTime/inTime) {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            //transform.RotateAround(objectToOrbit.position, byAngles, t);
            yield return null;
        }
         
     }

     

    public float speed = 1f;


    public float zRotation(){
        switch(GameObject.Find("Player").GetComponent<Controller>().pointer){
            case 0:
                return 0;
            case 1:
                return 90;
            case 2:
                return 180;
            case 3:
                return -90;
            default:
                return 0;
        }
    }

    IEnumerator Rotatee(){

    

    startingRotation = this.transform.rotation;

    Quaternion finalRotation = Quaternion.Euler( 0, 0, zRotation()) * startingRotation;
    
    while(this.transform.rotation != finalRotation){
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, finalRotation, Time.deltaTime*15);


        // if(Mathf.Abs(transform.rotation.z - finalRotation.z) < .01f){
        //     Debug.Log("hi");
        //     yield return new WaitForSeconds(1);
        //     GameObject.Find("RIGHT").GetComponent<BoxCollider>().enabled = true;
        //     GameObject.Find("LEFT").GetComponent<BoxCollider>().enabled = true;
        // }
        yield return 0;
    }

    }

    float timeToRotate = 0.3f;
    public float rotationSpeed = 10f;

    public void turn(int dir){
        switch(dir){
            case 0:
                //StartCoroutine(RotateMe(Vector3.forward * 90, timeToRotate));
                //StopAllCoroutines();
                StartCoroutine(Rotatee());
                startingRotation = this.transform.rotation;
                
                Quaternion finalRotation = Quaternion.Euler( 0, 0, zRotation()) * startingRotation;
                this.transform.rotation = finalRotation;
                break;
            case 1:
                //StopAllCoroutines();
                StartCoroutine(Rotatee());
                break;
        }
    }

    void Update () {
        if(Input.GetKeyDown("e")){
            StartCoroutine(RotateMe(Vector3.forward * 90, timeToRotate));
        }
        if(Input.GetKeyDown("q")){
            StartCoroutine(RotateMe(Vector3.forward * -90, timeToRotate));
        }
        
    }
}

