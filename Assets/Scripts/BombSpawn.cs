using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawn : MonoBehaviour
{
    public Transform bombSpawnTransform;
    public GameObject bombSpawnPrefab;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(bombSpawnPrefab, bombSpawnTransform.position, bombSpawnTransform.rotation);
    }
}
