using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShipShooting : MonoBehaviour
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
        random = Random.Range(3, 2000);
        if (random == 3 && shootTimer > 30)
        {
            shootTimer = 0;
            Transform projectile = Instantiate(projectilePrefab);
            projectile.position = transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
