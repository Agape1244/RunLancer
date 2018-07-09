using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemaster : MonoBehaviour {

    public float Speed;
    public float Kasokudo;



    // Use this for initialization
    void Start () {
        StartCoroutine(Morespeed());
        StartCoroutine(Logger());

    }

    IEnumerator Morespeed()//Speedが加速する処理
    {
        while (true)
        {//ぶれいくのないわいるぶん
            Speed += Kasokudo * Time.deltaTime;//スピードに１秒当たりKasokudoづつ増加
            yield return 0;

        }
    }

    IEnumerator Logger()//Speedの値をLogに書き出す
    {
        while (true)
        {//ぶれいくのないわいるぶん
            Debug.Log(Speed);
            yield return new WaitForSeconds(1.0f);

        }
    }
    // Update is called once per frame
    void Update () {

    }
}
