using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGhosts : MonoBehaviour
{
    public GameObject ghost;
    float nextTimeToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        nextTimeToSpawn = 2f;


    }
    private void InstantiateGhosts(GameObject ghost){
        Instantiate(ghost, gameObject.transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextTimeToSpawn)
        {
            InstantiateGhosts(ghost);
            nextTimeToSpawn += 10f;
        }
    }
}
