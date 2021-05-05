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
    private List<GameObject> clouds;
    public float rate = 10;
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
        Debug.Log(clouds);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time % Mathf.Round(100 / rate) == 0f)
        {
            Vector3 location = new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), Random.Range(min.z, max.z));
            Quaternion rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            GameObject temp = clouds[Random.Range(0, 4)];
            Debug.Log(temp);
            // newCloud = Instantiate(temp, location, rotation);
        }
    }
}
