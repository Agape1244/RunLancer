using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockmodel : MonoBehaviour {

    /// <summary>
    /// 破壊可能かどうか
    /// </summary>
    [SerializeField]
    private bool breakTrg;

    /// <summary>
    /// スコア値
    /// </summary>
    [SerializeField]
    private int scorepoint;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
		
	}

    void OnTriggerEnter2D(Collider2D collider)//Unityでの当たり判定の命令
    {
        if (collider.tag == "Player")
        {
            Debug.Log("DODOD" + collider);
            if (breakTrg)
            {
                


                BreakBlock();
                
                // Debug.Log("break");
            }
            else
            {

                NoBreakBlock();
                // Debug.Log("No break");
            }
        }
    }
    /// <summary>
    /// ブロックを壊す命令
    /// </summary>
    void BreakBlock()
    {
        GameObject master;
        master = GameObject.Find("GameMaster");
        Gamemaster gamemaster;
        gamemaster = master.GetComponent<Gamemaster>();
        gamemaster.ScoreAdd(scorepoint);


       Destroy(this.gameObject);//this

    } 



    /// <summary>
    /// 壊れないブロックに触れた時の命令
    /// </summary>
    void NoBreakBlock()
    {
        GameObject master;
        master = GameObject.Find("GameMaster");
        Gamemaster gamemaster;
        gamemaster = master.GetComponent<Gamemaster>();
        gamemaster.Gameover();

    }





}
