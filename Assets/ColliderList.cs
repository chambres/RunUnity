 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class ColliderList : MonoBehaviour
 {
     public static List<GameObject> colliderList = new List<GameObject>();
 
     public void OnTriggerEnter(Collider collider)
     {
         if (!colliderList.Contains(collider.gameObject))
         {
             colliderList.Add(collider.gameObject);
         }
     }
 
     public void OnTriggerExit(Collider collider)
     {
         if(colliderList.Contains(collider.gameObject))
         {
             colliderList.Remove(collider.gameObject);
         }
     }


     public static bool isPlayer(){
        foreach(GameObject go in colliderList){
            if(go.name == "Player"){
                return true;
            }
        }
        return false;
     }
 }