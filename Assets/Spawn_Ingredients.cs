using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Ingredients : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] smallMushroomSpawns;
    void Start()
    {
        //Spawn each of the ingredients
        smallMushroomSpawns = GameObject.FindGameObjectsWithTag("SmallMushroomSpawn");
        foreach(GameObject spawn in smallMushroomSpawns){
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
