using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cloud1;
    public GameObject cloud2;
    public GameObject cloud3;
    public GameObject cloud4;
    private List<GameObject> clouds = new List<GameObject>();
    [SerializeField] private float cloudPerSec = 1;
    private Vector3 max;
    private Vector3 min;

    void Start()
    {
        max = GetComponent<Renderer>().bounds.max;
        min = GetComponent<Renderer>().bounds.min;
        clouds.Add(cloud1);
        clouds.Add(cloud2);
        clouds.Add(cloud3);
        clouds.Add(cloud4);
        InvokeRepeating("SpawnCloud", 1.0f, 1.0f / cloudPerSec);
    }

    // Update is called once per frame
    void SpawnCloud()
    {
        Vector3 location = new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), Random.Range(min.z, max.z));
        Quaternion rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        GameObject temp = clouds[Random.Range(0, 4)];
        Instantiate(temp, location, rotation);

    }
}
