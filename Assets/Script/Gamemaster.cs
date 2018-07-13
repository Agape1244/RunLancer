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

    public AudioSource sound01;
    public AudioSource sound02;

    private bool getSceneChange=true;

    private float speedAdd=0;



    public int Getallscore()
    {
        return allscore;
    }
    [SerializeField]
    Text kasanScore;
    [SerializeField]
    Text speedtext;
    [SerializeField]
    Text scoretext;

    /// <summary>
    /// GameOverへのシーン移動
    /// </summary>
    public void Gameover()
    {
        sound02.PlayOneShot(sound02.clip);
        SceneManager.LoadScene("GameOver");

    }
    /// <summary>
    /// オールスコアにスコアを加算
    /// </summary>
    /// <param name="score"></param>
    public void ScoreAdd(int score)
    {

        sound01.PlayOneShot(sound01.clip);
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
            allscore += (int)Speed;
            scoretext.text = "Score:" + allscore;
            speedAdd++;

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
