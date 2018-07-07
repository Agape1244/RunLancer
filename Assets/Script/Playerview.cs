using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerview : MonoBehaviour {

    private Rigidbody2D rb2D;//リジットボデーの箱
    private float jumpForce = 10.0f;//ジャンプパワー１０

	// Use this for initialization
	void Start () {
        rb2D = GetComponent<Rigidbody2D>();//リジットボデーの読み込み
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();//←マウスクリックでジャンプ。命令内容は下で
        }
	}

    void Jump()//ジャンプの命令内容
    {
        rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
    }//ベロシティは早さをつかさどる（べくたー２の）
    //これによりリジットボデーに指定されたオブジェクトはX軸は特になし、Y軸にジャンプフォースで指示したぱうわー１０の速度、で動く、という命令ジャンプができた。
    //todo 動作確認完了。クリックでジャンプ。ふわふわしてた。２段３段とジャンプできちゃう。要修正
}
