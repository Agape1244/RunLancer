using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haikeiview : MonoBehaviour {


    public GameObject Haikei1;
    public GameObject Haikei2;
    public GameObject gamemaster;
    public GameObject H1Prefab;
    public GameObject H2Prefab;
    public GameObject Yuka;
    public GameObject movingHaikei;
    public GameObject TyekkuH1;


    
    public float SHaikei1;
    public float SHaikei2;
    public float Haikeiset;
    public float count;
    public float Haikeimove;





    // Use this for initialization
    void Start () {

        StartCoroutine(SetHaikei1());//背景を産む命令をスタートで繰り返しさせちゃうぜ！
        //StartCoroutine(SetHaikei2());//背景を産む命令をスタートで繰り返しさせちゃうぜ！

        // StartCoroutine(SetYuka());//床を産む命令をスタートで繰り返しさせちゃうぜ！
       
        StartCoroutine(MoveHaikei());//動く命令


    }


    IEnumerator SetHaikei1()//ブロックをセットする命令
    {

        while (true)//ブレイクのないwhile文。。。つまりエンドレス？
        {
            Vector3 pos = TyekkuH1.transform.position;
            if (pos.x < -2f)
            {
                Vector3 pos1 = new Vector3(35, 0.5f, 0);//pos指定
                GameObject Haikei1P = Instantiate(Haikei1, pos1, transform.rotation) as GameObject;//インスタンス、これはぽすの場所にオブジェクト召喚しちゃうやつ。
                Haikei1P.transform.parent = movingHaikei.transform;//生み出したオブジェクトの親関係。むーびんぐ背景にいんすたんすしたくろーんをいれちゃうぜ

                Vector3 posT = new Vector3(35, -3, 0);
                GameObject TyekkuH1P = Instantiate(TyekkuH1, posT, transform.rotation) as GameObject;
                TyekkuH1P.transform.parent = movingHaikei.transform;//生み出したオブジェクトの親関係。むーびんぐ背景にいんすたんすしたくろーんをいれちゃうぜ

            }
            yield return 0;//i秒でもっかいする

           

           
        }
	}


    IEnumerator MoveHaikei()//ブロックが移動する命令
    {
        while (true)
        {//ぶれいくのないわいるぶん
            float speed = gamemaster.GetComponent<Gamemaster>().Speed;//ゲームマスターというオブジェクトからスピードという概念を引用代入！
            Vector3 pos = movingHaikei.transform.position;//ぽすにムービングブロックの位置情報いれるぜ
            pos.x -= (Blockmove * speed) * Time.deltaTime;//ぽすのX方向（マイナス）に調整用計算×１秒
            movingBlock.transform.position = pos;//ムービングブロックにポス（変動後）の位置情報を入れる
            yield return 0;
            //todo 解析完了。速度関連微調整の必要あり
        }
    }


    // Update is called once per frame
    void Update() 
            {

            }
            
           

}
