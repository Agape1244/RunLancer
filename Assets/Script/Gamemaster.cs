using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Gamemaster : MonoBehaviour {

    public float Speed;
    public float Kasokudo;
    public float morespeed;

    private int allscore=0;

    public int Getallscore()
    {
        return allscore;
    }

    [SerializeField]
    Text speedtext;
    [SerializeField]
    Text scoretext;

    /// <summary>
    /// GameOver
    /// </summary>
    public void Gameover()
    {
        SceneManager.LoadScene("GameOver");

    }

    public void ScoreAdd(int score)
    {
        allscore += score;
        scoretext.text = "Score:" + allscore;
    }


    // Use this for initialization
    void Start () {
        scoretext.text = "Score:0";
        DontDestroyOnLoad(this.gameObject);//死なないオブジェクト
        StartCoroutine(Morespeed());//スピードが増えていく命令
        StartCoroutine(Logger());//スピードをログに残す命令

    }

    IEnumerator Morespeed()//Speedが加速する処理
    {
        while (true)
        {//ぶれいくのないわいるぶん
            Speed += Kasokudo;//スピードにモアスピード秒当たりKasokudoづつ増加
            if (speedtext != null) 
                speedtext.text="Speed:"+Speed.ToString();


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
