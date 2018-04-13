using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBoundsScript : MonoBehaviour {

    GameObject alienGroup;
    AlienGroup alienGroupScript;
    // Use this for initialization
    void Start () {
        alienGroup = GameObject.Find("Ships");
        alienGroupScript = alienGroup.GetComponent<AlienGroup>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Alien")
        {
            if (!alienGroupScript.isAlreadyInBounds)
            {
                alienGroupScript.boundsReached = true;      
            }
        }
    }

}
