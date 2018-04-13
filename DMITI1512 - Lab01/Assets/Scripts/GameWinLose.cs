using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinLose : MonoBehaviour {
    GameObject tank;


    public bool gameLost = false;
    public bool gameWon = false;

	// Use this for initialization
	void Start () {
        tank = GameObject.Find("Tank");
    }

    // Update is called once per frame
    void Update () {
		if (gameLost)
        {
            Invoke("LoseScreen", 2f);
        }

        if (gameWon)
        {
            Invoke("WinScreen", 2f);
        }
	}

    public void LoseScreen()
    {
        SceneManager.LoadScene("Lose Screen");
    }

    public void WinScreen()
    {
        SceneManager.LoadScene("Win Screen");
    }


}
