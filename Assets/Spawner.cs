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

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MyCoroutine());
    }


    IEnumerator MyCoroutine()
    {
        while(running){
            Spawn();
            Debug.Log("ran");
            yield return new WaitForSeconds(time(speed));
        }

    }

    void Spawn(){
        GameObject spawnedBox = (GameObject)Instantiate(box, new Vector3(0, 0, 50) , Quaternion.Euler(0, 0, 0));
        spawnedBox.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -speed);

    }

    // Update is called once per frame
    void Update()
    {

    }

}
