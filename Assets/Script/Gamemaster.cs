using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemaster : MonoBehaviour {

    public float Speed;
    public float Kasokudo;
    public float morespeed;



    // Use this for initialization
    void Start () {
        StartCoroutine(Morespeed());//スピードが増えていく命令
        StartCoroutine(Logger());//スピードをログに残す命令

    }

    IEnumerator Morespeed()//Speedが加速する処理
    {
        while (true)
        {//ぶれいくのないわいるぶん
            Speed += Kasokudo;//スピードにモアスピード秒当たりKasokudoづつ増加
            yield return new WaitForSeconds(morespeed);

        }
    }

    IEnumerator Logger()//Speedの値をLogに書き出す
    {
        while (true)
        {//ぶれいくのないわいるぶんは永遠と続く
            yield return new WaitForSeconds(1.0f);//それを一秒ごとにやんな！

        }
    }
    // Update is called once per frame
    void Update () {

    }
}
