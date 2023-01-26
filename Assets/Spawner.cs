using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float time(float x){
        return 10.0458f/x - .00554707f;
    }

    public GameObject box;

    public float speed;
    public bool running=true;
    public int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MyCoroutine());
    }


    IEnumerator MyCoroutine()
    {
        while(running){
            Spawn();
            yield return new WaitForSeconds(1);
        }

    }

    void Spawn(){
        GameObject spawnedBox = (GameObject)Instantiate(box, new Vector3(0, 0, 50) , Quaternion.Euler(0, 0, 0));
        ///Debug.Break();
        //spawnedBox.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -10f);
        i++;
        if(i == 2){
            //change scale of spawnedBox.
            spawnedBox.transform.localScale = new Vector3(1, 1, 1.1f);
            //spawnedBox.transform.position = new Vector3(0, 0, 0);
        }

    }

    // Update is called once per frame
    void Update()
    { 
    }

}
