using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockview : MonoBehaviour {

    public GameObject Rblock;
    public GameObject Bblock;
    public GameObject movingBlock;


	// Use this for initialization
	void Start () {
        StartCoroutine(MoveMap());//このふたつは止めたり進めたりすることができる命令でっせ
        StartCoroutine(SetBlock());
        
	}
	

    IEnumerator SetBlock()//ブロックをセットする命令
    {
        while (true)//ブレイクのないwhile文。。。つまりエンドレス？
        {
            Vector3 posB = new Vector3(11, Random.Range(3f, -1.5f), 0);//ランダムなY軸３F～－１．５
            Vector3 posR = new Vector3(11, Random.Range(3f, -1.5f), 0);
            GameObject blockB=Instantiate(Bblock,posB,transform.rotation) as GameObject;//インスタンス、これはぽすの場所にオブジェクト召喚しちゃうやつ。
            GameObject blockR = Instantiate(Rblock, posR, transform.rotation) as GameObject;
            blockB.transform.parent = movingBlock.transform;//生み出したオブジェクトの親関係。むーびんぐブロックにいんすたんすしたくろーんをいれちゃうぜ
            blockR.transform.parent = movingBlock.transform;
            yield return new WaitForSeconds(1.5f);//１．５秒処理するのまってねー
            //todo　解析完了。現状ブロックが重なっても無視して召喚しちゃうのでそこ直したいが、後回し。
            //todo ぅえいとふぉあせこんどずの（）内はSpeedに合わせて間隔短くすることによってブロック召喚が早くなる
        }
     
    }
    //繰り返しの保証？
    IEnumerator MoveMap()//ブロックが移動する命令
    {
        while (true) {//ぶれいくのないわいるぶん
            Vector3 pos = movingBlock.transform.position;//ぽすにムービングブロックの位置情報いれるぜ
            pos.x -= 4 * Time.deltaTime;//ぽすのX方向（マイナス）に一秒あたり４進む
            movingBlock.transform.position = pos;//ムービングブロックにポス（変動後）の位置情報を入れる
            yield return 0;
            //todo 解析完了。Speedに合わせて数字を大きくすることによって左へ早く流れる
        }
    }

    //todo 床や森も同じように入れることであたかもプレイヤーが右に移動してるように見せれる
	// Update is called once per frame
	void Update () {
		
	}
}
