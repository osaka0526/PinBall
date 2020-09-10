using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    //スコアを表示するテキスト
    private GameObject scoreText;

    //スコア
    private int score = 0;


    // Use this for initialization
    void Start()
    {
        //シーン中のScoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");
    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        //SmallStarTag衝突時
        if (other.gameObject.CompareTag("SmallStarTag"))
        {
            score += 10;
        }
        //LargeStarTag衝突時
        else if (other.gameObject.CompareTag("LargeStarTag"))
        {
            score += 50;
        }
        //SmallCloudTag衝突時
        else if (other.gameObject.CompareTag("SmallCloudTag"))
        {
            score += 100;
        }
        //LargeCloudTag衝突時
        else if (other.gameObject.CompareTag("LargeCloudTag"))
        {
            score += 150;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //スコア表示
        this.scoreText.GetComponent<Text>().text = score + "pt";
    }
}

