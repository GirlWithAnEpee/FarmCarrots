using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotGeneration : MonoBehaviour
{
    public GameObject carrotPrefab;
    public float spawnInterval = 2f;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            Instantiate(carrotPrefab, new Vector3(Random.Range(-10, 40),1, Random.Range(-50, -20)), transform.rotation);
        }
    }
}
