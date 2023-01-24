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

    IEnumerator Wait(){
        GameObject.Find("RIGHT").GetComponent<BoxCollider>().enabled = false;
        GameObject.Find("LEFT").GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(1f);
        GameObject.Find("RIGHT").GetComponent<BoxCollider>().enabled = true;
        GameObject.Find("LEFT").GetComponent<BoxCollider>().enabled = true;
    }

    IEnumerator Rotatee(){

    

    startingRotation = this.transform.rotation;
    Debug.Log(zRotation());
    Quaternion finalRotation = Quaternion.Euler( 0, 0, zRotation()); //* startingRotation;
    Debug.Log(finalRotation);
    
    while(this.transform.rotation != finalRotation){
        
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, finalRotation, Time.deltaTime*10);
        yield return new WaitForEndOfFrame ();
    }

    }


    IEnumerator Rotater(float time){
        float elapsedTime = 0.0f;
        Quaternion startingRotation = transform.rotation; // have a startingRotation as well
        Quaternion targetRotation =  Quaternion.Euler ( new Vector3 ( 0.0f, 0.0f, zRotation() ) );
        while (elapsedTime < time) {
            elapsedTime += Time.deltaTime; // <- move elapsedTime increment here
            //transform.localPosition = Vector3.Lerp (startingPosition, newLocalTarget, (elapsedTime / time)   );  
            // Rotations
            transform.rotation = Quaternion.Slerp(startingRotation, targetRotation,  (elapsedTime / time)  );
            yield return new WaitForEndOfFrame ();
        }
        

    }

    float timeToRotate = 0.3f;
    public float rotationSpeed = 10f;

    public void turn(int dir){
        StartCoroutine(Wait());
        Debug.Log(transform.rotation.z);
        StartCoroutine(Rotater(.4f));



        // switch(dir){
        //     case 0:
        //         //StartCoroutine(RotateMe(Vector3.forward * 90, timeToRotate));
        //         //StopAllCoroutines();
        //         //
        //         break;
        //     case 1:
        //         //StopAllCoroutines();
        //         //StartCoroutine(Rotatee());
        //         break;
        // }
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

