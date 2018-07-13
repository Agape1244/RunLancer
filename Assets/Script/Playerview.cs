using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerview : MonoBehaviour {

    private Rigidbody2D rb2D;//リジットボデーの箱
    [SerializeField]
    private float jumpForce;
    private const int MAX_JUMP_COUNT = 2;//ジャンプできる最大回数

    private int jumpCount = 0;
    private bool isJump=false;






	// Use this for initialization
	void Start () {
        rb2D = GetComponent<Rigidbody2D>();//リジットボデーの読み込み
		
	}

    // Update is called once per frame
    void Update()
    {
        if (jumpCount < MAX_JUMP_COUNT && Input.GetMouseButtonDown(0))
        {
            isJump = true;
            if (isJump)
            {
                rb2D.AddForce(new Vector2(0, jumpForce * 10.0f));
                jumpCount++;
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Yuka")
        {
            jumpCount = 0;
        }
    }
}
