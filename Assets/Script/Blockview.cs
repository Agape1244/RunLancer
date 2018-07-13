using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockview : MonoBehaviour {

    public GameObject Rblock;
    public GameObject Bblock;
    public GameObject movingBlock;
    public GameObject gamemaster;


    public float Blockset;
    public float Blockmove;
    public float count;



	
    
    // Use this for initialization
	void Start () {
        StartCoroutine(MoveMap());//動く命令
        StartCoroutine(SetBlock());//ブロックを産む命令をスタートで繰り返しさせちゃうぜ！
        
	}
	

    IEnumerator SetBlock()//ブロックをセットする命令
    {

        while (true)//ブレイクのないwhile文。。。つまりエンドレス？
        {
            float speed = gamemaster.GetComponent<Gamemaster>().Speed;//ゲームマスターというオブジェクトからスピードという概念を引用代入！
            float i=count-(speed*Blockset);//ブロック召喚調整用計算

            if (i < 0)
            {
                i = 0.3f;
            }
            yield return new WaitForSeconds(i);//i秒でもっかいする
            
            int R = UnityEngine.Random.Range(0, 2);//ランダムで壊れるブロック、壊れないブロックをどちらか生成
            if (R == 1)
            {
            Vector3 posB = new Vector3(11, Random.Range(2.7f, -3.0f), 0);//ランダムなY軸３F～－１．５
            GameObject blockB=Instantiate(Bblock,posB,transform.rotation) as GameObject;//インスタンス、これはぽすの場所にオブジェクト召喚しちゃうやつ。
            blockB.transform.parent = movingBlock.transform;//生み出したオブジェクトの親関係。むーびんぐブロックにいんすたんすしたくろーんをいれちゃうぜ

            }
            else
            {
            Vector3 posR = new Vector3(11, Random.Range(2.7f, -3.0f), 0);
            GameObject blockR = Instantiate(Rblock, posR, transform.rotation) as GameObject;
            blockR.transform.parent = movingBlock.transform;


            }


            //todo 速度関連微調整の必要あり
            //todo　解析完了。
        }
     
    }
    //繰り返しの保証
    IEnumerator MoveMap()//ブロックが移動する命令
    {
        while (true) {//ぶれいくのないわいるぶん
            float speed = gamemaster.GetComponent<Gamemaster>().Speed;//ゲームマスターというオブジェクトからスピードという概念を引用代入！
            Vector3 pos = movingBlock.transform.position;//ぽすにムービングブロックの位置情報いれるぜ
            pos.x -= (Blockmove*speed) * Time.deltaTime;//ぽすのX方向（マイナス）に調整用計算×１秒
            movingBlock.transform.position = pos;//ムービングブロックにポス（変動後）の位置情報を入れる
            yield return 0;
            //todo 解析完了。速度関連微調整の必要あり
        }
    }


    //todo 床や森も同じように入れることであたかもプレイヤーが右に移動してるように見せれる
	// Update is called once per frame
	void Update () {
		
	}
}
