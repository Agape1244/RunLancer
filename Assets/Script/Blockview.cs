using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockview : MonoBehaviour {

    public GameObject Rblock;
    public GameObject Bblock;
    public GameObject movingBlock;


	// Use this for initialization
	void Start () {
        StartCoroutine(MoveMap());//このふたつはこるーちんしちゃうぜ
        StartCoroutine(SetBlock());
	}
	
    IEnumerator SetBlock()//ブロックをセットする命令
    {
        while (true)
        {
            Vector3 pos = new Vector3(11, Random.Range(3f, -1.5f), 0);
            Vector3 pos1 = new Vector3(11, Random.Range(3f, -1.5f), 0);
            GameObject block=Instantiate(Bblock,pos,transform.rotation) as GameObject;
            GameObject block1 = Instantiate(Rblock, pos1, transform.rotation) as GameObject;
            block.transform.parent = movingBlock.transform;
            block1.transform.parent = movingBlock.transform;
            yield return new WaitForSeconds(1.5f);
            //todo　ほぼ借り物。解析まだ。実行可否まだ。つまりまだまだ。
            //todo ぅえいとふぉあせこんどずの（）内はSpeedに合わせて間隔短くしていきたい
        }
     
    }

    IEnumerator MoveMap()//ブロックが移動する命令
    {
        while (true) {
            Vector3 pos = movingBlock.transform.position;
            pos.x -= 4 * Time.deltaTime;
            movingBlock.transform.position = pos;
            yield return 0;//todo これも借り物。解析まだ。背景動かすものっぽい？
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
