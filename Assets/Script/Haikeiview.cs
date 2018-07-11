using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haikeiview : MonoBehaviour {


    public GameObject Haikei1;
    public GameObject Haikei2;
    public GameObject gamemaster;
    public GameObject Haikei1Prefab;
    public GameObject Haikei2Prefab;
    public GameObject Yuka;
    public GameObject CheckHaikei1;
    //public Gameobject CheckHaikei2;
    public GameObject movingHaikei;
    public GameObject movingCheck;


    
    public float SpeedHaikei1;
    public float SpeedHaikei2;
    public float Haikeiset;
    public float Haikeimove;
    public Vector3 Checkpos;




    // Use this for initialization
    void Start () {
        StartCoroutine(MoveHaikei1());//動く命令
        StartCoroutine(MoveCheck());//動く命令
        StartHaikei1Set();//最初の背景召喚

    }

    IEnumerator MoveCheck()//ブロックが移動する命令
    {
        while (true)
        {//ぶれいくのないわいるぶん
            float speed = gamemaster.GetComponent<Gamemaster>().Speed;//ゲームマスターというオブジェクトからスピードという概念を引用代入！
            Vector3 pos = movingCheck.transform.position;//ぽすにムービング背景の位置情報いれるぜ
            pos.x -= (Haikeimove * speed) * Time.deltaTime;//ぽすのX方向（マイナス）に調整用計算*１秒
            movingCheck.transform.position = pos;//ムービング背景にポス（変動後）の位置情報を入れる
            yield return 0;
            //todo 解析完了。速度関連微調整の必要あり
        }
    }

    IEnumerator MoveHaikei1()//ブロックが移動する命令
    {
        while (true)
        {//ぶれいくのないわいるぶん
            float speed = gamemaster.GetComponent<Gamemaster>().Speed;//ゲームマスターというオブジェクトからスピードという概念を引用代入！
            Vector3 pos = movingHaikei.transform.position;//ぽすにムービング背景の位置情報いれるぜ
            pos.x -= (Haikeimove * speed) * Time.deltaTime;//ぽすのX方向（マイナス）に調整用計算*１秒
            movingHaikei.transform.position = pos;//ムービング背景にポス（変動後）の位置情報を入れる
            yield return 0;
            //todo 解析完了。速度関連微調整の必要あり
        }
    }


    // Update is called once per frame
    void Update() 
            {

        CheckHaikei1pos();//チェック背景の位置情報を更新するためのもの

        if (CheckHaikei1SetTiming())//条件ー背景がセッティングされるタイミング
        {
            Haikei1Set();//背景をセッティングする命令
            Debug.Log("true");//ログ

        }

    }


    void StartHaikei1Set()//初回背景召喚
    {
        Vector3 pos1 = new Vector3(35, 0.5f, 0);//pos指定
        GameObject Haikei1P = Instantiate(Haikei1, pos1, transform.rotation) as GameObject;//インスタンス、これはぽすの場所にオブジェクト召喚しちゃうやつ。
        Haikei1P.transform.parent = movingHaikei.transform;//生み出したオブジェクトの親関係。むーびんぐ背景にいんすたんすしたくろーんをいれちゃうぜ

        Vector3 posC = new Vector3(35, -3, 0);
        GameObject CheckHaikei1Prefab = Instantiate(CheckHaikei1, posC, transform.rotation) as GameObject;//オブジェクト生成
        CheckHaikei1Prefab.transform.parent = movingHaikei.transform;//生み出したオブジェクトの親関係。むーびんぐ背景にいんすたんすしたくろーんをいれちゃうぜ



    }

    void Haikei1Set()
    {
            Vector3 pos1 = new Vector3(55, 0.5f, 0);//pos指定
            GameObject Haikei1P = Instantiate(Haikei1, pos1, transform.rotation) as GameObject;//インスタンス、これはぽすの場所にオブジェクト召喚しちゃうやつ。
            Haikei1P.transform.parent = movingHaikei.transform;//生み出したオブジェクトの親関係。むーびんぐ背景にいんすたんすしたくろーんをいれちゃうぜ
            movingCheck.transform.position = new Vector3(35, 0, 0);//ムービングチェックの位置を動かしちゃうぜ

    }

    void CheckHaikei1pos()//ポジション確認せい！の命令
    {
        Vector3 pos = movingCheck.transform.position;//チェック背景の位置を代入
        Checkpos = pos;//パブリックなチェックポスにムービングチェックの位置情報突っ込むぜー
    }
    bool CheckHaikei1SetTiming()//背景のチェックの命令
    {
        if (Checkpos.x < -2f) return true;//チェック背景の位置のXがー２以下ならば正
        else return false;//それ以外は否
    }


}
