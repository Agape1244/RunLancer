﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameover : MonoBehaviour {
    [SerializeField]
    Text scoreriz;

	// Use this for initialization
	void Start () {
        ScoreYomu();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ScoreYomu()
    {
        GameObject master;
        master = GameObject.Find("GameMaster");
        Gamemaster gamemaster;
        gamemaster = master.GetComponent<Gamemaster>();
        scoreriz.text="Score:"+gamemaster.Getallscore().ToString();
    }

}
