using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour {
    [SerializeField]
    Text scoreriz;

    private GameObject master;
    [SerializeField]
    private bool checkSceneChange=true;

    public bool GetSceneChange()
    {
        return checkSceneChange;
    }

	// Use this for initialization
	void Start () {
        ScoreYomu();
        DestroyGameMaster();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            checkSceneChange = false;
            SceneManager.LoadScene("Title");
        }

    }

    void ScoreYomu()
    {
        master = GameObject.Find("GameMaster");
        Gamemaster gamemaster;
        gamemaster = master.GetComponent<Gamemaster>();
        scoreriz.text="Score:"+gamemaster.Getallscore().ToString();
    }
    void DestroyGameMaster()
    {
        Destroy(master);
    }

}
