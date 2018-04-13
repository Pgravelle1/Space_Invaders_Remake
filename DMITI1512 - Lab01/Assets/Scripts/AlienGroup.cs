using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienGroup: MonoBehaviour {

    int moveTimer;

    public bool boundsReached = false;
    public bool isAlreadyInBounds = false;

    GameWinLose gameWinLoseScript;


    public float shipDescent = 3f;
    public float shipSpeed = 3f;

    // Use this for initialization
    void Start ()
    {
        shipDescent *= -1;
        gameWinLoseScript = GameObject.Find("Game Win/Lose Logic").GetComponent<GameWinLose>();

    }

    // Update is called once per frame
    void Update ()
    {
        moveTimer++;

        if (moveTimer >= 60)
        {
            moveTimer = 0;
            if (boundsReached)
            {
                isAlreadyInBounds = true;
                shipSpeed *= -1;
                gameObject.transform.Translate(0, shipDescent, 0, Space.World);
                boundsReached = false;
            }
            else
            {
                gameObject.transform.Translate(shipSpeed, 0, 0, Space.World);
            }
        }

        if (transform.childCount == 0)
        {
            gameWinLoseScript.gameWon= true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isAlreadyInBounds = false;
    }

}
