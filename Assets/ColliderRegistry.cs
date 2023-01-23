using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderRegistry : MonoBehaviour
{
    public List<Collision> colliders = new List<Collision>();
     public List<Collision> GetColliders () { return colliders; }

     public bool isPlayerhere;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    float timer = 10f;

    // Update is called once per frame
    void Update()
    {
        isPlayerhere = isPlayer();
        

        timer -= Time.deltaTime;
        if (GetComponent<BoxCollider>().enabled == false && timer <= 0)
        {

        }
        if(GetComponent<BoxCollider>().enabled == false){
            Debug.Log("disabled");
            if(!isPlayerhere){
                GetComponent<BoxCollider>().enabled = true;
            }
        }
    }

     
 
    private void OnCollisionEnter (Collision other) {
         if (!colliders.Contains(other)) { colliders.Add(other); }
     }
 
     private void OnCollisionExit (Collision other) {
         colliders.Remove(other);
     }

     public bool isPlayer(){
            foreach(Collision c in colliders){
                if(c.gameObject.name == "Player"){
                    return true;
                }
            }
            return false;
     }


}
