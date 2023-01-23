using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controller : MonoBehaviour
{
    enum Direction {North, East, South, West};

    
    List<Vector3> list;

    Vector3 downG = new Vector3(0, -9.81f, 0);
    Vector3 upG = new Vector3(0, 9.81f, 0);
    Vector3 leftG = new Vector3(-9.81f, 0, 0);
    Vector3 rightG = new Vector3(9.81f, 0, 0);

    [SerializeField]
    public int pointer = 0;

    Rigidbody rb;

    Vector3 getNext(){
        switch(pointer){
            case 0:
                pointer=1;
                return rightG;
            case 1:
                pointer=2;
                return upG;
            case 2:
                pointer=3;
                return leftG;
            case 3:
                pointer = 0;
                return downG;
            default:
                return new Vector3(0, 0, 0);
        }
    }
    Vector3 getPrev(){
        switch(pointer){
            case 0:
                pointer = 3;
                return leftG;
            case 1:
                pointer=0;
                return downG;
            case 2:
                pointer=1;
                return rightG;
            case 3:
                pointer=2;
                return upG;
            default:
                return new Vector3(0, 0, 0);
        }
    }

    void force(float dir){
        rb.AddForce(GameObject.Find("Main Camera").transform.right * dir, ForceMode.Impulse);
        Debug.Log(GameObject.Find("Main Camera").transform.right);
        Debug.Log(dir);

        Debug.Log("added");
    }

    void Start () 
    {
        rb = GetComponent<Rigidbody>();
        list = new List<Vector3> { downG, rightG, upG, leftG };
        Direction myDirection;
        myDirection = Direction.North;

        force(-1f);
    }    





    float moveSpeed = 10f;




     private void FixedUpdate() {
        if(Input.GetKey(KeyCode.A)){
           rb.velocity += (-GameObject.Find("Main Camera").transform.right) * 1f;
        }
        if(Input.GetKey(KeyCode.D)){
           rb.velocity += (GameObject.Find("Main Camera").transform.right) * 1f;
        }

        
        if(Input.GetKey(KeyCode.L)){
            Physics.gravity = getNext();
        }
        if(Input.GetKey(KeyCode.J)){
            Physics.gravity = getPrev();
        }   




       //assuming we're only using the single camera:
            var camera = Camera.main;
            //Debug.Log(camera.left);
           
        //Data recieved from CrossPlatformInput Handler:
            float horizontalAxis = Input.GetAxis("Horizontal");
            float verticalAxis = Input.GetAxis("Vertical");
               
            

     }

     private void OnCollisionEnter(Collision other) {
        if(other.gameObject.name == "LEFT"){
            Physics.gravity = getPrev();
            GameObject.Find("Main Camera").GetComponent<Rotate>().turn(0);
        }
        if(other.gameObject.name == "RIGHT"){            
            Physics.gravity = getNext();
            GameObject.Find("Main Camera").GetComponent<Rotate>().turn(1);
        }
        
        other.gameObject.GetComponent<BoxCollider>().enabled = false;
     }
}

