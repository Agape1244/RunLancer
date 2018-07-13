using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockmodel : MonoBehaviour {

    /// <summary>
    /// 破壊可能かどうか
    /// </summary>
    [SerializeField]
    private bool breakTrg;

    [SerializeField]
    ParticleSystem particleEffect;

    /// <summary>
    /// スコア値
    /// </summary>
    [SerializeField]
    private int scorepoint;

    [SerializeField]
    private GameObject test;





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
        AddParticul();

        //todo パーティクル発生タイミング


       Destroy(this.gameObject);//this

    } 

    void AddParticul()
    {
        Vector3 pos = this.gameObject.transform.position;
        GameObject particle = Instantiate(particleEffect.gameObject, pos, transform.rotation) ;//インスタンス、これはぽすの場所にオブジェクト召喚しちゃうやつ。
       // particleEffect.transform.position=this.gameObject.transform.position;
        particleEffect.Emit(1);
        Debug.Log("パーティクルON");

        Destroy(particle, 1.0f);
        //todo パーティクルはできた
        //todo パーティクルの発生はできた
        //todo 表示順を直した
        //todo パーティクルの位置の指定できた

        //増えるオブジェクト消えた
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
