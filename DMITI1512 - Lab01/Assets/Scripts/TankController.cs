using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TankController : MonoBehaviour {

    Animator tankAnimator;
    public Transform projectile;
    GameWinLose gameWinLoseScript;

    public float tankSpeed = 15;
    float xTranslation;

    bool boundsLeftReached = false;
    bool boundsRightReached = false;

    int timer = 0;

    // Use this for initialization
    void Start ()
    {
        tankAnimator = gameObject.GetComponent<Animator>();
        gameWinLoseScript = GameObject.Find("Game Win/Lose Logic").GetComponent<GameWinLose>();
    }

    // Update is called once per frame
    void Update ()
    {
        #region Tank Movement and Animation
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            tankAnimator.SetBool("Moving", true);

            xTranslation = tankSpeed * Input.GetAxis("Horizontal");
            xTranslation *= Time.deltaTime;

            // If attempting to move left and leftBounds not reached...
            if (xTranslation < 0 && !boundsLeftReached)
            {
                // Ensure rightBounds is false
                boundsRightReached = false;
                // Then move me left
                transform.Translate(new Vector3(xTranslation, 0), Space.Self);
            }
            // If attempting to move right, and RightBounds not reached...
            if (xTranslation > 0 && !boundsRightReached)
            {
                // Ensure leftBounds if false
                boundsLeftReached = false;
                // then move me right
                transform.Translate(new Vector3(xTranslation, 0), Space.Self);
            }

        }
        else
        {
            tankAnimator.SetBool("Moving", false);
        }
        #endregion

        #region Tank Projectile Spawner
        timer++;
        if (Input.GetKey(KeyCode.Space) && timer > 60)
        {
            timer = 0;
            Transform newProjectile = Instantiate(projectile);            
            newProjectile.position = transform.position;
        }
        #endregion
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bounds")
        {
            // If the bounds I collided with is on my right
            if (collision.transform.position.x > transform.position.x)
            {
                // Set boundsRightReached to true to stop movement
                boundsRightReached = true;
            }
            // If the bounds I collided with is on my left
            if (collision.transform.position.x < transform.position.x)
            {
                // Set boundsLeftReached to true to stop movement
                boundsLeftReached = true;
            }
        }
        if (collision.gameObject.tag == "AlienProjectile" || collision.gameObject.tag == "Alien")
        {
            gameWinLoseScript.gameLost = true;
            Destroy(gameObject);
        }
    }
}
