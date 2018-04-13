using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShipController : MonoBehaviour
{

    int random;
    public Transform projectilePrefab;
    int shootTimer;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer++;
        random = Random.Range(1, 1600);
        if (random == 1 && shootTimer > 30)
        {
            shootTimer = 0;
            Transform projectile = Instantiate(projectilePrefab);
            projectile.position = transform.position;
        }

    }
    
}
