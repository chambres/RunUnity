using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vars : MonoBehaviour
{
    public static float chance = 0.9f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("changeChance", 0, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        void changeChance()
    {
        chance -= 0.001f;
    }
}
